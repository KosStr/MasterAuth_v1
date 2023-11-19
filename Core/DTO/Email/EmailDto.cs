namespace MasterAuth.Core.DTO.Email
{
    public class EmailDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string VerificationLink { get; set; }


        public EmailDto(string firstName, string lastName, string verificationLink)
        {
            FirstName = firstName;
            LastName = lastName;
            VerificationLink = verificationLink;
        }
    }
}
