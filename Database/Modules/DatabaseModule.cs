using Autofac;
using MasterAuth.Database.Database;
using Microsoft.EntityFrameworkCore;

namespace Database.Modules
{
    public class DatabaseModule : Module
    {
        public DatabaseModule() { }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SqlDatabase>()
                .As<DbContext>()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
