using EZ.Framework.EntityFramework;
using Owin;
using SimpleInjector;
using SimpleInjector.Extensions.ExecutionContextScoping;
using Vanke.WX.Weixin.Common;
using Vanke.WX.Weixin.Data;
using Vanke.WX.Weixin.Data.Repository;
using Vanke.WX.Weixin.Data.Repository.Interface;
using Vanke.WX.Weixin.Service;
using Vanke.WX.Weixin.Service.Interface;

namespace Vanke.WX.Weixin
{
    public partial class Startup
    {
        public void ConfigureSimpleInjector(IAppBuilder app)
        {
            app.Use(async (context, next) => {
                using (IoC.Container.BeginExecutionContextScope())
                {
                    await next();
                }
            });

            var container = IoC.Container;
            container.Options.DefaultScopedLifestyle = new ExecutionContextScopeLifestyle();

            // Register your types, for instance using the scoped lifestyle:
            container.Register<IDataContext, DataContext>(Lifestyle.Scoped);

            container.Register<IAdminService, AdminService>(Lifestyle.Transient);
            container.Register<IStaffService, StaffService>(Lifestyle.Transient);

            container.Register<IAdminRepository, AdminRepository>(Lifestyle.Transient);
            container.Register<IStaffRepository, StaffRepository>(Lifestyle.Transient);

            //container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            //container.Verify();

            //GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}
