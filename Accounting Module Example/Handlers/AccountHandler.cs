using Accounting_Module_Example.Domain_Class;
using Accounting_Module_Example.Repository;
using System.Security.Principal;

namespace Accounting_Module_Example.Handlers
{
    public class AccounttHandler
    {
        private IAccountRepository _accountRepository;

        public  AccounttHandler(IAccountRepository accountRepository )
        {
            _accountRepository = accountRepository;
        }
        public void Handle(AccountViewModal accountvm)
        {
            if (accountvm.Id != Guid.Empty)
            {
                _accountRepository.UpdateAccount(accountvm);
            }
            else
            {
                _accountRepository.CreateAccount(accountvm);
            }
        }
    }
}
