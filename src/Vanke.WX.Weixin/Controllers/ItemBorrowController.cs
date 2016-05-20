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
    [RoutePrefix("api/itemborrow")]
    [AllowAnonymous]
    public class ItemBorrowController : GenericApiController
    {
        private readonly IItemBorrowService _itemBorrowService = IoC.Container.GetInstance<IItemBorrowService>();

        /// <summary>
        /// Get all item borrow history
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<ItemBorrowModel>> Get()
        {
            return await _itemBorrowService.GetAllItemBorrowHistoryAsync();
        }

        /// <summary>
        /// Borrow item
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("borrow")]
        public async Task Borrow(ItemBorrowModel model)
        {
            await _itemBorrowService.InsertAsync(model);
        }

        /// <summary>
        /// Cancel borrow
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("cancel/{id}")]
        public async Task Cancel(long id)
        {
            await _itemBorrowService.CancelAsync(id);
        }
    }
}
