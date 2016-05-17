using System.Linq;
using System.Web.Http;
using EZ.Framework.Integration.WebApi;
using Owin;
using Microsoft.Owin.Cors;
using SimpleInjector.Integration.WebApi;
using Vanke.WX.Weixin.Common;

namespace Vanke.WX.Weixin
{
    public partial class Startup
    {
        public void ConfigureWebApi(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new {id = RouteParameter.Optional}
                );

            config.Filters.Add(new WebApiExceptionFilter());
            config.Filters.Add(new AuthorizeAttribute());

            config.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(IoC.Container);

            app.UseCors(CorsOptions.AllowAll);
            app.UseWebApi(config);
        }
    }
}
