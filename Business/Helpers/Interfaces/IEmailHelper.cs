using MasterAuth.Business.Services.Interfaces;

namespace Business.Helpers.Interfaces
{
    public interface IEmailHelper : IService
    {
        Task SendRegistrationEmailAsync();
        Task SendPasswordChangeEmailAsync();
    }
}
