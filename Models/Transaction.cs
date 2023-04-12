using System.ComponentModel.DataAnnotations.Schema;
using AccountsWebApi.Models;

namespace AccountsWebApi.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public int AccountId { get; set; }
        [ForeignKey("AccountId")]
        public virtual Account? Account { get; set; }
        public DateTime Date { get; set; }

        public TransactionType TransactionType { get; set; }

        public decimal Amount { get; set; }

        public bool IsActive { get; set; }
    }
}
