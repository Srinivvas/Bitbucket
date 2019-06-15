using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CustomerApp.Core;
using CustomerApp.Infrastructure;

namespace CustomerAPI.Controllers
{
    public class CustomersController : ApiController
    {
        private CustomerContext db = new CustomerContext();

        [HttpGet]
        public IHttpActionResult GetCustomer(int? id = 0, string email = "")
        {

            int tempID = 0;

            if (id != 0 || email != "")
            {
                var details = (from custmer in db.customers
                               where custmer.CustomerID == id ||
                               custmer.ContactEmail == email
                               select custmer.CustomerID).FirstOrDefault();
                if (details != null)
                {

                    tempID = Convert.ToInt32(details);
                }

            }

            var result = from Cust in db.customers
                         where Cust.CustomerID == tempID
                         select new
                         {
                             Cust.CustomerID,
                             Cust.CustomerName,
                             Cust.ContactEmail,
                             Cust.MobileNo,

                             tran = from tran in db.Transactions
                                    join sta in db.statuses on tran.StatusID equals sta.StatusID
                                    join curr in db.currencies on tran.CurrencyID equals curr.CurrencyID
                                    where tran.CustomerID == Cust.CustomerID

                                    select new
                                    {
                                        tran.TransactionID,
                                        tran.TransactionDateTime,
                                        tran.Amount,
                                        curr.CurrencyName,
                                        sta.StatusName

                                    }

                         };


            return Ok(result);

        }



        //// PUT: api/Customers/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutCustomer(int id, Customer customer)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != customer.CustomerID)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(customer).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!CustomerExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// POST: api/Customers
        //[ResponseType(typeof(Customer))]
        //public IHttpActionResult PostCustomer(Customer customer)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.customers.Add(customer);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = customer.CustomerID }, customer);
        //}

        //// DELETE: api/Customers/5
        //[ResponseType(typeof(Customer))]
        //public IHttpActionResult DeleteCustomer(int id)
        //{
        //    Customer customer = db.customers.Find(id);
        //    if (customer == null)
        //    {
        //        return NotFound();
        //    }

        //    db.customers.Remove(customer);
        //    db.SaveChanges();

        //    return Ok(customer);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool CustomerExists(int id)
        //{
        //    return db.customers.Count(e => e.CustomerID == id) > 0;
        //}
    }
}