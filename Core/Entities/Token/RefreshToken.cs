using MasterAuth.Core.Entities.Account;
using MasterAuth.Core.Entities.Base;

namespace MasterAuth.Core.Entities.Token
{
    public class RefreshToken : EntityBase
    {
        public string Token { get; set; } = string.Empty;
        public DateTime ExpiryTime { get; set; }
        public Guid UserId { get; set; }
        public virtual User User { get; set; }

        public void Update(string token, DateTime expiryTime)
        {
            Token = token;
            ExpiryTime = expiryTime;
        }
    }
}
