using System.Web.Http;
using EZ.Framework.Integration.WebApi;
using Owin;

namespace Vanke.WX.Weixin
{
    public partial class Startup
    {
        public void ConfigureWebApi(IAppBuilder app)
        {

            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new {id = RouteParameter.Optional}
                );
            config.Filters.Add(new WebApiExceptionFilter());

            app.UseWebApi(config);
        }
    }
}
