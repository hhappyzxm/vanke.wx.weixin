using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.WebPages.Html;
using EZ.Framework.Integration.WebApi;
using Vanke.WX.Weixin.Common;
using Vanke.WX.Weixin.Data.Entity;
using Vanke.WX.Weixin.Service.Interface;
using Vanke.WX.Weixin.Service.Models;
using Vanke.WX.Weixin.ViewModels;

namespace Vanke.WX.Weixin.Controllers
{
    public class EmployeeDiscountsController : GenericApiController
    {
        private readonly IEmployeeDiscountService _service = IoC.Container.GetInstance<IEmployeeDiscountService>();

        /// <summary>
        /// Get all items
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<EmployeeDiscountModel>> Get()
        {
            var services =  await _service.GetAllAsync();

            foreach (var item in services)
            {
                item.ImagePath = "http://localhost:54843/Upload/" + item.ImagePath;
            }

            return services;
        }

        /// <summary>
        /// Get item by key
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<EmployeeDiscountModel> Get(long id)
        {
            return await _service.GetByKeyAsync(id);
        }

        [HttpGet]
        [Route("api/employeediscounts/search")]
        public async Task<IEnumerable<EmployeeDiscountModel>> Search(string type)
        {
            return
                await
                    _service.GetAllAsync(string.IsNullOrEmpty(type)
                        ? (EmployeeDiscountType?)null
                        : (EmployeeDiscountType)int.Parse(type));
        }

        [HttpGet]
        [Route("api/employeediscounts/gettypes")]
        public List<SelectListItemModel> GetTypes()
        {
            return new List<SelectListItemModel>
            {
                new SelectListItemModel
                {
                    Text = "衣",
                    Value = (int)EmployeeDiscountType.Clothes
                },
                new SelectListItemModel
                {
                    Text = "食",
                    Value = (int)EmployeeDiscountType.Food
                }
                ,
                new SelectListItemModel
                {
                    Text = "住",
                    Value = (int)EmployeeDiscountType.Live
                },
                new SelectListItemModel
                {
                    Text = "行",
                    Value = (int)EmployeeDiscountType.Walk
                },
                new SelectListItemModel
                {
                    Text = "健",
                    Value = (int)EmployeeDiscountType.Health
                }
            };
        }

        /// <summary>
        /// Insert/Update item
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task Save(EmployeeDiscountViewModel model)
        {
            if (model.ID.Equals(0))
            {
                await _service.InsertAsync(model);
                File.Move(HttpRuntime.AppDomainAppPath + @"Temp\" + model.ImagePath, HttpRuntime.AppDomainAppPath + @"Upload\" + model.ImagePath);
            }
            else
            {
                await _service.UpdateAsync(model.ID, model);

                if (!string.IsNullOrEmpty(model.OriginalImagePath))
                {
                    if (File.Exists(HttpRuntime.AppDomainAppPath + @"Upload\" + model.OriginalImagePath))
                    {
                        File.Delete(HttpRuntime.AppDomainAppPath + @"Upload\" + model.OriginalImagePath);
                    }
                    File.Move(HttpRuntime.AppDomainAppPath + @"Temp\" + model.ImagePath, HttpRuntime.AppDomainAppPath + @"Upload\" + model.ImagePath);
                }
            }
        }

        /// <summary>
        /// Delete item
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task Delete(long id)
        {
            await _service.RemoveAsync(id);
        }
    }
}
