using Newtonsoft.Json;

namespace LuskPaymentGatewayServices.Models.Responses
{
    public class CreatePaymentResponse
    {
        [JsonProperty("pay_url")]
        public string PayUrl { get; set; } = null!;
        
        [JsonProperty("detail_url")] 
        public string DetailUrl { get; set; } = null!;
    }
}