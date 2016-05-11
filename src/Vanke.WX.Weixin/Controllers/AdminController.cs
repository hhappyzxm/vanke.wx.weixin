using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using EZ.Framework.EntityFramework;
using Vanke.WX.Weixin.Common;
using Vanke.WX.Weixin.Data.Entity;
using Vanke.WX.Weixin.Service;
using Vanke.WX.Weixin.Service.Interface;
using Vanke.WX.Weixin.ViewModels;

namespace Vanke.WX.Weixin.Controllers
{
    
    public class AdminController : BaseApiController
    {
        private readonly IAdminService _adminService = IoC.Container.GetInstance<IAdminService>();

        public IEnumerable<string> Get()
        {
            var s = IoC.Container.GetInstance<IAdminService>();
            return new string[] { "11", "22" };
        }

        //public AdminViewModel Get(int id)
        //{
        //    return _adminService.
        //}

        public async Task Post(Admin entity)
        {
            await _adminService.InsertAsync(entity);
        }

        public async Task Put(Admin entity)
        {
            await _adminService.UpdateAsync(entity);
        }

        // DELETE api/values/5
        //public async Task Delete(int id)
        //{
            
        //}
    }
}
