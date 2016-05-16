using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EZ.Framework;
using EZ.Framework.EntityFramework;
using EZ.Framework.Integration.WebApi;
using Vanke.WX.Weixin.Common;
using Vanke.WX.Weixin.Data.Entity;
using Vanke.WX.Weixin.Data.Repository.Interface;
using Vanke.WX.Weixin.Service.Interface;

namespace Vanke.WX.Weixin.Service
{
    public class ItemService : CRUDService<IDataContext, IItemRepository, Item>, IItemService
    {
        public ItemService(IDataContext dataContext, IItemRepository repository) : base(dataContext, repository)
        {
        }

        protected override async Task BeforeInsertAsync(Item entity)
        {
            await CheckItemExist(entity);

            entity.Status = ItemStatus.Active;
            entity.CreatedOn = DateTime.Now;
            entity.CreatedBy = (long)AccountManager.Instance.CurrentLoginUser.ID;
        }

        protected override async Task BeforeUpdateAsync(Item entity)
        {
            await CheckItemExist(entity);

            entity.UpdatedOn = DateTime.Now;
            entity.UpdatedBy = (long)AccountManager.Instance.CurrentLoginUser.ID;
        }

        public override async Task<IEnumerable<Item>> GetAllAsync()
        {
            return await Repository.ToListAsync(p => p.Status == ItemStatus.Active);
        }

        private async Task CheckItemExist(Item entity)
        {
            if (await Repository.AnyAsync(p => p.Name.Equals(entity.Name) && p.ID != entity.ID))
            {
                throw new BusinessException("物品已经存在");
            }
        }
    }
}
