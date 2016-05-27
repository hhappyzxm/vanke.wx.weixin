using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using EZ.Framework.Integration.WebApi;
using Vanke.WX.Weixin.Common;
using Vanke.WX.Weixin.Service.Interface;
using Vanke.WX.Weixin.Service.Models;
using Vanke.WX.Weixin.ViewModels;

namespace Vanke.WX.Weixin.Controllers
{
    public class StaffsController : GenericApiController
    {
        private readonly IStaffService _staffService = IoC.Container.GetInstance<IStaffService>();

        /// <summary>
        /// Get all admins
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<StaffModel>> Get()
        {
            return await _staffService.GetAllAsync();
        }

        /// <summary>
        /// Get admin by key
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<StaffEditViewModel> Get(long id)
        {
            var staff =  await _staffService.GetByKeyAsync(id);

            return new StaffEditViewModel
            {
                ID = staff.ID,
                RealName = staff.RealName,
                LoginName = staff.LoginName,
                Password = "******",
                IsAdmin = staff.Roles.Any(p => p == Role.Admin)
            };
        }

        /// <summary>
        /// Insert/Update admin
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task Save(StaffEditViewModel viewModel)
        {
            #region Convert to model from view model

            var model = new StaffModel
            {
                ID = viewModel.ID,
                RealName = viewModel.RealName,
                LoginName = viewModel.LoginName,
                Password = viewModel.Password,
                Roles = new List<Role>
                {
                    Role.Staff
                }
            };

            if (viewModel.IsAdmin)
            {
                model.Roles.Add(Role.Admin);
            }

            #endregion

            if (model.ID.Equals(0))
            {
                await _staffService.InsertAsync(model);
            }
            else
            {
                await _staffService.UpdateAsync(model.ID, model);
            }
        }

        /// <summary>
        /// Delete admin
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task Delete(long id)
        {
            await _staffService.RemoveAsync(id);
        }
    }
}
