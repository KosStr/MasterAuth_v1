using MasterAuth.Core.Entities.Base;
using MasterAuth.Database.Repository.Interfaces.Base;

namespace MasterAuth.Database.Repository.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
        ISqlRepository<T> Repository<T>() where T : class, ISqlEntity;
    }
}
