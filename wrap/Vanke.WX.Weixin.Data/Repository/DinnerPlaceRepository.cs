using EZ.Framework.EntityFramework;
using Vanke.WX.Weixin.Common;
using Vanke.WX.Weixin.Data.Entity;
using Vanke.WX.Weixin.Data.Repository.Interface;

namespace Vanke.WX.Weixin.Data.Repository
{
    public class DinnerPlaceRepository : EFRepository<DinnerPlace>, IDinnerPlaceRepository
    {
        public DinnerPlaceRepository(IDataContext dataContext) : base(dataContext)
        {
        }

        public override void Remove(DinnerPlace entity)
        {
            entity.Status = DinnerPlaceStatus.Removed;

            Update(entity);
        }
    }
}
