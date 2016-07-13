using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using EZ.Framework;
using EZ.Framework.Integration.WebApi;
using Vanke.WX.Weixin.App_Extension;
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
                Email = staff.Email,
                IsAdmin = staff.Roles.Any(p => p == Role.Admin),
                IsExternalPersonnelDiningManager = staff.Roles.Any(p => p == Role.ExternalPersonnelDiningManager),
                IsItemBorrowManager = staff.Roles.Any(p => p == Role.ItemBorrowManager)
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
                Email = viewModel.Email,
                Roles = new List<Role>
                {
                    Role.Staff
                }
            };

            if (viewModel.IsAdmin)
            {
                model.Roles.Add(Role.Admin);
            }

            if (viewModel.IsExternalPersonnelDiningManager)
            {
                model.Roles.Add(Role.ExternalPersonnelDiningManager);
            }

            if (viewModel.IsItemBorrowManager)
            {
                model.Roles.Add(Role.ItemBorrowManager);
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

        [HttpPost]
        [Route("api/staffs/import")]
        public async Task<object> Import(StaffImportViewModel viewModel)
        {
            var filePath = HttpRuntime.AppDomainAppPath + @"Temp\" + viewModel.FileName;
            var dataSource = ExcelHelper.GetExcelDataTable(filePath, "UserList");
            int index;

            #region 验证Excel格式

            index = 5;
            foreach (DataRow row in dataSource.Rows)
            {
                if (string.IsNullOrEmpty(row[1].ToString()) &&
                    string.IsNullOrEmpty(row[2].ToString()) &&
                    string.IsNullOrEmpty(row[3].ToString()))
                {
                    break;
                }
                
                if (string.IsNullOrEmpty(row[2].ToString()))
                {
                    throw new BusinessException($"第{index}行用户名为空");
                }
                //if (string.IsNullOrEmpty(row[3].ToString()))
                //{
                //    throw new BusinessException($"第{index}行说明为空");
                //}

                index++;
            }

            #endregion
            
            int successed = 0;
            var line = 0;
            foreach (DataRow row in dataSource.Rows)
            {
                if (string.IsNullOrEmpty(row[1].ToString()) &&
                    string.IsNullOrEmpty(row[2].ToString()) &&
                    string.IsNullOrEmpty(row[3].ToString()))
                {
                    break;
                }

                if (line <= 3)
                {
                    line++;
                    continue;
                }

                try
                {
                    var newStaffModel = new StaffEditViewModel
                    {
                        LoginName = row[2].ToString(),
                        RealName = string.IsNullOrEmpty(row[3].ToString()) ? row[2].ToString() : row[3].ToString(),
                        Password = "123456",
                        Email = row[8].ToString()
                    };

                    await this.Save(newStaffModel);
                    successed++;
                }
                catch (BusinessException)
                {
                    // Do nonthing
                }

                line ++;
            }

            File.Delete(filePath);

            return new
            {
                Successed = successed
            };
        }

        [HttpPost]
        [Route("api/staffs/search")]
        public async Task<IEnumerable<StaffModel>> Search(StaffSearchViewModel viewModel)
        {
            return await _staffService.GetAllAsync(viewModel.RealName);
        }
    }
}
