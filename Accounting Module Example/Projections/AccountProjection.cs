using Accounting_Module_Example.Domain_Class;
using Marten.Events.Aggregation;

namespace Accounting_Module_Example.Projections
{
    public class AccountReview
    {
        public Guid Id { get; set; }
        public string AccountHolderName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int PhoneNumber { get; set; }
        public int AccountHolderIdentityProof { get; set; }
    }
    public class AccountProjection : SingleStreamAggregation<AccountReview>
    {
        public AccountReview Create(AccountViewModal accountvm)
        {
            var accountreview = new AccountReview();
            accountreview.Id = accountvm.Id;
            accountreview.AccountHolderName = accountvm.AccountHolderName;
            accountreview.Address = accountvm.Address;
            accountreview.PhoneNumber = accountvm.PhoneNumber; 
            accountreview.AccountHolderIdentityProof = accountvm.AccountHolderIdentityProof;

            return accountreview;
        }
    }
    
}
