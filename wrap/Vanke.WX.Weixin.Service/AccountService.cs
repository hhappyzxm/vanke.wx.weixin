using System;
using System.Linq;
using System.Text;
using EZ.Framework;
using EZ.Framework.EntityFramework;
using EZ.Framework.Integration.WebApi;
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

            var user =
                UnitOfWork.Set<User>()
                    .SingleOrDefault(p => p.LoginName.Equals(loginName) && p.Password.Equals(password));

            if (user == null)
            {
                return null;
            }
            else
            {
                return new IdentityUser
                {
                    Id = user.ID
                };
            }
        }

        public CurrentLogin GetCurrentLogin(object userId)
        {
            var admin = UnitOfWork.Set<Admin>().Find(userId);
            if (admin != null)
            {
                return new CurrentLogin
                {
                    ID = userId,
                    AdminID = admin.ID,
                    UserName = admin.RealName,
                    Type = UserType.Admin
                };
            }
            else
            {
                var staff = UnitOfWork.Set<Staff>().Find(userId);
                if (staff != null)
                {
                    return new CurrentLogin
                    {
                        ID = userId,
                        StaffID = staff.ID,
                        UserName = staff.RealName,
                        Type = UserType.Staff
                    };
                }
            }

            throw new Exception("Can not found user from admin/staff by id " + userId);
        }
    }
}
