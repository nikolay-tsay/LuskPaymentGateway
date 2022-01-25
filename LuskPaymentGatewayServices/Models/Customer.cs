using Newtonsoft.Json;

namespace LuskPaymentGatewayServices.Models
{
    public class Customer
    {
        [JsonProperty("name")]
        public string Name { get; set; } = null!;
        
        [JsonProperty("surname")]
        public string Surname { get; set; } = null!;
        
        [JsonProperty("email")]
        public string Email { get; set; } = null!;
        
        [JsonProperty("phone")]
        public string? Phone { get; set; }

        [JsonProperty("billing_address")]
        public BillingAddress BillingAddress { get; set; } = null!;
    }
}