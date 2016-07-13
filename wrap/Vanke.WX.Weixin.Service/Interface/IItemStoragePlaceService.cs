using System.Collections.Generic;
using System.Threading.Tasks;
using EZ.Framework;
using Vanke.WX.Weixin.Service.Models;

namespace Vanke.WX.Weixin.Service.Interface
{
    public interface IItemStoragePlaceService : ICRUDAsyncService<ItemStoragePlaceModel>
    {
        Task<IEnumerable<ItemStoragePlaceModel>> GetAllAsync(long areaId = 0);

        Task<ItemStoragePlaceModel> GetByNameAsync(long areaId, string name);
    }
}
