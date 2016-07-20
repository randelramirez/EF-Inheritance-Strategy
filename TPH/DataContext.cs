using System.Data.Entity;

namespace TPH
{
    public class DataContext : DbContext
   {
      public DbSet<BillingDetail> BillingDetails { get; set; }
   }
}
