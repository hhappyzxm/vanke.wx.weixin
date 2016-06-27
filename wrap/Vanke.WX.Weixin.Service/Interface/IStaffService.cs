using System.Threading.Tasks;
using EZ.Framework;
using Vanke.WX.Weixin.Data.Entity;
using Vanke.WX.Weixin.Service.Models;

namespace Vanke.WX.Weixin.Service.Interface
{
    public interface IStaffService : ICRUDAsyncService<StaffModel>
    {
        Staff GetByOpenID(string openId);

        void BindOpenId(int staffId, string openId);
    }
}
