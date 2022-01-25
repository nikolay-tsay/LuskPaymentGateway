using Newtonsoft.Json;

namespace LuskPaymentGatewayServices.Models.Requests
{
    public class PaymentRefundRequest
    {
        [JsonProperty("amount")] 
        public uint Amount { get; set; }
        
        [JsonProperty("reason")]
        public string Reason { get; set; } = null!;
    }
}