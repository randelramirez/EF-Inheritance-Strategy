using System.Data.Entity;

namespace TPT_FluentAPI
{
    public class DataContext : DbContext
    {
        public DbSet<BillingDetail> BillingDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BankAccount>().ToTable("BankAccounts");
            modelBuilder.Entity<CreditCard>().ToTable("CreditCards");
        }

    }
}
