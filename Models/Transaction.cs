using System.ComponentModel.DataAnnotations.Schema;

namespace AccountsWebApi.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public int AccountId { get; set; }
        [ForeignKey("AccountId")]
        public virtual Account Account { get; set; }
        public DateTime Date { get; set; }

        public bool TransactionType { get; set; }

        public decimal Amount { get; set; }

        public bool IsActive { get; set; }
    }
}
