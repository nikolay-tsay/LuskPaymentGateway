using Newtonsoft.Json;

namespace LuskPaymentGatewayServices.Models
{
    public class BillingAddress
    {
        [JsonProperty("country_code")] 
        public string CountryCode { get; set; } = null!;
        
        [JsonProperty("city")] 
        public string City { get; set; } = null!;
        
        [JsonProperty("zip")] 
        public string Zip { get; set; } = null!;
        
        [JsonProperty("street")] 
        public string Street { get; set; } = null!;
    }
}