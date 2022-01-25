using LuskPaymentGatewayServices.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace LuskPaymentGatewayServices.Models.Responses
{
    public class GetPaymentsResponse
    {
        public string Uid { get; set; } = null!;
        
        [JsonProperty("project_id")]
        public string? ProjectId { get; set; }
        
        [JsonProperty("order_id")]
        public string? OrderId { get; set; }

        [JsonProperty("state")]
        [JsonConverter(typeof(StringEnumConverter))]
        public PaymentStates State { get; set; }
        
        [JsonProperty("currency")] 
        public string Currency { get; set; } = null!;
        
        [JsonProperty("amount")] 
        public int Amount { get; set; }

        [JsonProperty("created_at")] 
        public string? CreatedAt{ get; set; }
        
        [JsonProperty("finished_at")] 
        public string? FinishedAt{ get; set; }
        
        [JsonProperty("valid_to")] 
        public string? ValidTo{ get; set; }

        [JsonProperty("fee")]
        public int Fee { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }
        
        [JsonProperty("payment_method")]
        [JsonConverter(typeof(StringEnumConverter))]
        public PaymentMethodCode? PaymentMethod { get; set; }

        [JsonProperty("pay_url")] 
        public string PayUrl { get; set; } = null!;
        
        [JsonProperty("detail_url")] 
        public string DetailUrl { get; set; } = null!;

        [JsonProperty("customer")] 
        public SimpleCustomer? Customer { get; set; }

        [JsonProperty("offset_account")]
        public OffsetAccount? OffsetAccount { get; set; }

        [JsonProperty("offset_account_status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public OffsetAccountStatus OffsetAccountStatus { get; set; }

        [JsonProperty("card")] 
        public CardModel? Card { get; set; }

        [JsonProperty("events")] 
        public EventModel[] Events { get; set; } = null!;
    }

    public class EventModel
    {
        [JsonProperty("occured_at")] 
        public string OccuredAt { get; set; } = null!;

        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public EventType Type { get; set; }

        [JsonProperty("data")]
        public string? Data { get; set; }
    }
    
    public class CardModel
    {
        [JsonProperty("number")] 
        public string Number { get; set; } = null!;

        [JsonProperty("expiration_date")]
        public string ExpirationDate { get; set; } = null!;

        [JsonProperty("brand")]
        public string Brand { get; set; } = null!;
    }
    
    public class SimpleCustomer
    {
        [JsonProperty("name")]
        public string Name { get; set; } = null!;

        [JsonProperty("ip")]
        public string? Ip { get; set; }
        
        [JsonProperty("email")]
        public string Email { get; set; } = null!;
    }
}