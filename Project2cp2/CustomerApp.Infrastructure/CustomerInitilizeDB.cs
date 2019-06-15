using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using CustomerApp.Core;

namespace CustomerApp.Infrastructure
{
  public  class CustomerInitilizeDB : DropCreateDatabaseIfModelChanges<CustomerContext>
    {
        // Overide Seed class
        protected override void Seed(CustomerContext context)
        {
            base.Seed(context);
            context.statuses.Add(new Status
            {
                StatusID = 1,
                StatusName = "Inprogress"

            });
            context.statuses.Add(new Status

            {
                StatusID = 2,
                StatusName = "Sucessful"
            }

                );
            context.currencies.Add(new Currency
            {
                CurrencyID = 1,
                CurrencyName = "THB"
            });
            context.currencies.Add(new Currency
            {
                CurrencyID = 2,
                CurrencyName = "USD"
            });

            context.customers.Add(new Customer
            {
                CustomerID = 1,
                CustomerName = "CustomerName1",
                ContactEmail = "CustomerName1@gmail.com",
                MobileNo = 121212121

            });

            context.customers.Add(new Customer
            {
                CustomerID = 2,
                CustomerName = "CustomerName2",
                ContactEmail = "CustomerName2@gmail.com",
                MobileNo = 888656565

            });


            context.Transactions.Add(new Transactions
            {
                TransactionID = 1,
                TransactionDateTime = DateTime.Today,
                Amount=1212,
                CurrencyID =1,
                StatusID =2,
                CustomerID = context.customers.Find(1).CustomerID

            });

            context.Transactions.Add(new Transactions
            {
                TransactionID = 2,
                TransactionDateTime = DateTime.Today,
                Amount = 8887,
                CurrencyID = 2,
                StatusID = 2,
                CustomerID = context.customers.Find(1).CustomerID

            });

            context.Transactions.Add(new Transactions
            {
                TransactionID = 3,
                TransactionDateTime = DateTime.Today,
                Amount = 9999,
                CurrencyID = 1,
                StatusID = 1,
                CustomerID = context.customers.Find(2).CustomerID

            });


            
            context.SaveChanges();

        }

    }
}
