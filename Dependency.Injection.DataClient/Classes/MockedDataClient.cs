using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dependency.Injection.DataMocking;
using Dependency.Injection.DataModel;

namespace Dependency.Injection.DataClient
{
    public class MockedDataClient : IData
    {
        Northwind data = null;
        private Int32 numberOfRecords = 0;


        public MockedDataClient(Int32 numberOfRecords)
        {
            this.numberOfRecords = numberOfRecords;
        }

        public Northwind Data
        {
            get
            {
                if (data == null)
                    data = GetNorthwindData();

                return data;
            }
            set
            {
                data = value;
            }
        }

        private Northwind GetNorthwindData()
        {
            Northwind northwindData = new Northwind();

            northwindData.CategoryData = new Lazy<List<Category>> (() => MockData.GetCategories(numberOfRecords));
            northwindData.CustomerData = new Lazy<List<Customer>> (() => MockData.GetCustomers(numberOfRecords));
            northwindData.CustomerDemographicData = new Lazy<List<CustomerDemographic>>(() => MockData.GetCustomerDemographics(numberOfRecords));
            northwindData.EmployeeData = new Lazy<List<Employee>>(() => MockData.GetEmployees(numberOfRecords));
            northwindData.OrderData = new Lazy<List<Order>> (() => MockData.GetOrders(numberOfRecords));
            northwindData.OrderDetailData = new Lazy<List<Order_Detail>> (() => MockData.GetOrderDetails(numberOfRecords));
            northwindData.ProductData = new Lazy<List<Product>> (() => MockData.GetProducts(numberOfRecords));
            northwindData.RegionData = new Lazy<List<Region>> (() => MockData.GetRegions(numberOfRecords));
            northwindData.ShipperData = new Lazy<List<Shipper>> (() => MockData.GetShippers(numberOfRecords));
            northwindData.SupplierData = new Lazy<List<Supplier>> (() => MockData.GetSuppliers(numberOfRecords));
            northwindData.TerritoryData = new Lazy<List<Territory>> (() => MockData.GetTerritories(numberOfRecords));

            return northwindData;
        }
    }
}
