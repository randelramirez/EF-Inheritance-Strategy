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

        static void Main(string[] args)
        {
            // both BankAccount and CreditCard inherits from BillingDetail(abstract)

            var bankAccount1 = new BankAccount { BankName = "BPI", Number = "784327625", Owner = "Owner 123", Swift = "AFBCV22SU" };
            var bankAccount2 = new BankAccount { BankName = "BDO", Number = "43226924", Owner = "Owner 1234", Swift = "BFFGT47UI" };
            var creditCard1 = new CreditCard { ExpiryMonth = "April", Owner = "Owner 54321", Number = "0283632846", CardType = 22, ExpiryYear = "2019" };
            var creditCard2 = new CreditCard { ExpiryMonth = "April", Owner = "Owner 54321", Number = "0283632846", CardType = 22, ExpiryYear = "2019" };

            using (var context = new DataContext())
            {
                // profile the sql command generated to the database
                context.BillingDetails.Add(bankAccount1);
                context.BillingDetails.Add(bankAccount2);
                context.BillingDetails.Add(creditCard1);
                context.BillingDetails.Add(creditCard2);
                context.SaveChanges();

                // if we breakpoint here we can check the query
                var queryable = context.BillingDetails;
                queryable.ToList();

                #region generated sql query

                /*
                 
                    exec sp_executesql N'INSERT [dbo].[BillingDetails]([Owner], [Number], [BankName], [Swift], [CardType], [ExpiryMonth], [ExpiryYear], [Discriminator])
VALUES (@0, @1, @2, @3, NULL, NULL, NULL, @4)
SELECT [BillingDetailId]
FROM [dbo].[BillingDetails]
WHERE @@ROWCOUNT > 0 AND [BillingDetailId] = scope_identity()',N'@0 nvarchar(max) ,@1 nvarchar(max) ,@2 nvarchar(max) ,@3 nvarchar(max) ,@4 nvarchar(128)',@0=N'Owner 123',@1=N'784327625',@2=N'BPI',@3=N'AFBCV22SU',@4=N'BankAccount'





exec sp_executesql N'INSERT [dbo].[BillingDetails]([Owner], [Number], [BankName], [Swift], [CardType], [ExpiryMonth], [ExpiryYear], [Discriminator])
VALUES (@0, @1, @2, @3, NULL, NULL, NULL, @4)
SELECT [BillingDetailId]
FROM [dbo].[BillingDetails]
WHERE @@ROWCOUNT > 0 AND [BillingDetailId] = scope_identity()',N'@0 nvarchar(max) ,@1 nvarchar(max) ,@2 nvarchar(max) ,@3 nvarchar(max) ,@4 nvarchar(128)',@0=N'Owner 1234',@1=N'43226924',@2=N'BDO',@3=N'BFFGT47UI',@4=N'BankAccount'




exec sp_executesql N'INSERT [dbo].[BillingDetails]([Owner], [Number], [BankName], [Swift], [CardType], [ExpiryMonth], [ExpiryYear], [Discriminator])
VALUES (@0, @1, NULL, NULL, @2, @3, @4, @5)
SELECT [BillingDetailId]
FROM [dbo].[BillingDetails]
WHERE @@ROWCOUNT > 0 AND [BillingDetailId] = scope_identity()',N'@0 nvarchar(max) ,@1 nvarchar(max) ,@2 int,@3 nvarchar(max) ,@4 nvarchar(max) ,@5 nvarchar(128)',@0=N'Owner 54321',@1=N'0283632846',@2=22,@3=N'April',@4=N'2019',@5=N'CreditCard'



exec sp_executesql N'INSERT [dbo].[BillingDetails]([Owner], [Number], [BankName], [Swift], [CardType], [ExpiryMonth], [ExpiryYear], [Discriminator])
VALUES (@0, @1, NULL, NULL, @2, @3, @4, @5)
SELECT [BillingDetailId]
FROM [dbo].[BillingDetails]
WHERE @@ROWCOUNT > 0 AND [BillingDetailId] = scope_identity()',N'@0 nvarchar(max) ,@1 nvarchar(max) ,@2 int,@3 nvarchar(max) ,@4 nvarchar(max) ,@5 nvarchar(128)',@0=N'Owner 54321',@1=N'0283632846',@2=22,@3=N'April',@4=N'2019',@5=N'CreditCard'


            // for select, same as below
{SELECT 
    [Extent1].[Discriminator] AS [Discriminator], 
    [Extent1].[BillingDetailId] AS [BillingDetailId], 
    [Extent1].[Owner] AS [Owner], 
    [Extent1].[Number] AS [Number], 
    [Extent1].[BankName] AS [BankName], 
    [Extent1].[Swift] AS [Swift], 
    [Extent1].[CardType] AS [CardType], 
    [Extent1].[ExpiryMonth] AS [ExpiryMonth], 
    [Extent1].[ExpiryYear] AS [ExpiryYear]
    FROM [dbo].[BillingDetails] AS [Extent1]
    WHERE [Extent1].[Discriminator] IN (N'BankAccount',N'CreditCard',N'BillingDetail')}



SELECT 
    [Extent1].[Discriminator] AS [Discriminator], 
    [Extent1].[BillingDetailId] AS [BillingDetailId], 
    [Extent1].[Owner] AS [Owner], 
    [Extent1].[Number] AS [Number], 
    [Extent1].[BankName] AS [BankName], 
    [Extent1].[Swift] AS [Swift], 
    [Extent1].[CardType] AS [CardType], 
    [Extent1].[ExpiryMonth] AS [ExpiryMonth], 
    [Extent1].[ExpiryYear] AS [ExpiryYear]
    FROM [dbo].[BillingDetails] AS [Extent1]
    WHERE [Extent1].[Discriminator] IN (N'BankAccount',N'CreditCard',N'BillingDetail')


             
                */


                #endregion
            }

            Console.ReadKey();
        }
    }
}
