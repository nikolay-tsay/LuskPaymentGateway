using LuskPaymentGatewayServices.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace LuskPaymentGatewayServices.Models
{
    public class OrderItem
    {
        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public OrderItemType Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; } = null!;
        
        [JsonProperty("count")]
        public int Count { get; set; }
        
        [JsonProperty("total_price")]
        public int TotalPrice { get; set; }
        
        [JsonProperty("ean")]
        public string? Ean { get; set; }
    }
}