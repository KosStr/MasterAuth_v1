namespace Business.Helpers.Implementstions
{
    //public class EmailHelper : ServiceBase, IEmailHelper
    //{

    //    #region Properties

    //    private readonly IFluentEmail _fluentEmail;
    //    private readonly EmailConfig _emailConfig;

    //    #endregion

    //    #region Constructor

    //    public EmailHelper(IUnitOfWork unitOfWork, IFluentEmail fluentEmail, EmailConfig emailConfig) : base(unitOfWork)
    //    {
    //        _fluentEmail = fluentEmail;
    //        _emailConfig = emailConfig;
    //    }

    //    #endregion

    //    #region Interface Members

    //    public async Task<SendResponse> SendRegistrationEmailAsync(UserDTO user)
    //    {
    //        var confirmationString = Guid.NewGuid().ToString();
    //        var letter = new EmailDTO(user.FirstName, user.LastName, confirmationString);

    //        var userEntity = await UnitOfWork.Repository<User>().GetFirstAsync(i => i.Email == user.Email, i => i);
    //        userEntity.SetEmailToken(confirmationString, 24);

    //        await UnitOfWork.Repository<User>().UpdateAsync(userEntity);
    //        await UnitOfWork.SaveChangesAsync();

    //        return await _fluentEmail
    //            .To(user.Email)
    //            .Subject("Registration confirm")
    //            .SendAsync();
    //    }

    //    public async Task<SendResponse> SendPasswordChangeEmailAsync(UserDto user)
    //    {
    //        var userEntity = await UnitOfWork.Repository<User>().GetFirstAsync(i => i.Email == user.Email, i => i);
    //        if (userEntity.ActivatedDate == null)
    //        {
    //            // add Exception;
    //            return null;
    //        }
    //        else
    //        {
    //            var forgotLetter = new ConfirmationMail(user.FirstName, user.LastName, userEntity.EmailToken);
    //            userEntity.SetEmailToken(userEntity.EmailToken, 1);
    //            return await _fluentEmail
    //            .To(user.Email)
    //            .Subject("Passord change")
    //            .UsingTemplateFromEmbedded(Constants.EmailTemplates.ChangePasswordMailPath, forgotLetter, Assembly.GetEntryAssembly())
    //            .SendAsync();
    //        }
    //    }

    //    #endregion
    //}
}

