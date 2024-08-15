using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Dependency.Injection.DataClient;

namespace Dependency.Injection.WPFHost
{
    class ContainerBootStrapper
    {
        public static void RegisterTypes(IUnityContainer container)
        {
            //container.RegisterInstance<IData>("DbData", new DatabaseDirectClient(false));
            //container.RegisterInstance<IData>("MockedData", new MockedDataClient(10));

            container.RegisterType<IData, MockedDataClient>("MockedData",
                                            new TransientLifetimeManager(),
                                            new InjectionConstructor(10));

            container.RegisterType<IData, DatabaseDirectClient>("DbData",
                                            new TransientLifetimeManager(),
                                            new InjectionConstructor(false));
        }
    }
}
