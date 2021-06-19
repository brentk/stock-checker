using StockChecker.Services;
using Unity;

namespace StockChecker.Library {
    public class Container {
        static private UnityContainer _container = null;

        public static UnityContainer Instance() {
            if (_container == null) {
                _container = new UnityContainer();
                _container.RegisterType<IStockChecker, DirectToolsOutlet>("DirectToolsOutlet");
                _container.RegisterType<IConfig, JsonConfig>();
                _container.RegisterType<IMailer, Mailer>();
            }
            return _container;
        }
    }
}