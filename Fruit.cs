using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace FruitMarket
{
    public class Fruit
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("family")]
        public string Family { get; set; }
        [JsonPropertyName("genus")]
        public string Genus { get; set; }
        [JsonPropertyName("order")]
        public string Order { get; set; }
        [JsonPropertyName("nutritions")]
        public Dictionary<string, float> Nutrition { get; set; } = new Dictionary<string, float>();

    }
}
