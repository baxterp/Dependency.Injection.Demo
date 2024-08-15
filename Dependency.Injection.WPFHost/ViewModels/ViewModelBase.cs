using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Dependency.Injection.DataClient;

namespace Dependency.Injection.WPFHost
{
    class ViewModelBase : INotifyPropertyChanged
    {
        protected Northwind NorthwindData = null;
        protected IUnityContainer container;

        public ViewModelBase()
        {
            container = new UnityContainer();
            ContainerBootStrapper.RegisterTypes(container);

            NorthwindData = container.Resolve<IData>("MockedData").Data;
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Private Methods

        public void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}
