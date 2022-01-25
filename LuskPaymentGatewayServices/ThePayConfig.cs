namespace LuskPaymentGatewayServices
{
    public class ThePayConfig
    {
        public string MerchantId { get; set; } = null!;
        
        public int ProjectId { get; set; }
        
        public string PasswordApi { get; set; } = null!;
        
        public string ApiUrl { get; set; } = null!;
    }
}