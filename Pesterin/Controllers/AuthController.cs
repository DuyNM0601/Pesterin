using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pesterin.Responses;
using Pesterin.Services.Impls;
using Pesterin.Services.Interface;
using Pesterin.Services.Models.Accounts;
using Pesterin.Services.Models.Arts;

namespace Pesterin.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AuthController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromQuery] string email, [FromQuery] string password)
        {
            return Ok(new ResponseResult<string>
            {
                IsSuccess = true,
                Error = null,
                Value = await _accountService.GetAccount(email, password)
            });
        }
    }
}
