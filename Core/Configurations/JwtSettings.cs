namespace MasterAuth.Core.Configurations
{
    public class JwtSettings
    {
        public string Issuer { get; set; } = String.Empty;
        public string Audience { get; set; } = String.Empty;
        public string Key { get; set; } = String.Empty;
        public int Lifetime { get; set; }
        public int RefreshLifetime { get; set; }
    }
}
