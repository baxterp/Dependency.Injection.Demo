using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dependency.Injection.DataModel;

namespace Dependency.Injection.DataAccess
{
    public class NorthwindDataAccess
    {
        NorthwindEntities context = null;

        public NorthwindDataAccess()
        {
            context = new NorthwindEntities();
        }

        public List<Category> GetCategories()
        {
            try
            {
                List<Category> categories = context.Categories.ToList();
                return categories;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<Customer> GetCustomers()
        {
            try
            {
                List<Customer> customers = context.Customers.ToList();
                return customers;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<CustomerDemographic> GetCustomerDemographics()
        {
            try 
	        {
                List<CustomerDemographic> customerDemographics = context.CustomerDemographics.ToList();
                return customerDemographics;
	        }
	        catch (Exception ex)
	        {
                return null;
            }
        }

        public List<Employee> GetEmployees()
        {
            try 
            {
                List<Employee> employees = context.Employees.ToList();
                return employees;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<Order> GetOrders()
        {
            try 
            {
                List<Order> orders = context.Orders.ToList();
                return orders;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<Order_Detail> GetOrderDetails()
        {
            try 
            {
                List<Order_Detail> orderDetails = context.Order_Details.ToList();
                return orderDetails;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<Product> GetProducts()
        {
            try
            {
                List<Product> products = context.Products.ToList();
                return products;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<Region> GetRegions()
        {
            try 
            {
                List<Region> regions = context.Regions.ToList();
                return regions;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<Shipper> GetShippers()
        {
            try 
            {
                List<Shipper> shippers = context.Shippers.ToList();
                return shippers;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<Supplier> GetSuppliers()
        {
            try 
            {
                List<Supplier> suppliers = context.Suppliers.ToList();
                return suppliers;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<Territory> GetTerritories()
        {
            try 
            {
                List<Territory> territories = context.Territories.ToList();
                return territories;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
