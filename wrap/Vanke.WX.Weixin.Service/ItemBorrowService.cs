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

        
        //protected override Task InsertEntityAsync(ItemBorrowHistory entity)
        //{
        //    entity.StaffID = AccountManager.Instance.GetCurrentLoginUser<CurrentLogin>().StaffID;
        //    entity.Status = ItemBorrowStatus.Active;
        //    entity.BorrowedOn = DateTime.Now;

        //    return base.InsertEntityAsync(entity);
        //}
        
        public async Task CancelAsync(object key)
        {
            var entity = await UnitOfWork.Set<ItemBorrowHistory>().FindAsync(key);

            entity.Status = ItemBorrowStatus.Cancelled;
            entity.CancelledBy = (long)AccountManager.Instance.CurrentLoginUser.ID;
            entity.CancelledOn = DateTime.Now;

            await UnitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<ItemBorrowModel>> GetAllItemBorrowHistoryAsync(
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

        public Task<ItemBorrowModel> GetByKeyAsync(object key)
        {
            throw new NotImplementedException();
        }

        public Task InsertAsync(ItemBorrowModel model)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(object key,  ItemBorrowModel model)
        {
            throw new NotImplementedException();
        }
    }
}
