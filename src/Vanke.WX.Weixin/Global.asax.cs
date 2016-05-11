using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using EZ.Framework.EntityFramework;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using Vanke.WX.Weixin.Common;
using Vanke.WX.Weixin.Data;
using Vanke.WX.Weixin.Service;
using Vanke.WX.Weixin.Service.Interface;

namespace Vanke.WX.Weixin
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            //FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            //RouteConfig.RegisterRoutes(RouteTable.Routes);

            #region IoC 

            var container = IoC.Container;
            container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();

            // Register your types, for instance using the scoped lifestyle:
            container.Register<IDataContext, DataContext>(Lifestyle.Scoped);

            container.Register<IAdminService, AdminService>(Lifestyle.Transient);
            container.Register<IStaffService, StaffService>(Lifestyle.Transient);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);

            #endregion
        }
    }
}