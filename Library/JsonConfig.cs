using System.Collections.Generic;
using System.IO;
using StockChecker.Models;

namespace StockChecker.Library {

    public class JsonConfig : IConfig {

        public Config Settings {get; set;}

        public JsonConfig() {

            using (FileStream fs = File.OpenRead("./settings.json"))
            {
                using (StreamReader sr = new StreamReader(fs)) {
                    string json = sr.ReadToEnd();
                    Settings = System.Text.Json.JsonSerializer.Deserialize<Config>(json);
                }
            }
        }
    }
}
