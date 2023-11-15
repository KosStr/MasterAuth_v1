using Autofac;
using Database.Modules;
using MasterAuth.Business.Services.Base;

namespace MasterAuth.Business.Modules
{
    public class BusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var services = GetServices();
            builder
                .RegisterTypes(services)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterModule(new DatabaseModule());
            base.Load(builder);
        }

        private Type[] GetServices()
        {
            return ThisAssembly.GetTypes().Where(i => !i.IsAbstract && i.IsClass && i.IsAssignableTo<ServiceBase>()).ToArray();
        }
    }
}
