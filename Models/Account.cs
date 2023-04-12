namespace AccountsWebApi.Models
{
    public class Account
    {
    
        public int AccountId { get; set; }
        public string Number { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public virtual ICollection<Transaction>? Transactions { get; set; }
    }
}

