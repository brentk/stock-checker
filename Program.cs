using StockChecker.Library;
using StockChecker.Services;
using Unity;

namespace StockChecker
{
    class Program
    {
        static void Main(string[] args) {
            IStockChecker directToolsOutlet = Container.Instance().Resolve<IStockChecker>("DirectToolsOutlet");
            directToolsOutlet.Run();
        }
    }
}