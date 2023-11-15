using MasterAuth.Database.Database;
using Microsoft.EntityFrameworkCore;

namespace MasterAuth.Extensions
{
    public static class DbExtension
    {
        public static void AddDatabaseContext(this WebApplicationBuilder builder) =>
            builder.Services.AddDbContext<SqlDatabase>(options =>
            {
                options.UseMySql(builder.Configuration.GetConnectionString("MySqlDefault"), ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("MySqlDefault")));
            });
    }
}
