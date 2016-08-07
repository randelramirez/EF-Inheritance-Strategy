using System.ComponentModel.DataAnnotations.Schema;

namespace TPT_FluentAPI
{

    [Table("BankAccounts")]
    public class BankAccount : BillingDetail
   {
      public string BankName { get; set; }
      public string Swift { get; set; }
   }
}
