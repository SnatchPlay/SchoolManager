using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Factory
{
    public class FactoryProvider
    {
        public static IFactory GetFactory()
        {
            var factoryType = ConfigurationManager.AppSettings["factoryType"];
            switch (factoryType)
            {
                case "ADO":
                    return new ADOFactory();
                default:
                    return new EFFactory();
            }

        }
    }
}
