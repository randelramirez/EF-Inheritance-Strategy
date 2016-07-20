using System.Data.Entity;

namespace TPC
{
   public class DataContext : DbContext
   {
      public DbSet<BillingDetail> BillingDetails { get; set; }

      protected override void OnModelCreating( DbModelBuilder modelBuilder )
      {
         modelBuilder.Entity<BankAccount>().Map( m =>
          {
             m.MapInheritedProperties();
             m.ToTable( "BankAccounts" );
          } );

         modelBuilder.Entity<CreditCard>().Map( m =>
          {
             m.MapInheritedProperties();
             m.ToTable( "CreditCards" );
          } );
      }
   }
}
