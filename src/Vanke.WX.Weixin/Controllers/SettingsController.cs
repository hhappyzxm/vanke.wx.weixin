using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using EZ.Framework.Integration.WebApi;
using Vanke.WX.Weixin.Common;
using Vanke.WX.Weixin.Data.Entity;
using Vanke.WX.Weixin.Service.Interface;
using Vanke.WX.Weixin.Service.Models;

namespace Vanke.WX.Weixin.Controllers
{
    public class SettingsController : GenericApiController
    {
        private readonly ISettingService _service = IoC.Container.GetInstance<ISettingService>();

        /// <summary>
        /// Get all items
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<SettingModel> Get()
        {
            var results = await _service.GetAllAsync();

            var settingModels = results as SettingModel[] ?? results.ToArray();
            if (settingModels.Any())
            {
                return settingModels[0];
            }
            else
            {
                return null;
            }
        }
        
        /// <summary>
        /// Insert/Update item
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task Save(SettingModel model)
        {
            await _service.UpdateAsync(model.ID, model);
        }
    }
}
