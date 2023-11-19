namespace MasterAuth.Core.DTO.Token
{
    internal class TokenUpdateDto
    {
        public string AccessToken { get; set; } = String.Empty;
        public string RefreshToken { get; set; } = String.Empty;
    }
}
