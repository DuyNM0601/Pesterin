using Microsoft.AspNetCore.Mvc;
using Pesterin.Core.Entities;
using Pesterin.Responses;
using Pesterin.Services.Interface;
using Pesterin.Services.Models.Accounts;

namespace Pesterin.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAccount()
        {
            return Ok(new ResponseResult<List<AccountViewModel>>
            {
                Error = null,
                IsSuccess = true,
                Value = await _accountService.getAllAccount()
            });
        }
    }
}
