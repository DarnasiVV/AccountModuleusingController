namespace Accounting_Module_Example.Domain_Class
{
    public record AccountCreated (Guid Id, string AccountHolderName, string  Address );
    public record AccountUpdated (Guid Id,int AccountHolderIdentityProof);

    public class AccountViewModal 
    {
        public Guid Id { get; set; }
        public string AccountHolderName { get; set; }
        public string Address { get; set; }
        public int PhoneNumber { get; set; }
        public int AccountHolderIdentityProof { get; set; }
    }
    //public class AccountId : AccountViewModal
    //{
    //    public Guid Id { get; set; }
    //}
}
