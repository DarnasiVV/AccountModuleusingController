using Accounting_Module_Example.Domain_Class;

namespace Accounting_Module_Example.Repository
{
    public interface IAccountRepository
    {
        Task CreateAccount(AccountViewModal accountvm);
        Task UpdateAccount(AccountViewModal accountvm);
    }
}
