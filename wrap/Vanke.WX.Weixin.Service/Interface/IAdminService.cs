using EZ.Framework;
using Vanke.WX.Weixin.Data.Entity;

namespace Vanke.WX.Weixin.Service.Interface
{
    public interface IAdminService : ICRUDAsyncService<Admin>, IRetrieveService<Admin>
    {
        Admin Login(string loginName, string password);
    }
}
