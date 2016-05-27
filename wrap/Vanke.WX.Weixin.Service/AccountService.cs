using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EZ.Framework;
using EZ.Framework.Integration.WebApi;
using EZ.Framework.NoRepository.EntityFramework;
using Vanke.WX.Weixin.Common;
using Vanke.WX.Weixin.Data.Entity;
using Vanke.WX.Weixin.Service.Interface;

namespace Vanke.WX.Weixin.Service
{
    public class AccountService : Service<IDataContext>, IAccountService
    {
        public AccountService(IDataContext dataContext) : base(dataContext)
        {
        }

        public IdentityUser Login(string loginName, string password)
        {
            password = Convert.ToBase64String(Encoding.UTF8.GetBytes(password));

            var staff =
                UnitOfWork.Set<Staff>()
                    .SingleOrDefault(p => p.LoginName.Equals(loginName) && p.Password.Equals(password));

            if (staff == null)
            {
                return null;
            }
            else
            {
                var roles = staff.StaffRoles.ToList();

                var identityUser = new IdentityUser
                {
                    Id = staff.ID,
                    Roles = new List<string>()
                };

                roles.ForEach(p => identityUser.Roles.Add(p.Role.ToString()));

                return identityUser;
            }
        }

        public CurrentLogin GetCurrentLogin(object userId)
        {
            var staff = UnitOfWork.Set<Staff>().Find(userId);
            if (staff != null)
            {
                var currentLogin = new CurrentLogin
                {
                    ID = staff.ID,
                    UserName = staff.RealName,
                    Roles = (from r in UnitOfWork.Set<StaffRole>()
                        where r.StaffID == staff.ID
                        select r.Role).ToList()
                };


                return currentLogin;
            }

            throw new Exception("Can not found user from staff by id " + userId);
        }
    }
}
