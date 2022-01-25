using System.Runtime.Serialization;

namespace LuskPaymentGatewayServices.Enums
{
    public enum RecurringPaymentResponseStates
    {
        [EnumMember(Value = @"success")]
        Success,
        [EnumMember(Value = @"failed")]
        Failed,
        [EnumMember(Value = @"expired")]
        Expired
    }
}