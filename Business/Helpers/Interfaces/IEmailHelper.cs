
using FluentEmail.Core.Models;
using MasterAuth.Business.Services.Interfaces;
using MasterAuth.Core.DTO.Account;

namespace MasterAuth.Business.Helpers.Interfaces
{
    internal interface IEmailHelper : IService
    {
        Task<SendResponse> SendRegistrationEmailAsync(UserDto user);
        Task<SendResponse> SendConfirmationEmailAsync(UserDto user);
        Task<SendResponse> SendPasswordChangeEmailAsync(UserDto user);
    }
}
