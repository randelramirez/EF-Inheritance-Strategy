using System.Data.Entity;

namespace TPH_FluentAPI
{
    public class DataContext : DbContext
    {
        public DbSet<BillingDetail> BillingDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BillingDetail>()
                 .HasKey(b => b.Id);

            // to override disciminator property, using int as data type for the discriminator(the column name is BillingType)
            modelBuilder.Entity<BillingDetail>()
                .Map<BankAccount>(m => m.Requires("BillingType").HasValue(1))
                .Map<CreditCard>(m => m.Requires("BillingType").HasValue(2));

            // to override disciminator property, using string as data type for the discriminator(the column name is BillingType)
            //modelBuilder.Entity<BillingDetail>()
            //    .Map<BankAccount>(m => m.Requires("BillingType").HasValue("BA"))
            //    .Map<CreditCard>(m => m.Requires("BillingType").HasValue("CC"));

        }
    }
}
