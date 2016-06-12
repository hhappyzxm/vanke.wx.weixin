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
    public class ItemBorrowController : GenericApiController
    {
        private readonly IItemBorrowService _itemBorrowService = IoC.Container.GetInstance<IItemBorrowService>();

        /// <summary>
        /// Get all item borrow history
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("search")]
        public async Task<IEnumerable<ItemBorrowModel>> Search(string status)
        {
            return
                await
                    _itemBorrowService.GetAllAsync(string.IsNullOrEmpty(status)
                        ? null
                        : new[] {(ItemBorrowStatus) int.Parse(status)});
        }

        [HttpGet]
        [Route("getownhistories")]
        public async Task<IEnumerable<ItemBorrowModel>> GetOwnHistories()
        {
            return await _itemBorrowService.GetOwnHistoriesAsync();
        }

        /// <summary>
        /// Borrow item
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("borrow")]
        public async Task Borrow(ItemBorrowModel model)
        {
            await _itemBorrowService.InsertAsync(model);
        }

        /// <summary>
        /// Insert/Update dinner type
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task Save(ItemBorrowModel model)
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
