using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dependency.Injection.DataModel;

namespace Dependency.Injection.DataClient
{
    public class Northwind
    {
        public Lazy<List<Category>> CategoryData { get; set; }
        public Lazy<List<Customer>> CustomerData { get; set; }
        public Lazy<List<CustomerDemographic>> CustomerDemographicData { get; set; }
        public Lazy<List<Employee>> EmployeeData { get; set; }
        public Lazy<List<Order>> OrderData { get; set; }
        public Lazy<List<Order_Detail>> OrderDetailData { get; set; }
        public Lazy<List<Product>> ProductData { get; set; }
        public Lazy<List<Region>> RegionData { get; set; }
        public Lazy<List<Shipper>> ShipperData { get; set; }
        public Lazy<List<Supplier>> SupplierData { get; set; }
        public Lazy<List<Territory>> TerritoryData { get; set; }

        //public Lazy<List<OrdersData>> CustomerOrderData { get; set; }

    }
}
