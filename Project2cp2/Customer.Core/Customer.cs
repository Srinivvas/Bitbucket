using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Customer.Core
{
   public class Customer
    {

        [Key]

        public int CustomerID { get; set; }

        [StringLength(30)]
        public string CustomerName { get; set; }

        [MaxLength(25)]
        public string ContactEmail { get; set; }
        [Range(0, 9)]
        public int MobileNo { get; set; }



       public virtual List<Transactions> Transactions { get; set; }


    }
}
