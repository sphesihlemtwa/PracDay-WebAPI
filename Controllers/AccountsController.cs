using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PracDay_WebAPI.Services;
using PracDay_WebAPI.Models;

namespace PracDay_WebAPI.Controllers
{
    [Route("[controller]")]
    public class AccountsController : Controller
    {
        private readonly ILogger<AccountsController> _logger;
        AccountService _accountService;
        public AccountsController(ILogger<AccountsController> logger, AccountService accountService)
        {
            _logger = logger;
            this._accountService=accountService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }

        [HttpGet("Accounts")]
        public ActionResult Get(Account account)
        {
            
            return Ok(this._accountService.GetAccounts());
        }

        [HttpPost("register")]
        public ActionResult Register([FromBody]Account account)
        {

            this._accountService.AddAccount(account);
            return NoContent();
        }

    }
}