using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Customer.Core
{
    public class Transactions
    {

        [Key]
        public int TransactionID { get; set; }
        public DateTime TransactionDateTime { get; set; }

        public decimal Amount { get; set; }

        public int CurrencyID { get; set; }

        public int StatusID { get; set; }

        public int CustomerID { get; set; }



        public virtual Customer Customer { get; set; }
        public virtual Status Status { get; set; }
        public virtual Currency Currency { get; set; }


    }
}
