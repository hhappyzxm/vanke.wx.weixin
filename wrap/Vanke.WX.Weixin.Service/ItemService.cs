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
    public class ItemService : GenericService<IDataContext, Item, ItemModel>, IItemService
    {
        public ItemService(IDataContext dataContext) : base(dataContext)
        {
        }

        protected override Expression<Func<Item, ItemModel>> ModelSelector()
        {
            return p => new ItemModel
            {
                ID = p.ID,
                Name = p.Name,
                Status = p.Status
            };
        }

        protected override void ConvertToEntity(ItemModel model, ref Item targetEntity)
        {
            targetEntity.ID = model.ID;
            targetEntity.Name = model.Name;
            targetEntity.Status = model.Status;
        }

        public override async Task<ItemModel> GetByKeyAsync(object key)
        {
            return await UnitOfWork.Set<Item>().Select(ModelSelector()).SingleOrDefaultAsync(p => p.ID == (long)key);
        }

        public override async Task<IEnumerable<ItemModel>> GetAllAsync()
        {
            return await
                UnitOfWork.Set<Item>()
                    .Where(p => p.Status == ItemStatus.Active)
                    .Select(ModelSelector())
                    .ToListAsync();
        }

        protected override async Task InsertEntityAsync(Item entity)
        {
            await CheckItemExist(entity);

            entity.Status = ItemStatus.Active;
            entity.CreatedOn = DateTime.Now;
            entity.CreatedBy = (long)AccountManager.Instance.CurrentLoginUser.ID;

            await base.InsertEntityAsync(entity);
        }

        protected override async Task UpdateEntityAsync(Item entity)
        {
            await CheckItemExist(entity);

            entity.UpdatedOn = DateTime.Now;
            entity.UpdatedBy = (long)AccountManager.Instance.CurrentLoginUser.ID;

            await base.UpdateEntityAsync(entity);
        }

        protected override Task RemoveEntityAsync(Item entity)
        {
            entity.Status = ItemStatus.Removed;

            return base.UpdateEntityAsync(entity);
        }

        private async Task CheckItemExist(Item entity)
        {
            if (await UnitOfWork.Set<Item>().AnyAsync(p => p.Name.Equals(entity.Name) && p.ID != entity.ID && p.Status!= ItemStatus.Removed))
            {
                throw new BusinessException("物品已经存在");
            }
        }
    }
}
