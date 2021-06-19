using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using StockChecker.Models;

namespace StockChecker.Library {

    public class JsonConfig : IConfig {

        public Config Settings {get; set;}

        public JsonConfig() {

            using (FileStream fs = File.OpenRead("./settings.json"))
            {
                using (StreamReader sr = new StreamReader(fs)) {

                    var options = new JsonSerializerOptions
                    {
                        ReadCommentHandling = JsonCommentHandling.Skip,
                        AllowTrailingCommas = true,
                    };

                    string json = sr.ReadToEnd();
                    Settings = System.Text.Json.JsonSerializer.Deserialize<Config>(json, options);
                }
            }
        }
    }
}
