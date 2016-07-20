using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPT
{
   // moved to fluent api
   //[Table("BankAccounts")]
  public class BankAccount : BillingDetail
   {
      public string BankName { get; set; }
      public string Swift { get; set; }
   }
}
