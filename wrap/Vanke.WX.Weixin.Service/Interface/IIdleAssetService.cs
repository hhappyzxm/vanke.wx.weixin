﻿using System.Threading.Tasks;
using EZ.Framework;
using Vanke.WX.Weixin.Service.Models;

namespace Vanke.WX.Weixin.Service.Interface
{
    public interface IIdleAssetService : ICRUDAsyncService<IdleAssetModel>
    {
        Task InsertOrUpdate(IdleAssetModel model);
    }
}
