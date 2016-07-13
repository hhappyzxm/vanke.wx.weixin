using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EZ.Framework;
using EZ.Framework.Integration.WebApi;
using EZ.Framework.NoRepository.EntityFramework;
using Vanke.WX.Weixin.Common;
using Vanke.WX.Weixin.Data.Entity;
using Vanke.WX.Weixin.Service.Interface;
using Vanke.WX.Weixin.Service.Models;

namespace Vanke.WX.Weixin.Service
{
    public class MealTypeService : GenericService<IDataContext, MealType, MealTypeModel>, IMealTypeService
    {
        public MealTypeService(IDataContext dataContext) : base(dataContext)
        {
        }

        protected override Expression<Func<MealType, MealTypeModel>> ModelSelector()
        {
            return p => new MealTypeModel
            {
                ID = p.ID,
                Type = p.Type,
                Status = p.Status
            };
        }

        protected override void ConvertToEntity(MealTypeModel model, ref MealType targetEntity)
        {
            targetEntity.ID = model.ID;
            targetEntity.Type = model.Type;
            targetEntity.Status = model.Status;
        }

        public override async Task<MealTypeModel> GetByKeyAsync(object key)
        {
            return await UnitOfWork.Set<MealType>().Select(ModelSelector()).SingleOrDefaultAsync(p => p.ID == (long)key);
        }

        public override async Task<IEnumerable<MealTypeModel>> GetAllAsync()
        {
            return await
                UnitOfWork.Set<MealType>()
                    .Where(p => p.Status == MealTypeStatus.Active)
                    .Select(ModelSelector())
                    .ToListAsync();
        }

        protected override async Task InsertEntityAsync(MealType entity)
        {
            await CheckTypeExist(entity);

            entity.Status = MealTypeStatus.Active;
            entity.CreatedOn = DateTime.Now;
            entity.CreatedBy = (long)AccountManager.Instance.CurrentLoginUser.ID;

            await base.InsertEntityAsync(entity);
        }

        protected override async Task UpdateEntityAsync(MealType entity)
        {
            await CheckTypeExist(entity);

            entity.UpdatedOn = DateTime.Now;
            entity.UpdatedBy = (long)AccountManager.Instance.CurrentLoginUser.ID;

            await base.UpdateEntityAsync(entity);
        }

        protected override Task RemoveEntityAsync(MealType entity)
        {
            entity.Status = MealTypeStatus.Removed;

            return base.UpdateEntityAsync(entity);
        }

        private async Task CheckTypeExist(MealType entity)
        {
            if (await UnitOfWork.Set<MealType>().AnyAsync(p => p.Type.Equals(entity.Type) && p.ID != entity.ID && p.Status!= MealTypeStatus.Removed))
            {
                throw new BusinessException("餐别已经存在");
            }
        }
    }
}
