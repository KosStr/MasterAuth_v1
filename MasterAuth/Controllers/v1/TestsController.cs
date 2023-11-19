using FluentEmail.Core;
using MasterAuth.Attributes;
using Microsoft.AspNetCore.Mvc;


namespace MasterAuth.Controllers.v1
{
    [ApiController]
    [RouteV1("[controller]")]
    public class TestsController : ControllerBase
    {
        #region Properties

        //private readonly IAccountService _accountService;
        private readonly IFluentEmail _fluentEmail;

        #endregion

        #region Constructor

        public TestsController(IFluentEmail fluentEmail)
        {
            //_accountService = accountService;
            _fluentEmail = fluentEmail;
        }

        #endregion

        #region Actions

        [HttpPost]
        public async Task<IActionResult> LoginAsync()
        {
            var confirmationString = Guid.NewGuid().ToString();

            var a = await _fluentEmail
               .To("romanyanchuk14@gmail.com")
               .Subject("SMTP Test")
               .Body("Do you smoke chesh?)")
               .SendAsync();

            return Ok(a);
        }

        #endregion
    }
}
