using Autofac;
using Database.Modules;
using MasterAuth.Business.Services.Interfaces;

namespace MasterAuth.Business.Modules
{
    public class BusinessModule : Module
    {
        public BusinessModule() { }

        protected override void Load(ContainerBuilder builder)
        {
            var services = GetServices();
            builder.RegisterTypes(services)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
            //builder
            //    .RegisterType<CurrentUserHelper>()
            //    .AsImplementedInterfaces()
            //    .InstancePerLifetimeScope();

            builder.RegisterModule(new DatabaseModule());
        }

        private Type[] GetServices()
        {
            return ThisAssembly.GetTypes().Where(i => !i.IsAbstract && i.IsClass && i.IsAssignableTo<IService>()).ToArray();
        }
    }
}
