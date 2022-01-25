using System.Runtime.Serialization;

namespace LuskPaymentGatewayServices.Enums
{
    public enum EventType
    { 
        [EnumMember(Value = @"method_selection")]
        MethodSelection,
        [EnumMember(Value = @"state_change")]
        StateChange,
        [EnumMember(Value = @"unavailable_method")]
        UnavailableMethod,
        [EnumMember(Value = @"payment_cancelled")]
        PaymentCancelled,
        [EnumMember(Value = @"payment_error")]
        PaymentError
    }
}