using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dependency.Injection.DataModel;
using Dependency.Injection.DataAccess;

namespace Dependency.Injection.DataClient
{
    public class DatabaseDirectClient : IData 
    {
        NorthwindDataAccess dBAccess = null;
        Northwind data = null;

        public DatabaseDirectClient(Boolean getAllData)
        {
            dBAccess = new NorthwindDataAccess();
            if (getAllData) Data = GetNorthwindData();
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
            try
            {
                Northwind northwindData = new Northwind();

                northwindData.CustomerData = new Lazy<List<Customer>>(() => dBAccess.GetCustomers());
                northwindData.CategoryData = new Lazy<List<Category>>(() => dBAccess.GetCategories());
                northwindData.CustomerDemographicData = new Lazy<List<CustomerDemographic>>(() => dBAccess.GetCustomerDemographics());
                northwindData.EmployeeData = new Lazy<List<Employee>>(() => dBAccess.GetEmployees());
                northwindData.OrderData = new Lazy<List<Order>>(() => dBAccess.GetOrders());
                northwindData.OrderDetailData = new Lazy<List<Order_Detail>>(() => dBAccess.GetOrderDetails());
                northwindData.ProductData = new Lazy<List<Product>>(() => dBAccess.GetProducts());
                northwindData.RegionData = new Lazy<List<Region>>(() => dBAccess.GetRegions());
                northwindData.ShipperData = new Lazy<List<Shipper>>(() => dBAccess.GetShippers());
                northwindData.SupplierData = new Lazy<List<Supplier>>(() => dBAccess.GetSuppliers());
                northwindData.TerritoryData = new Lazy<List<Territory>>(() => dBAccess.GetTerritories());

                return northwindData;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
