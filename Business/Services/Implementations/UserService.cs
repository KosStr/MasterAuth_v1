using MasterAuth.Business.Services.Base;
using MasterAuth.Database.Repository.Interfaces;

namespace MasterAuth.Business.Services.Implementations
{
    internal class UserService : ServiceBase
    {
        #region Properties

        //private readonly Lazy<ICurrentUser> currentUser;

        #endregion

        #region Constructor

        public UserService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
           
        }

        #endregion

        //#region Interface Members

        //public Task<UserDto> GetAsync(Guid id, CancellationToken cancellationToken = default)
        //{
        //    return UnitOfWork.Repository<User>().GetFirstAsync(i => i.Id == id, i => new UserDto
        //    {
        //        Id = i.Id,
        //        Email = i.Email,
        //        FirstName = i.FirstName,
        //        LastName = i.LastName,
        //        GroupName = i.Group.Name,
        //        Role = i.Role
        //    }, cancellationToken);
        //}
        
        //public async Task<ActionStatus> UpdateAsync(UserDto user, CancellationToken cancellationToken = default)
        //{
        //    var entity = await UnitOfWork.Repository<User>().GetFirstAsync(i => i.Id == user.Id, i => i, cancellationToken);
        //    if (entity == null)
        //    {
        //        return ActionStatus.NoAccess;
        //    }

        //    entity.FirstName = user.FirstName;
        //    entity.LastName = user.LastName;
        //    entity.Phone = user.Phone;

        //    await UnitOfWork.Repository<User>().UpdateAsync(entity, cancellationToken);
        //    await UnitOfWork.SaveChangesAsync(cancellationToken);
        //    return ActionStatus.Success;
        //}

        //public async Task<ActionStatus> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        //{
        //    await UnitOfWork.Repository<User>().DeleteAsync(i => i.Id == id, cancellationToken);
        //    await UnitOfWork.SaveChangesAsync();
        //    return ActionStatus.Success;
        //}

        //#endregion
    }
}
