using Autofac;
using MasterAuth.Database.Database;
using MasterAuth.Database.Repository.Interfaces;
using MasterAuth.Database.Repository.Interfaces.Base;

namespace MasterAuth.Database.Repository.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Properties

        private readonly Lazy<SqlDatabase> _context;
        private readonly ILifetimeScope _lifetimeScope;

        #endregion

        #region Constructor

        public UnitOfWork(Lazy<SqlDatabase> context, ILifetimeScope lifetimeScope)
        {
            _context = context;
            _lifetimeScope = lifetimeScope;
        }

        #endregion

        #region Interface Members

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                await _context.Value.SaveChangesAsync(cancellationToken);
            }
            catch (Exception)
            {
                throw;
            }
        }

        ISqlRepository<T> IUnitOfWork.Repository<T>()
        {
            return _lifetimeScope.Resolve<ISqlRepository<T>>(new NamedParameter("context", _context.Value));
        }

        public void Dispose()
        {
            if (_context.IsValueCreated)
            {
                _context.Value.Dispose();
            }
        }

        #endregion
    }
}
