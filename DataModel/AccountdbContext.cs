using AccountsWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AccountsWebApi.DataModel
{
    public class AccountdbContext : DbContext
    {
        public AccountdbContext(DbContextOptions<AccountdbContext> options) : base(options)
        {


        }
        public DbSet<Account> Accounts { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

       
    }
}
