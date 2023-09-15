using Accounting_Module_Example.Domain_Class;
using Accounting_Module_Example.Projections;
using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;
using Wolverine;

namespace Accounting_Module_Example.Controllers
{
    [Route("Controller")]
    public class AccountController : Controller
    {
        private readonly Wolverine.IMessageBus _messageBus;
        public AccountController(IMessageBus messageBus)
        {
            _messageBus = messageBus;
        }
        [Route("CreateAccount")]
        [HttpPost]
        public async Task<ActionResult> CreateAccount(AccountViewModal accountvm)
        {
            await _messageBus.SendAsync(accountvm);
            return Ok("Account Created Successfully");
        }
        [Route("GetAccount")]
        [HttpGet]
        public async Task<ActionResult> GetAccount(Guid id)
        {
            var details = await _messageBus.InvokeAsync<AccountViewModal>(id);
            return Ok(details);
        }

        [Route("UpdateAccount")]
        [HttpPut]
        public async Task<ActionResult> UpdateAccount(Guid Id, int AccountHolderIdentityProof)
        {
            await _messageBus.SendAsync(Id);
            return Ok("Updated Successfully");
        }
    }
}
