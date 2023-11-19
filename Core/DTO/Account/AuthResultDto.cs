using MasterAuth.Core.Enums;

namespace MasterAuth.Core.DTO.Account
{
    public class AuthResultDto
    {
        public string JwtToken { get; set; } = String.Empty;
        public string RefreshToken { get; set; } = String.Empty;
        public DateTime RefreshExpiry { get; set; }
        public ActionStatus Status { get; set; }
        public UserDto User { get; set; }

        public static AuthResultDto Fail => new AuthResultDto { Status = ActionStatus.Fail };
        public static AuthResultDto Success => new AuthResultDto { Status = ActionStatus.Success };
    }
}
