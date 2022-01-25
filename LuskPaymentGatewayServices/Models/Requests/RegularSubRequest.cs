using System;
using Newtonsoft.Json;

namespace LuskPaymentGatewayServices.Models.Requests
{
    public class RegularSubRequest
    {
        [JsonProperty("payment_uid")]
        public string Uid { get; set; } = Guid.NewGuid().ToString();

        [JsonProperty("items")]
        public OrderItem[]? Items { get; set; }
    }
}