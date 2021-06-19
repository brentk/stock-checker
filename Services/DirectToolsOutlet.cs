
using AngleSharp;
using System.Linq;
using StockChecker.Library;
using StockChecker.Models;

namespace StockChecker.Services {
    public class DirectToolsOutlet : IStockChecker {

        protected Config _config;
        protected IMailer _mailer;

        public DirectToolsOutlet(IConfig config, IMailer mailer) {
            _config = config.Settings;
            _mailer = mailer;
        }

        public void Run() {

            foreach (var item in _config.Items) {
                var config = Configuration.Default.WithDefaultLoader();
                var document = BrowsingContext.New(config).OpenAsync(item.Url).GetAwaiter().GetResult();
                var oosButtons = document.QuerySelectorAll(".outOfStock").ToList();

                if (oosButtons.Count == 0) {

                    string subject = item.Name;
                    string body = $"{item.Name} appears to be in stock\n\n${item.Url}";

                    foreach(string email in _config.Emails) {
                        _mailer.Send(email, subject, body);
                    }
                }
            }
        }
    }
}
