using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerApp.Core;

namespace CustomerApp.Infrastructure
{
    public class CustomerContext : DbContext
    {
        public CustomerContext() : base("name=CustomerAppConnectionString")
        {

        }

        public DbSet<Customer> customers { get; set; }
        
        public DbSet<Transactions> Transactions { get; set; }
        public DbSet<Currency> currencies { get; set; }
        public DbSet<Status> statuses { get; set; }
    }
}
