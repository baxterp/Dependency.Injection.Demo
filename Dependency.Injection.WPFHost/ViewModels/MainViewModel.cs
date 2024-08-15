using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.Practices.Unity;
using Dependency.Injection.DataModel;
using Dependency.Injection.DataClient;

namespace Dependency.Injection.WPFHost
{
    class MainViewModel : ViewModelBase
    {
        #region Construction

        public MainViewModel()
        {
            TabSelectionChangedCommand = new Command(GetTabSelectionChangedCommandExecute, GetTabSelectionChangedCommandCanExecute);
            ComboDatasourceChangedCommand = new Command(GetComboDatasourceChangedCommandExecute, GetComboDatasourceChangedCommandCanExecute);
            ComboCustomerChangedCommand = new Command(GetComboCustomerChangedCommandExecute, GetComboCustomerChangedCommandCanExecute);

            CustomerData = NorthwindData.CustomerData.Value.ToObservableCollection();
            EmployeeData = NorthwindData.EmployeeData.Value.ToObservableCollection();

            if (!DesignerProperties.GetIsInDesignMode(new DependencyObject()))
            {
                Customers = DataOperations.GetCustomers(NorthwindData);
                CustomerOrdersData = DataOperations.GetCustomerOrders(NorthwindData, NorthwindData.CustomerData.Value.Select(x => x.CustomerID).FirstOrDefault()).ToObservableCollection();
            }
        }

        #endregion

        #region Commands

        public Command TabSelectionChangedCommand { get; set; }
        public Command ComboDatasourceChangedCommand { get; set; }
        public Command ComboCustomerChangedCommand { get; set; }

        private Boolean GetComboCustomerChangedCommandCanExecute(Object parameter)
        {
            return true;
        }

        private void GetComboCustomerChangedCommandExecute(Object parameter)
        {
            if (parameter == null) return;

            Tuple<String, String> customerData = (Tuple<String, String>)parameter;

            String customerID = customerData.Item1;

            InvokeMethodThreaded(new Action(() =>
            {
                CustomerOrdersData = DataOperations.GetCustomerOrders(NorthwindData, customerID);
            }));
        }

        private Boolean GetComboDatasourceChangedCommandCanExecute(Object parameter)
        {
            return true;
        }

        private void GetComboDatasourceChangedCommandExecute(Object parameter)
        {
            ComboBoxItem comboBox = (ComboBoxItem)parameter;

            String selection = comboBox.Content.ToString();

            if (selection == "Mocked Data")
                NorthwindData = container.Resolve<IData>("MockedData").Data;

            if (selection == "Live Data")
            {
                InvokeMethodThreaded(new Action(() =>
                {
                    NorthwindData = container.Resolve<IData>("DbData").Data;
                }));
            }

            TabSelectedIndex = -1;
        }

        private Boolean GetTabSelectionChangedCommandCanExecute(Object parameter)
        {
            return true;
        }

        private void GetTabSelectionChangedCommandExecute(Object parameter)
        {
            if (parameter == null) return;

            TabItem tabItem = (TabItem)parameter;

            if (tabItem.Header.ToString() == "Customers")
            {
                InvokeMethodThreaded(new Action(() =>
                {
                    CustomerData = NorthwindData.CustomerData.Value.ToObservableCollection();
                }));
            }
            if (tabItem.Header.ToString() == "Customer Orders")
            {
                InvokeMethodThreaded(new Action(() =>
                {
                    Customers = DataOperations.GetCustomers(NorthwindData).ToObservableCollection();
                    CustomerOrdersData = new ObservableCollection<OrdersData>();
                }));
            }
            if (tabItem.Header.ToString() == "Employees")
            {
                InvokeMethodThreaded(new Action(() =>
                {
                    EmployeeData = NorthwindData.EmployeeData.Value.ToObservableCollection();
                }));
            }
        }

        #endregion

        #region Properties

        private Int32 _tabSelectedIndex = 0;
        public Int32 TabSelectedIndex
        {
            set
            {
                _tabSelectedIndex = value;
                RaisePropertyChanged("TabSelectedIndex");
            }
        }

        private ObservableCollection<OrdersData> _customerOrdersData = new ObservableCollection<OrdersData>();
        public ObservableCollection<OrdersData> CustomerOrdersData
        {
            get
            {
                return _customerOrdersData;
            }
            set
            {
                _customerOrdersData = value;
                RaisePropertyChanged("CustomerOrdersData");
            }
        }


        private ObservableCollection<Tuple<string, string>> _customers = new ObservableCollection<Tuple<string, string>>();
        public ObservableCollection<Tuple<string, string>> Customers
        {
            get
            {
                return _customers;
            }
            set
            {
                _customers = value;
                RaisePropertyChanged("Customers");
            }
        }

        private ObservableCollection<Customer> _customerData = new ObservableCollection<Customer>();
        public ObservableCollection<Customer> CustomerData
        {
            get
            {
                return _customerData;
            }
            set
            {
                _customerData = value;
                RaisePropertyChanged("CustomerData");
            }
        }

        private ObservableCollection<Employee> _employeeData = new ObservableCollection<Employee>();
        public ObservableCollection<Employee> EmployeeData
        {
            get
            {
                return _employeeData;
            }
            set
            {
                _employeeData = value;
                RaisePropertyChanged("EmployeeData");
            }
        }

        
        #endregion

        #region Visibility

        private Visibility _busyVisibility = Visibility.Hidden;
        public Visibility BusyVisibility
        {
            get
            {
                return _busyVisibility;
            }
            set
            {
                _busyVisibility = value;
                RaisePropertyChanged("BusyVisibility");
            }
        }

        #endregion

        #region Private Methods

        private void UISetBusy()
        {
            BusyVisibility = Visibility.Visible;
        }

        private void UIClearBusy()
        {
            BusyVisibility = Visibility.Hidden;
        }

        private void InvokeMethodThreaded(Action actionToExecute)
        {
            Thread t = new Thread(delegate()
            {
                UISetBusy();
                actionToExecute();
                UIClearBusy();
            });
            t.Start();
        }
        
        #endregion
    }
}
