using LuskPaymentGatewayServices.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace LuskPaymentGatewayServices.Models.Responses
{
    public class StateMessageResponse
    {
        [JsonProperty("state")]
        [JsonConverter(typeof(StringEnumConverter))]
        public RecurringPaymentResponseStates State { get; set; }

        [JsonProperty("message")]
        public string? Message { get; set; }
    }
}