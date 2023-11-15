namespace Core.DTOs.Email
{
    public class EmailDTO
    {
        public string Email { get; set; } = String.Empty;
        public string Subject { get; set; } = String.Empty;
        public string Body { get; set; } = String.Empty;
        public string VerificationLink { get; set; } = String.Empty;


        public EmailDTO(string email, string lastName, string verificationLink)
        {
            VerificationLink = verificationLink;
        }
    }
}
