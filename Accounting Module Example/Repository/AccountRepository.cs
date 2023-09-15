using Accounting_Module_Example.Domain_Class;
using Marten;
using System.Security.Principal;

namespace Accounting_Module_Example.Repository
{
   
    public class AccountRepository : IAccountRepository 
    {
        private readonly IAccountRepository _accountInterface;
        private readonly IDocumentSession _documentSession;
        private readonly IQuerySession _querySession;


        public AccountRepository(IAccountRepository accountInterface,IDocumentSession documentSession,IQuerySession querySession)
        {
            _accountInterface = accountInterface;
            _documentSession = documentSession;
            _querySession = querySession;
        }
        public async Task CreateAccount(AccountViewModal accountvm)
        {
            var Id = Guid.NewGuid();
            _documentSession.Events.StartStream<AccountViewModal>(Id, new AccountCreated(Id, accountvm.AccountHolderName, accountvm.Address));
            _documentSession.SaveChanges();
        }
        public async Task UpdateAccount(AccountViewModal accountvm)
        {
            _documentSession.Events.Append(accountvm.Id, new AccountUpdated(accountvm.Id, accountvm.AccountHolderIdentityProof));
            _documentSession.SaveChanges();
        }
    }
}
