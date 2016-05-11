using System;
using System.Threading.Tasks;
using EZ.Framework.Core;
using EZ.Framework.EntityFramework;
using Vanke.WX.Weixin.Data.Entity;
using Vanke.WX.Weixin.Data.Repository;
using Vanke.WX.Weixin.Data.Repository.Interface;
using Vanke.WX.Weixin.Service.Interface;

namespace Vanke.WX.Weixin.Service
{
    public class AdminService : CRUDService<IDataContext, IAdminRepository, Admin>, IAdminService
    {
        public AdminService(IDataContext dataContext, IAdminRepository repository) : base(dataContext, repository)
        {
        }
    }
}
