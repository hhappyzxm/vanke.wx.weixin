using System.Threading.Tasks;
using EZ.Framework.Core;
using Vanke.WX.Weixin.Data.Entity;

namespace Vanke.WX.Weixin.Service.Interface
{
    public interface IAdminService : IService
    {
        Task InsertAsync(Admin entity);

        Task UpdateAsync(Admin entity);
    }
}
