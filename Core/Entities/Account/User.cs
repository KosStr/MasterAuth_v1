using MasterAuth.Core.Entities.Base;
using MasterAuth.Core.Enums;

namespace MasterAuth.Core.Entities.Account
{
    public class User : AuditEntity
    {
        public string FirstName { get; set; } = String.Empty;
        public string LastName { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public string Phone { get; set; } = String.Empty;
        public Role Role { get; set; }
        public string PasswordHash { get; set; } = String.Empty;
        public DateTime ActivatedDate { get; set; }
    }
}
