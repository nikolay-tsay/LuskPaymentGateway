using Newtonsoft.Json;

namespace LuskPaymentGatewayServices.Models
{
    public class CurrencyModel
    {
        [JsonProperty("code")] 
        public string Code { get; set; } = null!;

        [JsonProperty("numeric_code")] 
        public string NumericCode { get; set; } = null!;
    }
}