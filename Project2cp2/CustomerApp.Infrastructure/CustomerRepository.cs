using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerApp.Core;

namespace CustomerApp.Infrastructure
{
    class CustomerRepository : ICustomerRepository
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
    }
}
