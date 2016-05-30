using System.Collections.Generic;
using System.Threading.Tasks;
using EZ.Framework;
using Vanke.WX.Weixin.Common;
using Vanke.WX.Weixin.Service.Models;

namespace Vanke.WX.Weixin.Service.Interface
{
    public interface IItemBorrowService : ICreateAsyncService<ItemBorrowModel>
    {
        Task<IEnumerable<ItemBorrowModel>> GetAllAsync(ItemBorrowStatus[] filterStatuses = null);

        Task CancelAsync(long key);
    }
}

