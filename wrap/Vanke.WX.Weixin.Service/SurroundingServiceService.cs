using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
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
    public class SurroundingServiceService : GenericService<IDataContext, SurroundingService, SurroundingServiceModel>, ISurroundingServiceService
    {
        public SurroundingServiceService(IDataContext dataContext) : base(dataContext)
        {
        }

        protected override Expression<Func<SurroundingService, SurroundingServiceModel>> ModelSelector()
        {
            return p => new SurroundingServiceModel
            {
                ID = p.ID,
                Name = p.Name,
                ImagePath = p.ImagePath,
                Description = p.Description,
                UnitPrice = p.UnitPrice,
                Address = p.Address,
                Phone = p.Phone,
                Recommendation = p.Recommendation
            };
        }

        protected override void ConvertToEntity(SurroundingServiceModel model, ref SurroundingService targetEntity)
        {
            targetEntity.ID = model.ID;
            targetEntity.Name = model.Name;
            targetEntity.ImagePath = model.ImagePath;
            targetEntity.Description = model.Description;
            targetEntity.UnitPrice = model.UnitPrice;
            targetEntity.Address = model.Address;
            targetEntity.Phone = model.Phone;
            targetEntity.Recommendation = model.Recommendation;
        }

        public override async Task<SurroundingServiceModel> GetByKeyAsync(object key)
        {
            return await UnitOfWork.Set<SurroundingService>().Select(ModelSelector()).SingleOrDefaultAsync(p => p.ID == (long)key);
        }

        public override async Task<IEnumerable<SurroundingServiceModel>> GetAllAsync()
        {
            return await
                UnitOfWork.Set<SurroundingService>()
                    .Where(p => p.Status == SurroundingServiceStatus.Active)
                    .Select(ModelSelector())
                    .ToListAsync();
        }

        protected override async Task InsertEntityAsync(SurroundingService entity)
        {
            await CheckItemExist(entity);

            entity.Status = SurroundingServiceStatus.Active;
            entity.CreatedOn = DateTime.Now;
            entity.CreatedBy = (long)AccountManager.Instance.CurrentLoginUser.ID;

            await base.InsertEntityAsync(entity);
        }

        protected override async Task UpdateEntityAsync(SurroundingService entity)
        {
            await CheckItemExist(entity);

            entity.UpdatedOn = DateTime.Now;
            entity.UpdatedBy = (long)AccountManager.Instance.CurrentLoginUser.ID;

            await base.UpdateEntityAsync(entity);
        }

        protected override Task RemoveEntityAsync(SurroundingService entity)
        {
            entity.Status = SurroundingServiceStatus.Removed;

            return base.UpdateEntityAsync(entity);
        }

        private async Task CheckItemExist(SurroundingService entity)
        {
            if (await UnitOfWork.Set<SurroundingService>().AnyAsync(p => p.Name.Equals(entity.Name) && p.ID != entity.ID))
            {
                throw new BusinessException("名称已经存在");
            }
        }
    }
}
