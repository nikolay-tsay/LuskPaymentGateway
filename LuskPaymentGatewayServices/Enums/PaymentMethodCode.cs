using System.Runtime.Serialization;

namespace LuskPaymentGatewayServices.Enums
{
    public enum PaymentMethodCode
    {
        [EnumMember(Value = @"card")]
        Card,
        [EnumMember(Value = @"transfer")]
        Transfer,
        [EnumMember(Value = @"platba_24")]
        Platba24,
        [EnumMember(Value = @"ekonto")]
        Ekonto,
        [EnumMember(Value = @"uni_credit")]
        UniCredit,
        [EnumMember(Value = @"bitcoin")]
        Bitcoin,
        [EnumMember(Value = @"csob")]
        Csob,
        [EnumMember(Value = @"equa_bank")]
        EquaBank,
        [EnumMember(Value = @"fio_banka")]
        FioBanka,
        [EnumMember(Value = @"mojeplatba")]
        MojePlatba,
        [EnumMember(Value = @"moneta")]
        Moneta,
        [EnumMember(Value = @"mbank")]
        Mbank,
        [EnumMember(Value = @"postovni_sporitelna")]
        PostovniSporitelna,
        [EnumMember(Value = @"platimpak")]
        PlatimPak
    }
}