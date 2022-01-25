using LuskPaymentGatewayServices.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace LuskPaymentGatewayServices.Models.Responses
{
    public class GetPaymentMethodResponse
    {
        [JsonProperty("code")]
        [JsonConverter(typeof(StringEnumConverter))]
        public PaymentMethodCode Code { get; set; }
        
        [JsonProperty("title")]
        public string Title { get; set; } = null!;
        
        [JsonProperty("tags")]
        [JsonConverter(typeof(StringEnumConverter))]
        public PaymentMethodTag[]? Tags { get; set; }

        [JsonProperty("available_currencies")] 
        public CurrencyModel[]? AvailableCurrencies { get; set; }
        
        [JsonProperty("image")]
        public ImageModel? Image { get; set; }
    }
}