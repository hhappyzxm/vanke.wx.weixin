using System.Diagnostics;
using EZ.Framework.EntityFramework;
using Vanke.WX.Weixin.Common;
using Vanke.WX.Weixin.Data.Entity;
using Vanke.WX.Weixin.Data.Repository.Interface;

namespace Vanke.WX.Weixin.Data.Repository
{
    public class ItemBorrowRepository : EFRepository<ItemBorrowHistory>, IItemBorrowRepository
    {
        public ItemBorrowRepository(IDataContext dataContext) : base(dataContext)
        {
        }

        public override void Remove(ItemBorrowHistory entity)
        {
            entity.Status = ItemBorrowStatus.Removed;

            Update(entity);
        }
    }
}
