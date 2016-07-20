using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPH
{
   public class DataContext : DbContext
   {
      public DbSet<BillingDetail> BillingDetails { get; set; }
   }
}
