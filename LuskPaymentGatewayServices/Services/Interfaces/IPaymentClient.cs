using System.Threading.Tasks;
using LuskPaymentGatewayServices.Models.Requests;
using LuskPaymentGatewayServices.Models.Responses;

namespace LuskPaymentGatewayServices.Services.Interfaces
{
    public interface IPaymentClient
    {
        Task<GetPaymentMethodResponse[]> GetPaymentMethods(string language ="cs");

        Task<GetPaymentsResponse[]> GetPayments();

        Task<GetPaymentsResponse> GetPaymentDetail(string uid);

        Task<CreatePaymentResponse> CreateNewPayment(CreatePaymentRequest request);

        Task RealizePreauthPayment(string uid, RealizePreauthPaymentRequest request);
    }
}