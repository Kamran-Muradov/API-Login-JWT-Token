using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Account;
using Service.Services.Interfaces;

namespace App.Controllers.UI
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        public async Task<IActionResult> SignUp([FromBody] RegisterDto request)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);

            var response = await _accountService.SignUpAsync(request);

            if (!response.Success) return BadRequest(response);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> SignIn([FromBody] LoginDto request)
        {
            return Ok(await _accountService.SignInAsync(request));
        }
    }
}
