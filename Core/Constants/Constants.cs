namespace MasterAuth.Core.Constants
{
    public class Constants
    {
        #region General 

        #endregion

        #region Emailing

        public class EmailTemplates
        {
            public const string RegistrationMailPath = "MasterAuth.Core.EmailTemplates.RegistrationMail.cshtml";
            public const string ChangePasswordMailPath = "MasterAuth.Core.EmailTemplates.PasswordChangeMail.cshtml";
        }

        #endregion

        #region Cookies

        public class Cookies
        {
            public const string RefreshTokenKey = "refresh_token";
        }

        #endregion

        #region Claims

        public class Claims
        {
            public const string UserId = "UserId";
            public const string GroupId = "GroupId";
            public const string FacultyId = "FacultyId";
            public const string OrganizationId = "OrganizationId";

        }

        #endregion

        #region Rules
        public class Rules
        {
            public const string Create = "Create";
            public const string Update = "Update";
            public const string Delete = "Delete";
        }

        #endregion

        #region Messages
        public class Messages
        {
            public const string ExistingId = "This Id already exists";
            public const string NonExistingId = "This Id doesn't exists";
            public const string ExistingEmail = "This email already exists";
            public const string ExistingEntity = "This entity already exists";
            public const string InvalidInput = "Invalid input";
        }

        #endregion
    }
}
