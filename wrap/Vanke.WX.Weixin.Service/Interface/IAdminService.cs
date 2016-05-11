using System.Threading.Tasks;
using EZ.Framework.Core;

namespace Vanke.WX.Weixin.Service.Interface
{
    public interface IAdminService : IService
    {
        Task Insert();
    }
}
