using EZ.Framework.EntityFramework;
using Vanke.WX.Weixin.Common;
using Vanke.WX.Weixin.Data.Entity;
using Vanke.WX.Weixin.Data.Repository.Interface;

namespace Vanke.WX.Weixin.Data.Repository
{
    public class ItemRepository : EFRepository<Item>, IItemRepository
    {
        public ItemRepository(IDataContext dataContext) : base(dataContext)
        {
        }

        public override void Remove(Item entity)
        {
            entity.Status = ItemStatus.Removed;

            Update(entity);
        }
    }
}
