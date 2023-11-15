using MasterAuth.Core.Enums;

namespace Core.DTOs.Account
{
    public class UserDTO
    {
        public string FirstName { get; set; } = String.Empty;
        public string LastName { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public string Phone { get; set; } = String.Empty;
        public Role Role { get; set; }
    }
}
