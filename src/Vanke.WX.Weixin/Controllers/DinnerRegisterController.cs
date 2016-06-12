using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using EZ.Framework.Integration.WebApi;
using Vanke.WX.Weixin.Common;
using Vanke.WX.Weixin.Service.Interface;
using Vanke.WX.Weixin.Service.Models;

namespace Vanke.WX.Weixin.Controllers
{
    [RoutePrefix("api/dinnerregister")]
    public class DinnerRegisterController : GenericApiController
    {
        private readonly IDinnerRegisterService _dinnerRegisterService = IoC.Container.GetInstance<IDinnerRegisterService>();

        /// <summary>
        /// Get all item borrow history
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("search")]
        public async Task<IEnumerable<DinnerRegisterModel>> Search(string status)
        {
            return
                await
                    _dinnerRegisterService.GetAllAsync(string.IsNullOrEmpty(status)
                        ? null
                        : new[] {(DinnerRegisterStatus) int.Parse(status)});
        }

        /// <summary>
        /// Insert/Update dinner type
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task Save(DinnerRegisterModel model)
        {
            await _dinnerRegisterService.InsertAsync(model);
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
            await _dinnerRegisterService.CancelAsync(id);
        }
    }
}
