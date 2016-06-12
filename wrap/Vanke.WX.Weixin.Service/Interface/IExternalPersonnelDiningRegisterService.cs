using System.Collections.Generic;
using System.Threading.Tasks;
using EZ.Framework;
using Vanke.WX.Weixin.Common;
using Vanke.WX.Weixin.Service.Models;

namespace Vanke.WX.Weixin.Service.Interface
{
    public interface IExternalPersonnelDiningRegisterService : ICreateAsyncService<ExternalPersonnelDiningRegisterModel>
    {
        Task<IEnumerable<ExternalPersonnelDiningRegisterModel>> GetAllAsync(ExternalPersonnelDiningRegisterStatus[] filterStatuses = null);

        Task<IEnumerable<ExternalPersonnelDiningRegisterModel>> GetOwnHistoriesAsync();

        Task CancelAsync(long key);
    }
}
