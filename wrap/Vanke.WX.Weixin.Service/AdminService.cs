using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EZ.Framework;
using EZ.Framework.EntityFramework;
using Vanke.WX.Weixin.Common;
using Vanke.WX.Weixin.Data.Entity;
using Vanke.WX.Weixin.Data.Repository.Interface;
using Vanke.WX.Weixin.Service.Interface;

namespace Vanke.WX.Weixin.Service
{
    public class AdminService : CRUDService<IDataContext, IAdminRepository, Admin>, IAdminService
    {
        public AdminService(IDataContext dataContext, IAdminRepository repository) : base(dataContext, repository)
        {
        }

        protected override async Task BeforeInsertAsync(Admin entity)
        {
            if (await Repository.AnyAsync(p => p.LoginName.Equals(entity.LoginName)))
            {
                throw new BusinessException("用户名已经存在");
            }

            entity.Password = Convert.ToBase64String(Encoding.UTF8.GetBytes(entity.Password));
            entity.Status = AdminStatus.Active;
            entity.CreatedOn = DateTime.Now;
        }

        public async Task<Admin> LoginAsync(string loginName, string password)
        {
            password = Convert.ToBase64String(Encoding.UTF8.GetBytes(password));

            return
                await
                    Repository.SingleOrDefaultAsync(
                        p =>
                            p.LoginName.Equals(loginName) && 
                            p.Password.Equals(password) &&
                            p.Status == AdminStatus.Active);
        }

        public override async Task RemoveAsync(Admin entity)
        {
            if (entity.LoginName.Equals("admin", StringComparison.Ordinal))
            {
                throw new BusinessException("该账号是默认管理员账号，不能被删除");
            }

            await base.RemoveAsync(entity);
        }

        public async Task<IEnumerable<Admin>> GetAllActiveAdmins()
        {
            return await Repository.ToListAsync(p => p.Status == AdminStatus.Active);
        }
    }
}
