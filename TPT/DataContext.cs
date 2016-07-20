using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPT
{
   public class DataContext : DbContext
   {
      public DbSet<BillingDetail> BillingDetails { get; set; }

      protected override void OnModelCreating( DbModelBuilder modelBuilder )
      {
         modelBuilder.Entity<BankAccount>().ToTable( "BankAccounts" );
         modelBuilder.Entity<CreditCard>().ToTable( "CreditCards" );
      }
   }
}
