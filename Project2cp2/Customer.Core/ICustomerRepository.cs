using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp.Core
{
    public interface ICustomerRepository
    {

        // IEnumerable<Customer> CustList(Customer Id);
        Customer FindByCustID(int Id);
        //  List<Customer> searchdetails(int Id);
        Customer FindByEmail(string Email);
        void AddCustomer(Customer c);
    }
}
