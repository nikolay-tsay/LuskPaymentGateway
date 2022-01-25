using System.Threading.Tasks;
using LuskPaymentGatewayServices.Models.Requests;
using LuskPaymentGatewayServices.Models.Responses;

namespace LuskPaymentGatewayServices.Services.Interfaces
{
    public interface IPaymentClient
    {
        Task<GetPaymentMethodResponse[]?> GetPaymentMethods(string language ="cs");

        Task<GetPaymentsResponse[]?> GetPayments(GetPaymentsRequest parameters);

        Task<GetPaymentsResponse?> GetPaymentDetail(string uid);

        Task ChangePaymentMethod(string uid, ChangePaymentMethodRequest request);

        Task InvalidatePayment(string uid);

        Task<CreatePaymentResponse?> CreateNewPayment(CreatePaymentRequest request);

        Task RealizePreauthPayment(string uid, RealizePreauthPaymentRequest request);
        
        Task CancelPreauthPayment(string uid);

        Task<StateMessageResponse?> RealizeRegularSubPayment(string parentId, RegularSubRequest request);
        
        Task<StateMessageResponse?> RealizeUsageBasedSubPayment(string parentId, UsageBasedRequest request);
        
        Task<StateMessageResponse?> RealizeIrregularSubPayment(string parentId, IrregularSubRequest request);
        
        Task<StateMessageResponse?> RealizePaymentBySavedAuth(string parentId, RealizeBySavedAuthRequest request);

        Task<PaymentRefundResponse?> GetPaymentRefundInfo(string uid);

        Task RequestRefund(string uid, PaymentRefundRequest request);
    }
}