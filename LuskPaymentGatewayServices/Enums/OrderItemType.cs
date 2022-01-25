namespace LuskPaymentGatewayServices.Enums
{
    public enum OrderItemType
    {
        [System.Runtime.Serialization.EnumMember(Value = @"item")]
        Item = 1,
        [System.Runtime.Serialization.EnumMember(Value = @"delivery")]
        Delivery = 2,
        [System.Runtime.Serialization.EnumMember(Value = @"discount")]
        Discount = 3
    }
}