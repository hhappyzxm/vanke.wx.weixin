using System;
using System.Threading.Tasks;
using EZ.Framework.EntityFramework;
using Vanke.WX.Weixin.Common;
using Vanke.WX.Weixin.Data.Entity;
using Vanke.WX.Weixin.Data.Repository;
using Vanke.WX.Weixin.Service.Interface;

namespace Vanke.WX.Weixin.Service
{
    public class AdminService : EZ.Framework.Core.Service, IAdminService
    {
        public AdminService(IDataContext dataContext) : base(dataContext)
        {
        }

        public Task Insert()
        {
            throw new NotImplementedException();
        }

        //public async Task Insert(Admin entity)
        //{
        //    var a = IoC.Container.GetInstance<AdminRepository>();
        //    a.Insert(entity);


        //}
    }
}
