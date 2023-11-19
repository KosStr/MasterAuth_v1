using MasterAuth.Core.Entities.Token;
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
        public string EmailToken { get; set; } = String.Empty;
        public DateTime EmailTokenLifetime { get; set; }
        public virtual RefreshToken Token { get; set; }

        public void SetEmailToken(string emailToken, int hoursLifetime)
        {
            EmailToken = emailToken;
            EmailTokenLifetime = DateTime.Now.AddHours(hoursLifetime);
        }
    }
}
