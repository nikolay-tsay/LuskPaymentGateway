using System;
using Newtonsoft.Json;

namespace LuskPaymentGatewayServices.Models.Requests
{
    public class UsageBasedRequest
    {
        [JsonProperty("payment_uid")]
        public string Uid { get; set; } = Guid.NewGuid().ToString();

        [JsonProperty("amount")]
        public uint Amount { get; set; }
        
        [JsonProperty("items")]
        public OrderItem[]? Items { get; set; }
    }
}