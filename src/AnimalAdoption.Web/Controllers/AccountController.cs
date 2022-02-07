using System.Threading.Tasks;
using AnimalAdoption.Web.Controllers.Base;
using AnimalAdoption.Web.Services.Account;
using Microsoft.AspNetCore.Mvc;

namespace AnimalAdoption.Web.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        // [HttpGet("accounts")]
        // public async Task<IActionResult> GetAccounts()
        // {
        //     var accounts = await _accountService.GetAccounts();
        //     return Ok(accounts);
        // }

    }
}
