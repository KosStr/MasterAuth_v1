using Autofac;
using MasterAuth.Core.Entities.Base;
using MasterAuth.Database.Database;
using MasterAuth.Database.Repository.Implementations;
using MasterAuth.Database.Repository.Implementations.Base;
using Microsoft.EntityFrameworkCore;

namespace Database.Modules
{
    public class DatabaseModule : Module
    {
        public DatabaseModule() { }

        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<SqlDatabase>()
                .As<DbContext>()
                .InstancePerLifetimeScope();

            builder.
                RegisterType<UnitOfWork>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder
                .RegisterTypes(GetRepositories())
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }

        private Type[] GetRepositories()
        {
            var entities = typeof(ISqlEntity).Assembly.GetTypes().Where(i => i.IsClass && !i.IsAbstract && i.IsAssignableTo<ISqlEntity>());
            return entities.Select(i => typeof(SqlRepository<>).MakeGenericType(i)).ToArray();
        }
    }
}
