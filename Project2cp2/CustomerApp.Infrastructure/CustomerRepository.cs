using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerApp.Core;

namespace CustomerApp.Infrastructure
{
   public class CustomerRepository : ICustomerRepository
    {

        CustomerContext context = new CustomerContext();

        public void AddCustomer(Customer c)
        {
            context.customers.Add(c);
            context.SaveChanges();
        }

        public Customer FindByCustID(int Id)
        {
            var result = (from c in context.customers where c.CustomerID == Id select c).FirstOrDefault();
            return result;
        }

        public Customer FindByEmail(string Email)
        {
            var result = (from e in context.customers where e.ContactEmail == Email select e).FirstOrDefault();
            return result;
        }

        //public Customer FindCustomers(int? id = 0, string email = "")
        //{
        //    int tempID = 0;

        //    if (id != 0 || email != "")
        //    {
        //        var details = (from custmer in context.customers
        //                       where custmer.CustomerID == id ||
        //                       custmer.ContactEmail == email
        //                       select custmer.CustomerID).FirstOrDefault();
        //        if (details != null)
        //        {

        //            tempID = Convert.ToInt32(details);
        //        }

        //    }

        //    var result = (from Cust in context.customers
        //                 where Cust.CustomerID == tempID
        //                 select new
        //                 {
        //                     Cust.CustomerID,
        //                     Cust.CustomerName,
        //                     Cust.ContactEmail,
        //                     Cust.MobileNo,

        //                     tran = from tran in context.Transactions
        //                            join sta in context.statuses on tran.StatusID equals sta.StatusID
        //                            join curr in context.currencies on tran.CurrencyID equals curr.CurrencyID
        //                            where tran.CustomerID == Cust.CustomerID

        //                            select new
        //                            {
        //                                tran.TransactionID,
        //                                tran.TransactionDateTime,
        //                                tran.Amount,
        //                                curr.CurrencyName,
        //                                sta.StatusName

        //                            }

        //                 });


        //    return result.ToList() ;

        //}

    

        public IEnumerable<Customer> GetCustomers()
        {
            return context.customers;
        }
    }
}
