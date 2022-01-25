using LuskPaymentGatewayServices.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace LuskPaymentGatewayServices.Models.Responses
{
    public class PaymentRefundResponse
    {
        [JsonProperty("available_amount")]
        public int AvailableAmount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; } = null!;

        [JsonProperty("partial_refunds")]
        public PartialRefund[] PartialRefunds { get; set; } = null!;
    }

    public class PartialRefund
    {
        [JsonProperty("amount")] 
        public uint Amount { get; set; }

        [JsonProperty("reason")]
        public string Reason { get; set; } = null!;

        [JsonProperty("state")]
        [JsonConverter(typeof(StringEnumConverter))]
        public RefundState State { get; set; }
    }
}