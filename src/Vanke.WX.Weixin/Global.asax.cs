using System;

namespace Vanke.WX.Weixin
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            //GlobalConfiguration.Configure(WebApiConfig.Register);
            //FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            //RouteConfig.RegisterRoutes(RouteTable.Routes);

            //#region IoC 

            //var container = IoC.Container;
            //container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();

            //// Register your types, for instance using the scoped lifestyle:
            //container.Register<IDataContext, DataContext>(Lifestyle.Scoped);

            //container.Register<IAdminService, AdminService>(Lifestyle.Transient);
            //container.Register<IStaffService, StaffService>(Lifestyle.Transient);

            //container.Register<IAdminRepository, AdminRepository>(Lifestyle.Transient);
            //container.Register<IStaffRepository, StaffRepository>(Lifestyle.Transient);

            //container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            ////container.Verify();

            //GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);

            //#endregion
        }
    }
}