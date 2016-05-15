using EZ.Framework.EntityFramework;
using Vanke.WX.Weixin.Common;
using Vanke.WX.Weixin.Data.Entity;
using Vanke.WX.Weixin.Data.Repository.Interface;

namespace Vanke.WX.Weixin.Data.Repository
{
    public class DinnerTypeRepository : EFRepository<DinnerType>, IDinnerTypeRepository
    {
        public DinnerTypeRepository(IDataContext dataContext) : base(dataContext)
        {
        }

        public override void Remove(DinnerType entity)
        {
            entity.Status = DinnerTypeStatus.Removed;

            Update(entity);
        }
    }
}
