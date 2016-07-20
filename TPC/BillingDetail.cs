using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPC
{
   public abstract class BillingDetail
   {
        
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        //[Key]
        public int BillingDetailId { get; set; }

        public string Owner { get; set; }

        public string Number { get; set; }
   }
}
