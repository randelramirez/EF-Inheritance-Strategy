using System.Data.Entity;

namespace TPT
{
    public class DataContext : DbContext
   {
      public DbSet<BillingDetail> BillingDetails { get; set; }

   }
}
