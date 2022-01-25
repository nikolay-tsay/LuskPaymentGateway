using System;
using Newtonsoft.Json;

namespace LuskPaymentGatewayServices.Models.Requests
{
    public class RealizeBySavedAuthRequest
    {
        [JsonProperty("payment_uid")]
        public string Uid { get; set; } = Guid.NewGuid().ToString();

        [JsonProperty("value")]
        public PriceModel? Price { get; set; }
        
        [JsonProperty("items")]
        public OrderItem[]? Items { get; set; }
    }

    public class PriceModel
    {
        [JsonProperty("amount")] 
        public uint Amount { get; set; }
        
        [JsonProperty("currency")] 
        public string Currency { get; set; } = null!;
    }
}