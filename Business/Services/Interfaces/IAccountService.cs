using MasterAuth.Core.DTO.Account;

namespace MasterAuth.Business.Services.Interfaces
{
    public interface IAccountService : IService, IDisposable
    {
        //Task<AuthResultDto> LoginAsync(AuthDto auth, CancellationToken cancellationToken = default);
        Task RegisterAsync(RegisterDto registerModel, CancellationToken cancellationToken = default);
        //Task ConfirmRegistrationAsync(string registrationToken, CancellationToken cancellationToken = default);
        //Task<AuthResultDto> UpdateRefreshTokenAsync(TokenUpdateDto tokenPair, CancellationToken cancellationToken = default);
    }
}
