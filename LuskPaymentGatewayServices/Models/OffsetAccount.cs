using Newtonsoft.Json;

namespace LuskPaymentGatewayServices.Models
{
    public class OffsetAccount
    {
        [JsonProperty("iban")]
        public string Iban { get; set; } = null!;

        [JsonProperty("owner_name")]
        public string OwnerName { get; set; } = null!;
    }
}