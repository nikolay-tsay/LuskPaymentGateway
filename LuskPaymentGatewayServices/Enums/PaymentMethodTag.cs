using System.Runtime.Serialization;

namespace LuskPaymentGatewayServices.Enums
{
    public enum PaymentMethodTag
    {
        [EnumMember(Value = @"returnable")]
        Returnable, 
        [EnumMember(Value = @"pre_authorization")]
        PreAuthorization, 
        [EnumMember(Value = @"recurring_payments")]
        RecurringPayments, 
        [EnumMember(Value = @"access_account_owner")]
        AccessAccountOwner, 
        [EnumMember(Value = @"online")]
        Online, 
        [EnumMember(Value = @"card")]
        Card, 
        [EnumMember(Value = @"bank_transfer")]
        BankTransfer, 
        [EnumMember(Value = @"alternative_method")]
        AlternativeMethod,
        [EnumMember(Value = @"deferred_payment")]
        DeferredPayment
    }
}