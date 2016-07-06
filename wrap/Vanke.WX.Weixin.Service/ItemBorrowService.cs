using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EZ.Framework.Integration.WebApi;
using EZ.Framework.NoRepository.EntityFramework;
using Vanke.WX.Weixin.Common;
using Vanke.WX.Weixin.Data.Entity;
using Vanke.WX.Weixin.Service.Interface;
using Vanke.WX.Weixin.Service.Models;
using EZ.Framework;

namespace Vanke.WX.Weixin.Service
{
    public class ItemBorrowService : Service<IDataContext>, IItemBorrowService
    {
        public ItemBorrowService(IDataContext dataContext) : base(dataContext)
        {
        }

        public async Task CancelAsync(long key)
        {
            var entity = await UnitOfWork.Set<ItemBorrowHistory>().FindAsync(key);

            entity.Status = ItemBorrowStatus.Cancelled;
            entity.CancelledBy = (long)AccountManager.Instance.CurrentLoginUser.ID;
            entity.CancelledOn = DateTime.Now;

            await UnitOfWork.SaveChangesAsync();
        }

        public async Task ReturnAsync(long key)
        {
            var entity = await UnitOfWork.Set<ItemBorrowHistory>().FindAsync(key);

            entity.Status = ItemBorrowStatus.Returned;
            entity.ReturnedBy = (long)AccountManager.Instance.CurrentLoginUser.ID;
            entity.ReturnedOn = DateTime.Now;

            await UnitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<ItemBorrowModel>> GetAllAsync(
            ItemBorrowStatus[] filterStatuses = null, long? borrowBy = null)
        {
            var query = from borrowHistory in UnitOfWork.Set<ItemBorrowHistory>()
                        join staff in UnitOfWork.Set<Staff>() on borrowHistory.StaffID equals staff.ID
                        join t1 in UnitOfWork.Set<Staff>() on borrowHistory.ReturnedBy equals t1.ID into tt1
                        from returnStaff in tt1.DefaultIfEmpty()
                        join t2 in UnitOfWork.Set<Staff>() on borrowHistory.CancelledBy equals t2.ID into tt2
                        from cancelStaff in tt2.DefaultIfEmpty()
                        join item in UnitOfWork.Set<Item>() on borrowHistory.ItemID equals item.ID
                        orderby borrowHistory.BorrowedOn descending 
                        select new
                        {
                            BorrowHistory = borrowHistory,
                            Staff = staff,
                            ReturnStaff = returnStaff,
                            CancelStaff = cancelStaff,
                            Item = item
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

            if (borrowBy.HasValue)
            {
                query = query.Where(p => p.BorrowHistory.StaffID == borrowBy);
            }

            return await query.Select(p => new ItemBorrowModel
            {
                ID = p.BorrowHistory.ID,
                Staff = p.Staff.RealName,
                Item = p.Item.Name,
                Status = p.BorrowHistory.Status,
                Quantity = p.BorrowHistory.Quantity,
                Comment = p.BorrowHistory.Comment,
                BorrowedOn = p.BorrowHistory.BorrowedOn,
                CancelledOn = p.BorrowHistory.CancelledOn,
                CancelledStaff = p.CancelStaff == null ? string.Empty : p.CancelStaff.RealName,
                ReturnedOn = p.BorrowHistory.ReturnedOn,
                ReturnedStaff = p.ReturnStaff == null ? string.Empty : p.ReturnStaff.RealName
            }).ToListAsync();
        }

        public async Task<IEnumerable<ItemBorrowModel>> GetOwnHistoriesAsync()
        {
            return await this.GetAllAsync(null, (long) AccountManager.Instance.CurrentLoginUser.ID);
        }

        public async Task InsertAsync(ItemBorrowModel model)
        {
            var entity = new ItemBorrowHistory
            {
                StaffID = (long)AccountManager.Instance.CurrentLoginUser.ID,
                ItemID = model.ItemID,
                Quantity = model.Quantity,
                BorrowedOn = DateTime.Now,
                Comment = model.Comment,
                Status = ItemBorrowStatus.Active
            };


            UnitOfWork.Set<ItemBorrowHistory>().Add(entity);
            await UnitOfWork.SaveChangesAsync();
        }
    }
}
