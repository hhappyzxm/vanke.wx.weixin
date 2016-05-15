using System.Linq;
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
            app.Use(async (context, next) =>
            {
                using (IoC.Container.BeginExecutionContextScope())
                {
                    await next();
                }
            });

            var container = IoC.Container;
            container.Options.DefaultScopedLifestyle = new ExecutionContextScopeLifestyle();

            // Register your types, for instance using the scoped lifestyle:
            container.Register<IDataContext>(() => new DataContext("SQLConnection"), Lifestyle.Scoped);

            #region Register Services

            var serviceAssembly = typeof(AdminService).Assembly;
            var services =
                from type in serviceAssembly.GetExportedTypes()
                where type.Namespace == "Vanke.WX.Weixin.Service"
                where type.GetInterfaces().Any()
                select
                    new
                    {
                        Service =
                            type.GetInterfaces().Single(p => p.Namespace == "Vanke.WX.Weixin.Service.Interface"),
                        Implementation = type
                    };

            foreach (var reg in services)
            {
                container.Register(reg.Service, reg.Implementation, Lifestyle.Transient);
            }

            #endregion

            #region Register Repositories

            var repositoryAssembly = typeof(DataContext).Assembly;
            var registrations =
                from type in repositoryAssembly.GetExportedTypes()
                where type.Namespace == "Vanke.WX.Weixin.Data.Repository"
                where type.GetInterfaces().Any()
                select
                    new
                    {
                        Service =
                            type.GetInterfaces().Single(p => p.Namespace == "Vanke.WX.Weixin.Data.Repository.Interface"),
                        Implementation = type
                    };

            foreach (var reg in registrations)
            {
                container.Register(reg.Service, reg.Implementation, Lifestyle.Transient);
            }

            #endregion
            
            container.Verify();
        }
    }
}
