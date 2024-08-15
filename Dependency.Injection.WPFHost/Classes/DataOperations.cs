using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dependency.Injection.DataClient;
using Dependency.Injection.DataModel;

namespace Dependency.Injection.WPFHost
{
    class DataOperations
    {
        public static ObservableCollection<OrdersData> GetCustomerOrders(Northwind northWindData, String customerID)
        {
            try
            {
                List<Order> customerOrders = (from cd in northWindData.CustomerData.Value
                                              where cd.CustomerID == customerID
                                              select cd).FirstOrDefault().Orders.ToList();

                List<OrdersData> ordersData = new List<OrdersData>();

                customerOrders.ForEach(x => ordersData.Add(
                                                    new OrdersData() 
                                                    { 
                                                        OrderDate = x.OrderDate, 
                                                        ProductName = x.Order_Details.First().Product.ProductName,
                                                        Price = x.Order_Details.First().UnitPrice,
                                                        Quantity = x.Order_Details.First().Quantity,
                                                        TotalCost = x.Order_Details.First().UnitPrice *
                                                                    x.Order_Details.First().Quantity
                                                    }));

                return ordersData.ToObservableCollection();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static ObservableCollection<Tuple<string, string>> GetCustomers(Northwind northwindData)
        {
            IEnumerable<Tuple<string, string>> customerData = from cd in northwindData.CustomerData.Value
                                                              select new Tuple<string, string>(cd.CustomerID, cd.ContactName);

            return customerData.ToObservableCollection();
        }
    }
}
