using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    public class ItemBorrowService : CRUDService<IDataContext, IItemBorrowRepository, ItemBorrowHistory>, IItemBorrowService
    {
        public ItemBorrowService(IDataContext dataContext, IItemBorrowRepository repository) : base(dataContext, repository)
        {
        }

        protected override Task BeforeInsertAsync(ItemBorrowHistory entity)
        {
            entity.Status = ItemBorrowStatus.Active;
            entity.CreatedOn = DateTime.Now;
            entity.CreatedBy = (long)AccountManager.Instance.CurrentLoginUser.ID;

            return base.BeforeInsertAsync(entity);
        }

        protected override Task BeforeUpdateAsync(ItemBorrowHistory entity)
        {
            entity.UpdatedBy = (long)AccountManager.Instance.CurrentLoginUser.ID;
            entity.UpdatedOn = DateTime.Now;

            return base.BeforeUpdateAsync(entity);
        }

        public async Task CancelAsync(object key)
        {
            var entity = await Repository.GetByKeyAsync(key);
            entity.Status = ItemBorrowStatus.Cancelled;

            await this.UpdateAsync(entity);
        }

        public override async Task<IEnumerable<ItemBorrowHistory>> GetAllAsync()
        {
            return await Repository.ToListAsync(p => p.Status != ItemBorrowStatus.Removed);
        }
    }
}
