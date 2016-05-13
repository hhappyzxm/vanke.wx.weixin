using System;
using System.Text;
using System.Threading.Tasks;
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
            entity.Password = Convert.ToBase64String(Encoding.UTF8.GetBytes(entity.Password));
            entity.Status = UserStatus.Active;
            entity.CreatedOn = DateTime.Now;
        }
    }
}
