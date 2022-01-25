using Newtonsoft.Json;

namespace LuskPaymentGatewayServices.Models
{
    public class ImageModel
    {
        [JsonProperty("src")]
        public string Src { get; set; } = null!;
    }
}