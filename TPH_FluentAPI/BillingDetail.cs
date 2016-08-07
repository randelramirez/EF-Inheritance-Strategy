using System.ComponentModel.DataAnnotations.Schema;

namespace TPH_FluentAPI
{
    public abstract class BillingDetail
    {
        public int Id { get; set; }
        public string Owner { get; set; }
        public string Number { get; set; }
    }
}
