using Newtonsoft.Json;

namespace LuskPaymentGatewayServices.Models.Requests
{
    public class RealizePreauthPaymentRequest
    {
        [JsonProperty("amount")]
        public int Amount { get; set; }
    }
}