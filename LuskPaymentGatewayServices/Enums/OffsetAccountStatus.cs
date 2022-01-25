using System.Runtime.Serialization;

namespace LuskPaymentGatewayServices.Enums
{
    public enum OffsetAccountStatus
    {
        [EnumMember(Value = @"not_available")]
        NotAvailable, 
        [EnumMember(Value = @"waiting")]
        Waiting, 
        [EnumMember(Value = @"loaded")]
        Loaded
    }
}