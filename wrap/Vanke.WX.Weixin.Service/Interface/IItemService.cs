using System.Collections.Generic;
using System.Threading.Tasks;
using EZ.Framework;
using EZ.Framework.EntityFramework;
using Vanke.WX.Weixin.Data.Entity;
using Vanke.WX.Weixin.Service.Models;

namespace Vanke.WX.Weixin.Service.Interface
{
    public interface IItemService : ICRUDAsyncService<Item>
    {
    }
}
