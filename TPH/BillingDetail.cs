using System.ComponentModel.DataAnnotations.Schema;

namespace TPH
{
    //[Table("BillingDetail")] 
    public abstract class BillingDetail
    {
        public int BillingDetailId { get; set; }
        public string Owner { get; set; }
        public string Number { get; set; }
    }
}
