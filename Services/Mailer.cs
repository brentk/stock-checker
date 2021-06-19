using System;
using System.Net;
using System.Net.Mail;
using StockChecker.Library;
using StockChecker.Models;

namespace StockChecker.Services {

    public class Mailer : IMailer {

        protected Config _config;

        public Mailer(IConfig config) {
            _config = config.Settings;
        }

        public void Send(string to, string subject, string body) {

            var smtpClient = new SmtpClient(_config.Smtp.Server) {
                Port = _config.Smtp.Port,
                Credentials = new NetworkCredential(_config.Smtp.Username, _config.Smtp.Password),
                EnableSsl = _config.Smtp.UseSsl,
            };

            smtpClient.Send(_config.Smtp.From, to, subject, body);
        }
    }
}