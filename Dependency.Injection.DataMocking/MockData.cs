using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FizzWare.NBuilder;
using Dependency.Injection.DataModel;

namespace Dependency.Injection.DataMocking
{
    public class MockData
    {
        public static List<Category> GetCategories(int size)
        {
            List<Category> categories = Builder<Category>.CreateListOfSize(size).Build().ToList();
            return categories;
        }

        public static List<Customer> GetCustomers(int size)
        {
            List<Customer> customers = Builder<Customer>.CreateListOfSize(size).Build().ToList();
            return customers;
        }

        public static List<CustomerDemographic> GetCustomerDemographics(int size)
        {
            List<CustomerDemographic> customerDemographics = Builder<CustomerDemographic>.CreateListOfSize(size).Build().ToList();
            return customerDemographics;
        }

        public static List<Employee> GetEmployees(int size)
        {
            List<Employee> employess = Builder<Employee>.CreateListOfSize(size).Build().ToList();
            return employess;
        }

        public static List<Order> GetOrders(int size)
        {
            List<Order> orders = Builder<Order>.CreateListOfSize(size).Build().ToList();
            return orders;
        }

        public static List<Order_Detail> GetOrderDetails(int size)
        {
            List<Order_Detail> orderDetails = Builder<Order_Detail>.CreateListOfSize(size).Build().ToList();
            return orderDetails;
        }

        public static List<Product> GetProducts(int size)
        {
            List<Product> products = Builder<Product>.CreateListOfSize(size).Build().ToList();
            return products;
        }

        public static List<Region> GetRegions(int size)
        {
            List<Region> regions = Builder<Region>.CreateListOfSize(size).Build().ToList();
            return regions;
        }

        public static List<Shipper> GetShippers(int size)
        {
            List<Shipper> shippers = Builder<Shipper>.CreateListOfSize(size).Build().ToList();
            return shippers;
        }

        public static List<Supplier> GetSuppliers(int size)
        {
            List<Supplier> suppliers = Builder<Supplier>.CreateListOfSize(size).Build().ToList();
            return suppliers;
        }

        public static List<Territory> GetTerritories(int size)
        {
            List<Territory> territories = Builder<Territory>.CreateListOfSize(size).Build().ToList();
            return territories;
        }
    }
}
