using EZ.Framework.EntityFramework;
using Vanke.WX.Weixin.Common;
using Vanke.WX.Weixin.Data.Entity;
using Vanke.WX.Weixin.Data.Repository.Interface;

namespace Vanke.WX.Weixin.Data.Repository
{
    public class StaffRepository : EFRepository<Staff>, IStaffRepository
    {
        public StaffRepository(IDataContext dataContext) : base(dataContext)
        {
        }

        public override void Remove(Staff entity)
        {
            entity.Status = StaffStatus.Removed;

            Update(entity);
        }
    }
}
