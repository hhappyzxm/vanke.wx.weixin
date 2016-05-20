using EZ.Framework;
using EZ.Framework.NoRepository.EntityFramework;
using Vanke.WX.Weixin.Service.Interface;

namespace Vanke.WX.Weixin.Service
{
    public class StaffService : Service<IDataContext>, IStaffService
    {
        public StaffService(IDataContext dataContext) : base(dataContext)
        {
        }
    }
}
