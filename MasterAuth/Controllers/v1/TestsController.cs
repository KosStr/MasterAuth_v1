using FluentEmail.Core;
using MasterAuth.Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Schedule.Attributes;

namespace MasterAuth.Controllers.v1
{
    [ApiController]
    [RouteV1("[controller]")]
    public class TestsController : ControllerBase
    {
        #region Properties

        private readonly IAccountService _accountService;
        private readonly IFluentEmail _fluentEmail;

        #endregion

        #region Constructor

        public TestsController(IAccountService accountService, IFluentEmail fluentEmail)
        {
            _accountService = accountService;
            _fluentEmail = fluentEmail;
        }

        #endregion

        #region Actions

        [HttpPost]
        public async Task<IActionResult> LoginAsync()
        {
            var confirmationString = Guid.NewGuid().ToString();

            var a = await _fluentEmail
               .To("gradkep@gmail.com")
               .Subject("Registration confirm")
               .Body(confirmationString)
               .SendAsync();

            return Ok(a);
        }

        #endregion
    }
}
