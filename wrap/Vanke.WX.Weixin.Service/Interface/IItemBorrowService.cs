using System.Collections.Generic;
using System.Threading.Tasks;
using EZ.Framework;
using Vanke.WX.Weixin.Common;
using Vanke.WX.Weixin.Data.Entity;
using Vanke.WX.Weixin.Service.Models;

namespace Vanke.WX.Weixin.Service.Interface
{
    public interface IItemBorrowService : ICRUDAsyncService<ItemBorrowHistory>
    {
        Task<IEnumerable<ItemBorrowModel>> GetAllItemBorrowHistoryAsync(ItemBorrowStatus[] filterStatuses = null);

        Task CancelAsync(object key);
    }
}

