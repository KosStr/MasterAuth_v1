using MasterAuth.Core.Enums;

namespace MasterAuth.Core.DTO.Account
{
    public class UserDto
    {
        public string FirstName { get; set; } = String.Empty;
        public string LastName { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public string Phone { get; set; } = String.Empty;
        public Role Role { get; set; }
    }
}
