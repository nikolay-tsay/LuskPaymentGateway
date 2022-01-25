using System.Runtime.Serialization;

namespace LuskPaymentGatewayServices.Enums
{
    public enum NotificationTypes
    {
        [EnumMember(Value = @"state_changed")]
        StateChanged,
        [EnumMember(Value = @"offset_account_obtained")]
        OffsetAccountObtained
    }
}