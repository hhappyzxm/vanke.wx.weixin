using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using EZ.Framework.Integration.WebApi;
using Vanke.WX.Weixin.Common;
using Vanke.WX.Weixin.Data.Entity;
using Vanke.WX.Weixin.Service.Interface;
using Vanke.WX.Weixin.Service.Models;

namespace Vanke.WX.Weixin.Controllers
{
    public class ItemsController : GenericApiController
    {
        private readonly IItemService _itemService = IoC.Container.GetInstance<IItemService>();

        /// <summary>
        /// Get all items
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<Item>> Get()
        {
            return await _itemService.GetAllAsync();
        }

        /// <summary>
        /// Get item by key
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<Item> Get(int id)
        {
            return await _itemService.GetByKeyAsync(id);
        }
        
        /// <summary>
        /// Insert/Update item
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task Save(Item entity)
        {
            if (entity.ID == 0)
            {
                await _itemService.InsertAsync(entity);
            }
            else
            {
                await _itemService.UpdateAsync(entity);
            }
        }

        /// <summary>
        /// Delete item
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task Delete(int id)
        {
            await _itemService.RemoveAsync(id);
        }
    }
}
