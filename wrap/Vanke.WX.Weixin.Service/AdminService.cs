using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EZ.Framework;
using EZ.Framework.EntityFramework;
using EZ.Framework.Integration.WebApi;
using Vanke.WX.Weixin.Common;
using Vanke.WX.Weixin.Data.Entity;
using Vanke.WX.Weixin.Data.Repository.Interface;
using Vanke.WX.Weixin.Service.Interface;
using Vanke.WX.Weixin.Service.Models;

namespace Vanke.WX.Weixin.Service
{
    public class AdminService : Service<IDataContext>, IAdminService
    {
        public AdminService(IDataContext dataContext) : base(dataContext)
        {
        }

        public async Task<IEnumerable<AdminModel>> GetAllAsync()
        {

            var query = from admin in UnitOfWork.Set<Admin>()
                join user in UnitOfWork.Set<User>() on admin.UserID equals user.ID
                where admin.Status == AdminStatus.Active
                select new AdminModel
                {
                    ID = admin.ID,
                    LoginName = user.LoginName,
                    RealName = admin.RealName,
                };

            return await query.ToListAsync();
        }

        public async Task InsertAsync(AdminModel admin)
        {
            await CheckLoginNameExist(admin.LoginName);

            var adminEntity = new Admin
            {
                RealName = admin.RealName,
                Status = AdminStatus.Active,
                CreatedOn = DateTime.Now,
                CreatedBy = (long) AccountManager.Instance.CurrentLoginUser.ID,
                User = new User
                {
                    LoginName = admin.LoginName,
                    Password = Convert.ToBase64String(Encoding.UTF8.GetBytes(admin.Password))
                }
            };

            IoC.Container.GetInstance<IAdminRepository>().Insert(adminEntity);
            await UnitOfWork.SaveChangesAsync();
        }

        private async Task CheckLoginNameExist(string logingName, long userId = 0)
        {
            if (await UnitOfWork.Set<User>().AnyAsync(p=>p.LoginName == logingName && p.ID != userId))
            {
                throw new BusinessException("用户名已经存在");
            }
        }
    }
}
