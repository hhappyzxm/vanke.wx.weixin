using System.Threading.Tasks;
using EZ.Framework;
using Vanke.WX.Weixin.Data.Entity;

namespace Vanke.WX.Weixin.Service.Interface
{
    public interface IStaffService : IService
    {
        Task InsertAsync(Staff entity);
    }
}
