using LuskPaymentGatewayServices.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace LuskPaymentGatewayServices.Models
{
    public class Subscription
    {
        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public SubscriptionType Type { get; set; }

        [JsonProperty("period")]
        public ushort Period{ get; set; }
        
    }
}