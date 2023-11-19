using MasterAuth.Database.Repository.Interfaces;

namespace MasterAuth.Business.Services.Base
{
    public abstract class ServiceBase : IDisposable
    {
        #region Properties

        protected IUnitOfWork UnitOfWork { get; }

        #endregion

        #region Constructor

        protected ServiceBase(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        #endregion

        #region Interface Members

        public void Dispose()
        {
            UnitOfWork.Dispose();
        }

        #endregion
    }
}
