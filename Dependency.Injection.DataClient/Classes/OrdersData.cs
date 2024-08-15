using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dependency.Injection.DataClient
{
    public class OrdersData
    {
        public DateTime? OrderDate { get; set; }
        public String ProductName { get; set; }
        public Int32? Quantity { get; set; }
        public Decimal Price { get; set; }
        public Decimal TotalCost { get; set; }
    }
}
