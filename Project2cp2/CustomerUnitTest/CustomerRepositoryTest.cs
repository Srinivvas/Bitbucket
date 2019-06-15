using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using CustomerApp.Infrastructure;
 

namespace CustomerUnitTest
{
    [TestClass]
    public class CustomerRepositoryTest
    {
        CustomerRepository CusRep;
        [TestInitialize]
        public void CustomerTestSetup()
        {
            CustomerInitilizeDB db = new CustomerInitilizeDB();
            Database.SetInitializer(db);
            CusRep = new CustomerRepository();

        }

        [TestMethod]

        public void IsRepositoryGettingData()
        {

            var result = CusRep.GetCustomers();
            Assert.IsNotNull(result);
            var numberofRecordsReturn = result.ToList().Count();
            Assert.AreEqual(3, numberofRecordsReturn);


        }

    }
}
