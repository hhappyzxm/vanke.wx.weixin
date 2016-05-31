using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EZ.Framework;
using EZ.Framework.Integration.WebApi;
using EZ.Framework.NoRepository.EntityFramework;
using Vanke.WX.Weixin.Common;
using Vanke.WX.Weixin.Data.Entity;
using Vanke.WX.Weixin.Service.Interface;
using Vanke.WX.Weixin.Service.Models;

namespace Vanke.WX.Weixin.Service
{
    public class IdleAssetService : Service<IDataContext>, IIdleAssetService
    {
        public IdleAssetService(IDataContext dataContext) : base(dataContext)
        {
        }

        public Task InsertAsync(ItemModel model)
        {
            throw new NotImplementedException();
        }

        public Task<ItemModel> GetByKeyAsync(object key)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ItemModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(object key, ItemModel model)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(object key)
        {
            throw new NotImplementedException();
        }
    }
}
