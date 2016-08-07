using System;
using System.Linq;

namespace TPT_FluentAPI
{
    class Program
    {
        static void Main(string[] args)
        {

            // both BankAccount and CreditCard inherits from BillingDetail(abstract)

            var bankAccount1 = new BankAccount { BankName = "BPI", Number = "784327625", Owner = "Owner 123", Swift = "AFBCV22SU" };
            var bankAccount2 = new BankAccount { BankName = "BDO", Number = "43226924", Owner = "Owner 1234", Swift = "BFFGT47UI" };
            var creditCard1 = new CreditCard { ExpiryMonth = "April", Owner = "Owner 54321", Number = "0283632846", CardType = 22, ExpiryYear = "2019" };
            var creditCard2 = new CreditCard { ExpiryMonth = "April", Owner = "Owner 54321", Number = "0283632846", CardType = 22, ExpiryYear = "2019" };

            using (var context = new DataContext())
            {
                // profile the sql command generated to the database, 
                // note: check for triggers as I assume that there is  1-1 relationship between BillingDetail-BankAccount and BillingDetail-CreditCard
                // check also for the insert statement, is BankAccount or CreditCard inserted after BillingDetail, or BankAccount or CreditCard are in one insert statement with BillingDetail

                context.BillingDetails.Add(bankAccount1);
                context.BillingDetails.Add(bankAccount2);
                context.BillingDetails.Add(creditCard1);
                context.BillingDetails.Add(creditCard2);
                context.SaveChanges();

                #region sql result

                /*
                     
                    exec sp_executesql N'INSERT [dbo].[BillingDetails]([Owner], [Number])
VALUES (@0, @1)
SELECT [BillingDetailId]
FROM [dbo].[BillingDetails]
WHERE @@ROWCOUNT > 0 AND [BillingDetailId] = scope_identity()',N'@0 nvarchar(max) ,@1 nvarchar(max) ',@0=N'Owner 123',@1=N'784327625'


exec sp_executesql N'INSERT [dbo].[BankAccounts]([BillingDetailId], [BankName], [Swift])
VALUES (@0, @1, @2)
',N'@0 int,@1 nvarchar(max) ,@2 nvarchar(max) ',@0=1,@1=N'BPI',@2=N'AFBCV22SU'



exec sp_executesql N'INSERT [dbo].[BillingDetails]([Owner], [Number])
VALUES (@0, @1)
SELECT [BillingDetailId]
FROM [dbo].[BillingDetails]
WHERE @@ROWCOUNT > 0 AND [BillingDetailId] = scope_identity()',N'@0 nvarchar(max) ,@1 nvarchar(max) ',@0=N'Owner 1234',@1=N'43226924'


exec sp_executesql N'INSERT [dbo].[BankAccounts]([BillingDetailId], [BankName], [Swift])
VALUES (@0, @1, @2)
',N'@0 int,@1 nvarchar(max) ,@2 nvarchar(max) ',@0=2,@1=N'BDO',@2=N'BFFGT47UI'


exec sp_executesql N'INSERT [dbo].[BillingDetails]([Owner], [Number])
VALUES (@0, @1)
SELECT [BillingDetailId]
FROM [dbo].[BillingDetails]
WHERE @@ROWCOUNT > 0 AND [BillingDetailId] = scope_identity()',N'@0 nvarchar(max) ,@1 nvarchar(max) ',@0=N'Owner 54321',@1=N'0283632846'


exec sp_executesql N'INSERT [dbo].[BillingDetails]([Owner], [Number])
VALUES (@0, @1)
SELECT [BillingDetailId]
FROM [dbo].[BillingDetails]
WHERE @@ROWCOUNT > 0 AND [BillingDetailId] = scope_identity()',N'@0 nvarchar(max) ,@1 nvarchar(max) ',@0=N'Owner 54321',@1=N'0283632846'


exec sp_executesql N'INSERT [dbo].[CreditCards]([BillingDetailId], [CardType], [ExpiryMonth], [ExpiryYear])
VALUES (@0, @1, @2, @3)
',N'@0 int,@1 int,@2 nvarchar(max) ,@3 nvarchar(max) ',@0=3,@1=22,@2=N'April',@3=N'2019'


exec sp_executesql N'INSERT [dbo].[CreditCards]([BillingDetailId], [CardType], [ExpiryMonth], [ExpiryYear])
VALUES (@0, @1, @2, @3)
',N'@0 int,@1 int,@2 nvarchar(max) ,@3 nvarchar(max) ',@0=4,@1=22,@2=N'April',@3=N'2019'













SELECT 
    CASE WHEN (( NOT (([Project1].[C1] = 1) AND ([Project1].[C1] IS NOT NULL))) AND ( NOT (([Project2].[C1] = 1) AND ([Project2].[C1] IS NOT NULL)))) THEN '0X' WHEN (([Project2].[C1] = 1) AND ([Project2].[C1] IS NOT NULL)) THEN '0X0X' ELSE '0X1X' END AS [C1], 
    [Extent1].[BillingDetailId] AS [BillingDetailId], 
    [Extent1].[Owner] AS [Owner], 
    [Extent1].[Number] AS [Number], 
    CASE WHEN (( NOT (([Project1].[C1] = 1) AND ([Project1].[C1] IS NOT NULL))) AND ( NOT (([Project2].[C1] = 1) AND ([Project2].[C1] IS NOT NULL)))) THEN CAST(NULL AS varchar(1)) WHEN (([Project2].[C1] = 1) AND ([Project2].[C1] IS NOT NULL)) THEN [Project2].[BankName] END AS [C2], 
    CASE WHEN (( NOT (([Project1].[C1] = 1) AND ([Project1].[C1] IS NOT NULL))) AND ( NOT (([Project2].[C1] = 1) AND ([Project2].[C1] IS NOT NULL)))) THEN CAST(NULL AS varchar(1)) WHEN (([Project2].[C1] = 1) AND ([Project2].[C1] IS NOT NULL)) THEN [Project2].[Swift] END AS [C3], 
    CASE WHEN (( NOT (([Project1].[C1] = 1) AND ([Project1].[C1] IS NOT NULL))) AND ( NOT (([Project2].[C1] = 1) AND ([Project2].[C1] IS NOT NULL)))) THEN CAST(NULL AS int) WHEN (([Project2].[C1] = 1) AND ([Project2].[C1] IS NOT NULL)) THEN CAST(NULL AS int) ELSE [Project1].[CardType] END AS [C4], 
    CASE WHEN (( NOT (([Project1].[C1] = 1) AND ([Project1].[C1] IS NOT NULL))) AND ( NOT (([Project2].[C1] = 1) AND ([Project2].[C1] IS NOT NULL)))) THEN CAST(NULL AS varchar(1)) WHEN (([Project2].[C1] = 1) AND ([Project2].[C1] IS NOT NULL)) THEN CAST(NULL AS varchar(1)) ELSE [Project1].[ExpiryMonth] END AS [C5], 
    CASE WHEN (( NOT (([Project1].[C1] = 1) AND ([Project1].[C1] IS NOT NULL))) AND ( NOT (([Project2].[C1] = 1) AND ([Project2].[C1] IS NOT NULL)))) THEN CAST(NULL AS varchar(1)) WHEN (([Project2].[C1] = 1) AND ([Project2].[C1] IS NOT NULL)) THEN CAST(NULL AS varchar(1)) ELSE [Project1].[ExpiryYear] END AS [C6]
    FROM   [dbo].[BillingDetails] AS [Extent1]
    LEFT OUTER JOIN  (SELECT 
        [Extent2].[BillingDetailId] AS [BillingDetailId], 
        [Extent2].[CardType] AS [CardType], 
        [Extent2].[ExpiryMonth] AS [ExpiryMonth], 
        [Extent2].[ExpiryYear] AS [ExpiryYear], 
        cast(1 as bit) AS [C1]
        FROM [dbo].[CreditCards] AS [Extent2] ) AS [Project1] ON [Extent1].[BillingDetailId] = [Project1].[BillingDetailId]
    LEFT OUTER JOIN  (SELECT 
        [Extent3].[BillingDetailId] AS [BillingDetailId], 
        [Extent3].[BankName] AS [BankName], 
        [Extent3].[Swift] AS [Swift], 
        cast(1 as bit) AS [C1]
        FROM [dbo].[BankAccounts] AS [Extent3] ) AS [Project2] ON [Extent1].[BillingDetailId] = [Project2].[BillingDetailId]
                 */

                #endregion

                // result no triggers were found
                // each entry generated an insert statement
                // tpt does automatically use 1-1

                // if we breakpoint here we can check the query
                var queryable = context.BillingDetails;
                queryable.ToList();
            }

            Console.ReadKey();
        }
    }
}
