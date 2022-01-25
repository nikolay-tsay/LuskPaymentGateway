namespace LuskPaymentGatewayServices.Enums
{
    public enum SubscriptionType
    {
        [System.Runtime.Serialization.EnumMember(Value = @"regular")]
        Regular,
        [System.Runtime.Serialization.EnumMember(Value = @"usagebased")]
        Usagebased,
        [System.Runtime.Serialization.EnumMember(Value = @"irregular")]
        Irregular
    }
}