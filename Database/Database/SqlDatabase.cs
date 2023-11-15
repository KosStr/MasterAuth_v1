using MasterAuth.Core.Entities.Account;
using Microsoft.EntityFrameworkCore;

namespace MasterAuth.Database.Database
{
    public class SqlDatabase : DbContext
    {
        #region Constructor

        public SqlDatabase(DbContextOptions<SqlDatabase> options) : base(options)
        {

        }

        #endregion

        #region Overrides

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            //optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var type = GetType();
            modelBuilder.ApplyConfigurationsFromAssembly(type.Assembly);
            base.OnModelCreating(modelBuilder);
        }

        #endregion

        #region DbSets

        public DbSet<User> Users { get; set; }
       
        
        #endregion
    }
}
