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

        public async Task<IEnumerable<ItemBorrowModel>> GetAllAsync(
            ItemBorrowStatus[] filterStatuses = null)
        {
            var query = from borrowHistory in UnitOfWork.Set<ItemBorrowHistory>()
                join staff in UnitOfWork.Set<Staff>() on borrowHistory.StaffID equals staff.ID
                join item in UnitOfWork.Set<Item>() on borrowHistory.ItemID equals  item.ID
                select new
                {
                    BorrowHistory = borrowHistory,
                    Staff = staff,
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

            return await query.Select(p => new ItemBorrowModel
            {
                ID = p.BorrowHistory.ID,
                Staff = p.Staff.RealName,
                Item = p.Item.Name,
                Status = p.BorrowHistory.Status,
                Quantity = p.BorrowHistory.Quantity,
                BorrowedOn = p.BorrowHistory.BorrowedOn,
                CancelledOn = p.BorrowHistory.CancelledOn
            }).ToListAsync();
        }

        public async Task<IEnumerable<ItemBorrowModel>> GetOwnHistoriesAsync()
        {
            var staffId = (long) AccountManager.Instance.CurrentLoginUser.ID;

            return await UnitOfWork.Set<ItemBorrowHistory>()
                .Where(
                    p =>
                        p.Status != ItemBorrowStatus.Removed &&
                        p.StaffID == staffId)
                .OrderByDescending(p => p.BorrowedOn)
                .Select(p => new ItemBorrowModel
                {
                    ID = p.ID,
                    Item = p.Item.Name,
                    Status = p.Status,
                    Quantity = p.Quantity,
                    BorrowedOn = p.BorrowedOn,
                    CancelledOn = p.CancelledOn
                })
                .ToListAsync();
        }

        public async Task InsertAsync(ItemBorrowModel model)
        {
            var entity = new ItemBorrowHistory
            {
                StaffID = (long)AccountManager.Instance.CurrentLoginUser.ID,
                ItemID = model.ItemID,
                Quantity = model.Quantity,
                BorrowedOn = DateTime.Now,
                Status = ItemBorrowStatus.Active
            };

            UnitOfWork.Set<ItemBorrowHistory>().Add(entity);
            await UnitOfWork.SaveChangesAsync();
        }
    }
}
