using LuskPaymentGatewayServices.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace LuskPaymentGatewayServices.Models.Requests
{
    public class CreatePaymentRequest
    {
        //If set to false the payment will be created as "pre-authorization" and can be realised later using
        //the "Realize Preauthorized Payment" endpoint.
        //After preauthorizing of payment, a period of 7 days to realise the pre-authorized payment starts.
        [JsonProperty("is_deposit")] 
        public bool IsDeposit { get; set; } = true;

        [JsonProperty("can_customer_change_method")] 
        public bool CustomerMethodChange { get; set; } = true;
        
        [JsonProperty("payment_method_code")]
        [JsonConverter(typeof(StringEnumConverter))]
        public PaymentMethodCode PaymentMethodCode { get; set; }

        [JsonProperty("amount")] 
        public int Amount { get; set; }

        [JsonProperty("currency_code")] 
        public string CurrencyCode { get; set; } = null!;

        [JsonProperty("uid")] 
        public string Uid { get; set; } = null!;
        
        [JsonProperty("order_id")]
        public string? OrderId { get; set; }
        
        [JsonProperty("description_for_customer")]
        public string? DescriptionForCustomer { get; set; }
        
        [JsonProperty("description_for_merchant")]
        public string? DescriptionForMerchant { get; set; }
        
        [JsonProperty("return_url")]
        public string? ReturnUrl { get; set; }
        
        [JsonProperty("notif_url")]
        public string? NotifUrl { get; set; }

        [JsonProperty("is_customer_notification_enabled")]
        public bool NotifEnabled { get; set; }
        
        [JsonProperty("valid_to")]
        public string? ValidTo { get; set; }
        
        [JsonProperty("save_authorization")]
        public bool SaveAuth { get; set; }

        [JsonProperty("language_code")]
        public string LanguageCode { get; set; } = null!;

        [JsonProperty("customer")]
        public Customer Customer { get; set; } = null!;

        [JsonProperty("items")]
        public OrderItem[] Items { get; set; } = null!;

        [JsonProperty("subscription")]
        public Subscription? Subscription { get; set; }
    }
}