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
    public class ItemStorageAreaService : GenericService<IDataContext, ItemStorageArea, ItemStorageAreaModel>, IItemStorageAreaService
    {
        public ItemStorageAreaService(IDataContext dataContext) : base(dataContext)
        {
        }

        protected override Expression<Func<ItemStorageArea, ItemStorageAreaModel>> ModelSelector()
        {
            return p => new ItemStorageAreaModel
            {
                ID = p.ID,
                Area = p.Area,
                Status = p.Status
            };
        }

        protected override void ConvertToEntity(ItemStorageAreaModel model, ref ItemStorageArea targetEntity)
        {
            targetEntity.ID = model.ID;
            targetEntity.Area = model.Area;
            targetEntity.Status = model.Status;
        }

        public override async Task<ItemStorageAreaModel> GetByKeyAsync(object key)
        {
            return await UnitOfWork.Set<ItemStorageArea>().Select(ModelSelector()).SingleOrDefaultAsync(p => p.ID == (long)key);
        }

        public override async Task<IEnumerable<ItemStorageAreaModel>> GetAllAsync()
        {
            return await
                UnitOfWork.Set<ItemStorageArea>()
                    .Where(p => p.Status == ItemStorageAreaStatus.Active)
                    .Select(ModelSelector())
                    .ToListAsync();
        }

        protected override async Task InsertEntityAsync(ItemStorageArea entity)
        {
            await CheckItemExist(entity);

            entity.Status = ItemStorageAreaStatus.Active;
            entity.CreatedOn = DateTime.Now;
            entity.CreatedBy = (long)AccountManager.Instance.CurrentLoginUser.ID;

            await base.InsertEntityAsync(entity);
        }

        public override async Task UpdateEntityAsync(ItemStorageArea entity)
        {
            await CheckItemExist(entity);

            entity.UpdatedOn = DateTime.Now;
            entity.UpdatedBy = (long)AccountManager.Instance.CurrentLoginUser.ID;

            await base.UpdateEntityAsync(entity);
        }

        public override async Task RemoveAsync(object key)
        {
            var entity = UnitOfWork.Set<ItemStorageArea>().Find(key);
            entity.Status = ItemStorageAreaStatus.Removed;

            await UpdateEntityAsync(entity);
        }

        private async Task CheckItemExist(ItemStorageArea entity)
        {
            if (await UnitOfWork.Set<ItemStorageArea>().AnyAsync(p => p.Area.Equals(entity.Area) && p.ID != entity.ID))
            {
                throw new BusinessException("存放区域已经存在");
            }
        }
    }
}
