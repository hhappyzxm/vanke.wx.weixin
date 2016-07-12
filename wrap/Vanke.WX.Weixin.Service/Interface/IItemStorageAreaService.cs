﻿using System.Threading.Tasks;
using EZ.Framework;
using Vanke.WX.Weixin.Service.Models;

namespace Vanke.WX.Weixin.Service.Interface
{
    public interface IItemStorageAreaService : ICRUDAsyncService<ItemStorageAreaModel>
    {
        Task<ItemStorageAreaModel> GetByNameAsync(string name);
    }
}
