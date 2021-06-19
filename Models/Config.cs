using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace StockChecker.Models {

    public class Item {
        [JsonPropertyName("type")]
        public string Type {get; set;}
        [JsonPropertyName("name")]
        public string Name {get; set;}
        [JsonPropertyName("url")]
        public string Url {get; set;}
    }

    public class Smtp {
        [JsonPropertyName("server")]
        public string Server {get; set;}
        [JsonPropertyName("username")]
        public string Username {get; set;}
        [JsonPropertyName("password")]
        public string Password {get; set;}
        [JsonPropertyName("useSsl")]
        public bool UseSsl {get; set;}
        [JsonPropertyName("port")]
        public int Port {get; set;}
    }

    public class Config {
        [JsonPropertyName("smtp")]
        public Smtp Smtp {get; set;}
        [JsonPropertyName("items")]
        public List<Item> Items {get; set;}
        [JsonPropertyName("emailsToNotify")]
        public List<string> Emails {get; set;}
    }
}
