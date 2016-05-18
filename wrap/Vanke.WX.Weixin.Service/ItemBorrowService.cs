using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using EZ.Framework.EntityFramework;
using EZ.Framework.Integration.WebApi;
using Vanke.WX.Weixin.Common;
using Vanke.WX.Weixin.Data.Entity;
using Vanke.WX.Weixin.Data.Repository.Interface;
using Vanke.WX.Weixin.Service.Interface;
using Vanke.WX.Weixin.Service.Models;

namespace Vanke.WX.Weixin.Service
{
    public class ItemBorrowService : CRUDService<IDataContext, IItemBorrowRepository, ItemBorrowHistory>, IItemBorrowService
    {
        public ItemBorrowService(IDataContext dataContext, IItemBorrowRepository repository) : base(dataContext, repository)
        {
        }

        protected override Task BeforeInsertAsync(ItemBorrowHistory entity)
        {
            entity.StaffID = AccountManager.Instance.GetCurrentLoginUser<CurrentLogin>().StaffID;
            entity.Status = ItemBorrowStatus.Active;
            entity.BorrowedOn = DateTime.Now;

            return base.BeforeInsertAsync(entity);
        }

        protected override Task BeforeUpdateAsync(ItemBorrowHistory entity)
        {
            entity.CancelledBy = (long)AccountManager.Instance.CurrentLoginUser.ID;
            entity.CancelledOn = DateTime.Now;

            return base.BeforeUpdateAsync(entity);
        }

        public async Task CancelAsync(object key)
        {
            var entity = await Repository.GetByKeyAsync(key);
            entity.Status = ItemBorrowStatus.Cancelled;

            await this.UpdateAsync(entity);
        }

        public async Task<IEnumerable<ItemBorrowModel>> GetAllItemBorrowHistoryAsync(
            ItemBorrowStatus[] filterStatuses = null)
        {
            var query = from borrowHistory in UnitOfWork.Set<ItemBorrowHistory>()
                join staff in UnitOfWork.Set<Staff>() on borrowHistory.StaffID equals staff.ID
                select new
                {
                    BorrowHistory = borrowHistory,
                    Staff = staff
                };

            if (filterStatuses == null)
            {
                query = query.Where(p => p.BorrowHistory.Status != ItemBorrowStatus.Removed);
            }
            else
            {
                foreach (var status in filterStatuses)
                {
                    query = query.Where(p => p.BorrowHistory.Status == status);
                }
            }

            return await query.Select(p => new ItemBorrowModel
            {
                ID = p.BorrowHistory.ID,
                Staff = p.Staff.RealName,
                Quantity = p.BorrowHistory.Quantity,
                BorrowTime = p.BorrowHistory.BorrowedOn,
                CancelledTime = p.BorrowHistory.CancelledOn
            }).ToListAsync();
        }

        public override async Task<IEnumerable<ItemBorrowHistory>> GetAllAsync()
        {
            return await Repository.ToListAsync(p => p.Status != ItemBorrowStatus.Removed);
        }
    }
}
