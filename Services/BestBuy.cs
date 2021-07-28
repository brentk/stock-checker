
using AngleSharp;
using System.Linq;
using StockChecker.Library;
using StockChecker.Models;
using System;

namespace StockChecker.Services {
    public class BestBuy : IStockChecker {

        protected Config _config;
        protected IMailer _mailer;

        public BestBuy(IConfig config, IMailer mailer) {
            _config = config.Settings;
            _mailer = mailer;
        }

        public void Run() {

            foreach (var item in _config.Items.Where(i => i.Type == "BestBuy")) {
                var config = Configuration.Default.WithDefaultLoader();
                var document = BrowsingContext.New(config).OpenAsync(item.Url).GetAwaiter().GetResult();
                var fulfillment = document.QuerySelectorAll(".fulfillment-fulfillment-summary").ToList();

                if (fulfillment?[0]?.Children?[0]?.Children?[0]?.Children?[0]?.TextContent?.ToLower() != "sold out") {

                    string subject = item.Name;
                    string body = $"{item.Name} appears to be in stock\n\n{item.Url}";

                    Console.WriteLine(body);
                    foreach(string email in _config.Emails) {
                        _mailer.Send(email, subject, body);
                    }
                } else {
                    Console.WriteLine($"{DateTime.Now}: {item.Name} is not in stock.");
                }
            }
        }
    }
}
