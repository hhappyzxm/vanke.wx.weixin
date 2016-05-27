using System.Linq;
using EZ.Framework.NoRepository.EntityFramework;
using Owin;
using SimpleInjector;
using SimpleInjector.Extensions.ExecutionContextScoping;
using Vanke.WX.Weixin.Common;
using Vanke.WX.Weixin.Data;
using Vanke.WX.Weixin.Service;

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

            var serviceAssembly = typeof(StaffService).Assembly;
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

            container.Verify();
        }
    }
}
