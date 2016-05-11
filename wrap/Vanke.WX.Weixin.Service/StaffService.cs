using EZ.Framework.EntityFramework;
using Vanke.WX.Weixin.Data.Entity;
using Vanke.WX.Weixin.Data.Repository.Interface;
using Vanke.WX.Weixin.Service.Interface;

namespace Vanke.WX.Weixin.Service
{
    public class StaffService : CRUDService<IDataContext, IStaffRepository, Staff>, IStaffService
    {
        public StaffService(IDataContext dataContext, IStaffRepository repository) : base(dataContext, repository)
        {
        }
    }
}
