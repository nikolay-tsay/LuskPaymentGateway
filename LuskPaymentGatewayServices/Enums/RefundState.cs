using System.Runtime.Serialization;

namespace LuskPaymentGatewayServices.Enums
{
    public enum RefundState
    {
        [EnumMember(Value = @"waiting")]
        Waiting,
        [EnumMember(Value = @"returned")]
        Returned,
        [EnumMember(Value = @"declined")]
        Declined,
    }
}