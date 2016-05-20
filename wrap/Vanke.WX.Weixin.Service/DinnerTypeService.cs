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
    public class DinnerTypeService : GenericService<IDataContext, DinnerType, DinnerTypeModel>, IDinnerTypeService
    {
        public DinnerTypeService(IDataContext dataContext) : base(dataContext)
        {
        }

        protected override Expression<Func<DinnerType, DinnerTypeModel>> ModelSelector()
        {
            return p => new DinnerTypeModel
            {
                ID = p.ID,
                Type = p.Type,
                Status = p.Status
            };
        }

        protected override void ConvertToEntity(DinnerTypeModel model, ref DinnerType targetEntity)
        {
            targetEntity.ID = model.ID;
            targetEntity.Type = model.Type;
            targetEntity.Status = model.Status;
        }

        public override async Task<DinnerTypeModel> GetByKeyAsync(object key)
        {
            return await UnitOfWork.Set<DinnerType>().Select(ModelSelector()).SingleOrDefaultAsync(p => p.ID == (long)key);
        }

        public override async Task<IEnumerable<DinnerTypeModel>> GetAllAsync()
        {
            return await
                UnitOfWork.Set<DinnerType>()
                    .Select(ModelSelector())
                    .Where(p => p.Status == DinnerTypeStatus.Active)
                    .ToListAsync();
        }

        protected override async Task InsertEntityAsync(DinnerType entity)
        {
            await CheckTypeExist(entity);

            entity.Status = DinnerTypeStatus.Active;
            entity.CreatedOn = DateTime.Now;
            entity.CreatedBy = (long)AccountManager.Instance.CurrentLoginUser.ID;

            await base.InsertEntityAsync(entity);
        }

        public override async Task UpdateEntityAsync(DinnerType entity)
        {
            await CheckTypeExist(entity);

            entity.UpdatedOn = DateTime.Now;
            entity.UpdatedBy = (long)AccountManager.Instance.CurrentLoginUser.ID;

            await base.UpdateEntityAsync(entity);
        }

        public override async Task RemoveAsync(object key)
        {
            var entity = UnitOfWork.Set<DinnerType>().Find(key);
            entity.Status = DinnerTypeStatus.Removed;

            await UpdateEntityAsync(entity);
        }

        private async Task CheckTypeExist(DinnerType entity)
        {
            if (await UnitOfWork.Set<DinnerType>().AnyAsync(p => p.Type.Equals(entity.Type) && p.ID != entity.ID))
            {
                throw new BusinessException("宴请类型已经存在");
            }
        }
    }
}
