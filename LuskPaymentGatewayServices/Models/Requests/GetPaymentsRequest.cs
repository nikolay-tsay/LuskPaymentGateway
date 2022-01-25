using System;
using LuskPaymentGatewayServices.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace LuskPaymentGatewayServices.Models.Requests
{
    public class GetPaymentsRequest
    {
        [JsonProperty("limit")] 
        public uint Limit { get; set; }

        [JsonProperty("page")]
        public uint Page { get; set; }

        [JsonProperty("state")]
        [JsonConverter(typeof(StringEnumConverter))]
        public PaymentStates? State { get; set; }

        [JsonProperty("currency")]
        public string? Currency { get; set; }

        [JsonProperty("amount_from")]
        public uint AmountFrom { get; set; }

        [JsonProperty("amount_to")]
        public uint AmountTo { get; set; }

        [JsonProperty("created_from")]
        public DateTime? CreatedFrom { get; set; }
        
        [JsonProperty("created_To")]
        public DateTime? CreatedTo { get; set; }
        
        [JsonProperty("finished_from")]
        public DateTime? FinishedFrom { get; set; }
        
        [JsonProperty("finished_To")]
        public DateTime? FinishedTo { get; set; }

        [JsonProperty("payment_method")]
        [JsonConverter(typeof(StringEnumConverter))]
        public PaymentMethodCode? PaymentMethod { get; set; }
    }
}