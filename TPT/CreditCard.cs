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
   [Table("CreditCards")]
   public class CreditCard : BillingDetail
   {
      public int CardType { get; set; }
      public string ExpiryMonth { get; set; }
      public string ExpiryYear { get; set; }
   }
}
