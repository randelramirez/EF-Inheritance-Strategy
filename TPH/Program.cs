using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPH
{
   class Program
   {
      // http://weblogs.asp.net/manavi/inheritance-mapping-strategies-with-entity-framework-code-first-ctp5-part-1-table-per-hierarchy-tph

      static void Main( string[] args )
      {
         // both BankAccount and CreditCard inherits from BillingDetail(abstract)

         var bankAccount1 = new BankAccount { BankName = "BPI", Number = "784327625", Owner = "Owner 123", Swift = "AFBCV22SU" };
         var bankAccount2 = new BankAccount { BankName = "BDO", Number = "43226924", Owner = "Owner 1234", Swift = "BFFGT47UI" };
         var creditCard1 = new CreditCard { ExpiryMonth = "April", Owner = "Owner 54321", Number = "0283632846", CardType = 22, ExpiryYear = "2019" };
         var creditCard2 = new CreditCard { ExpiryMonth = "April", Owner = "Owner 54321", Number = "0283632846", CardType = 22, ExpiryYear = "2019" };

         using ( var context = new DataContext() )
         {
            // profile the sql command generated to the database
            context.BillingDetails.Add( bankAccount1 );
            context.BillingDetails.Add( bankAccount2 );
            context.BillingDetails.Add( creditCard1 );
            context.BillingDetails.Add( creditCard2 );
            context.SaveChanges();

            // if we breakpoint here we can check the query
            var queryable = context.BillingDetails;
         }

         Console.ReadKey();
      }
   }
}
