using System;
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
    [RoutePrefix("api/externalpersonneldiningregister")]
    public class ExternalPersonnelDiningRegisterController : GenericApiController
    {
        private readonly IExternalPersonnelDiningRegisterService _externalPersonnelDiningRegisterService = IoC.Container.GetInstance<IExternalPersonnelDiningRegisterService>();

        /// <summary>
        /// Get all item borrow history
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("search")]
        public async Task<IEnumerable<ExternalPersonnelDiningRegisterModel>> Search(string status)
        {
            return
                await
                    _externalPersonnelDiningRegisterService.GetAllAsync(string.IsNullOrEmpty(status)
                        ? null
                        : new[] { (ExternalPersonnelDiningRegisterStatus)int.Parse(status) });
        }

        /// <summary>
        /// Borrow item
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("borrow")]
        public async Task Borrow(ExternalPersonnelDiningRegisterModel model)
        {
            await _externalPersonnelDiningRegisterService.InsertAsync(model);
        }

        /// <summary>
        /// Insert/Update dinner type
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task Save(ExternalPersonnelDiningRegisterModel model)
        {
            await _externalPersonnelDiningRegisterService.InsertAsync(model);
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
            await _externalPersonnelDiningRegisterService.CancelAsync(id);
        }
    }
}
