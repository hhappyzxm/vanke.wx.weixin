using System.Threading.Tasks;
using EZ.Framework.Core;
using Vanke.WX.Weixin.Data.Entity;

namespace Vanke.WX.Weixin.Service.Interface
{
    public interface IStaffService : IService
    {
        Task InsertAsync(Staff entity);
    }
}
