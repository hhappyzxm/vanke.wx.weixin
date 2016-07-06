using System.Collections.Generic;
using System.Threading.Tasks;
using EZ.Framework;
using Vanke.WX.Weixin.Common;
using Vanke.WX.Weixin.Service.Models;

namespace Vanke.WX.Weixin.Service.Interface
{
    public interface IDinnerRegisterService : ICreateAsyncService<DinnerRegisterModel>
    {
        Task<IEnumerable<DinnerRegisterModel>> GetAllAsync(DinnerRegisterStatus[] filterStatuses = null, long? registerBy = null);

        Task<IEnumerable<DinnerRegisterModel>> GetOwnHistoriesAsync();

        Task CancelAsync(long key);

        Task ReadAsync(long key);
    }
}

