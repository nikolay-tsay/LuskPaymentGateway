using LuskPaymentGatewayServices.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace LuskPaymentGatewayServices.Models.Requests
{
    public class ChangePaymentMethodRequest
    {
        [JsonProperty("payment_method_code")]
        [JsonConverter(typeof(StringEnumConverter))]
        public PaymentMethodCode PaymentMethodCode { get; set; }
    }
}