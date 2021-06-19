using StockChecker.Library;
using StockChecker.Services;
using Unity;

namespace StockChecker
{
    class Program
    {
        static void Main(string[] args) {
            var stockCheckers  = Container.Instance().ResolveAll<IStockChecker>();
            foreach (IStockChecker checker in stockCheckers) {
                checker.Run();
            }
        }
    }
}