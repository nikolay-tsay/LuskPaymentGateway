using System.Runtime.Serialization;

namespace LuskPaymentGatewayServices.Enums
{
    public enum PaymentStates
    {
        [EnumMember(Value = @"expired")]
        Expired, 
        [EnumMember(Value = @"paid")]
        Paid, 
        [EnumMember(Value = @"partially_refunded")]
        PartiallyRefunded,
        [EnumMember(Value = @"refunded")]
        Refunded, 
        [EnumMember(Value = @"preauthorized")]
        Preauthorized,
        [EnumMember(Value = @"preauth_cancelled")]
        PreauthCancelled, 
        [EnumMember(Value = @"preauth_expired")]
        PreauthExpired,
        [EnumMember(Value = @"waiting_for_payment")]
        WaitingForPayment, 
        [EnumMember(Value = @"waiting_for_confirmation")]
        WaitingForConfirmation 
    }
}