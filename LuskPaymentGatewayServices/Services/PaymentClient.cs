using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using LuskPaymentGatewayServices.Helpers;
using LuskPaymentGatewayServices.Models.Requests;
using LuskPaymentGatewayServices.Models.Responses;
using LuskPaymentGatewayServices.Services.Interfaces;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace LuskPaymentGatewayServices.Services
{
    public class PaymentClient : IPaymentClient
    {
        private readonly HttpClient _client;
        private readonly IOptionsMonitor<ThePayConfig> _config;
        private string MerchantString => $"?merchant_id={_config.CurrentValue.MerchantId}";

        public PaymentClient(HttpClient client, IOptionsMonitor<ThePayConfig> config)
        {
            _client = client;
            _config = config;
        }

        public async Task<GetPaymentMethodResponse[]?> GetPaymentMethods(string language = "cs")
        {
            var urlBuilder = GetBuilderWithProjectId();
            urlBuilder.Append("/methods");
            urlBuilder.Append(MerchantString);

            var request = CreateSignedRequest(HttpMethod.Get, urlBuilder.ToString());
            var response = await _client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<GetPaymentMethodResponse[]>(await response.Content.ReadAsStringAsync());
            }

            throw new Exception(response.ReasonPhrase);
        }

        public async Task<GetPaymentsResponse[]?> GetPayments(GetPaymentsRequest parameters)
        {
            var urlBuilder = GetBuilderWithProjectId();
            urlBuilder.Append("/payments");
            urlBuilder.Append(MerchantString);
            urlBuilder = InsertParemeters(urlBuilder, parameters);            

            var request = CreateSignedRequest(HttpMethod.Get, urlBuilder.ToString());
            var response = await _client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<GetPaymentsResponse[]>(await response.Content.ReadAsStringAsync());
            }

            throw new Exception(response.ReasonPhrase);
        }

        public async Task<GetPaymentsResponse?> GetPaymentDetail(string uid)
        {
            var urlBuilder = GetBuilderWithProjectId();
            urlBuilder.Append("/payments");
            urlBuilder.Append($"/{uid}");
            urlBuilder.Append(MerchantString);
            
            var request = CreateSignedRequest(HttpMethod.Get, urlBuilder.ToString());
            var response = await _client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<GetPaymentsResponse>(await response.Content.ReadAsStringAsync());
            }

            throw new Exception(response.ReasonPhrase);
        }

        public async Task ChangePaymentMethod(string uid, ChangePaymentMethodRequest request)
        {
            var urlBuilder = GetBuilderWithProjectId();
            urlBuilder.Append("/payments");
            urlBuilder.Append($"/{uid}/method");
            urlBuilder.Append(MerchantString);

            var signedRequest = CreateSignedRequest(HttpMethod.Put, urlBuilder.ToString());
            var serialized = JsonConvert.SerializeObject(request);
            signedRequest.Content = new StringContent(serialized, Encoding.UTF8, "application/json");

            var response = await _client.SendAsync(signedRequest);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"{response.ReasonPhrase} : {await response.Content.ReadAsStringAsync()}");
            }
        }

        public async Task InvalidatePayment(string uid)
        {
            var urlBuilder = GetBuilderWithProjectId();
            urlBuilder.Append("/payments");
            urlBuilder.Append($"/{uid}/invalidate");
            urlBuilder.Append(MerchantString);
            
            var request = CreateSignedRequest(HttpMethod.Put, urlBuilder.ToString());
            var response = await _client.SendAsync(request);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"{response.ReasonPhrase} : {await response.Content.ReadAsStringAsync()}");
            }
        }

        public async Task<CreatePaymentResponse?> CreateNewPayment(CreatePaymentRequest request)
        {
            var urlBuilder = GetBuilderWithProjectId();
            urlBuilder.Append("/payments");
            urlBuilder.Append(MerchantString);

            var signedRequest = CreateSignedRequest(HttpMethod.Post, urlBuilder.ToString());
            var serialized = JsonConvert.SerializeObject(request);
            signedRequest.Content = new StringContent(serialized, Encoding.UTF8, "application/json");

            var response = await _client.SendAsync(signedRequest);
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<CreatePaymentResponse>(await response.Content.ReadAsStringAsync());
            }

            throw new Exception($"{response.ReasonPhrase} : {await response.Content.ReadAsStringAsync()}");
        }

        public async Task RealizePreauthPayment(string uid, RealizePreauthPaymentRequest request)
        {
            var urlBuilder = GetBuilderWithProjectId();
            urlBuilder.Append("/payments");
            urlBuilder.Append($"/{uid}/preauthorized");
            urlBuilder.Append(MerchantString);
            
            var signedRequest = CreateSignedRequest(HttpMethod.Post, urlBuilder.ToString());
            var serialized = JsonConvert.SerializeObject(request);
            signedRequest.Content = new StringContent(serialized, Encoding.UTF8, "application/json");

            var response = await _client.SendAsync(signedRequest);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"{response.ReasonPhrase} : {await response.Content.ReadAsStringAsync()}");
            }
        }

        public async Task CancelPreauthPayment(string uid)
        {
            var urlBuilder = GetBuilderWithProjectId();
            urlBuilder.Append("/payments");
            urlBuilder.Append($"/{uid}/preauthorized");
            urlBuilder.Append(MerchantString);
            
            var request = CreateSignedRequest(HttpMethod.Delete, urlBuilder.ToString());
            var response = await _client.SendAsync(request);
            
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"{response.ReasonPhrase} : {await response.Content.ReadAsStringAsync()}");
            }
        }

        public async Task<StateMessageResponse?> RealizeRegularSubPayment(string parentId, RegularSubRequest request)
        {
            var urlBuilder = GetBuilderWithProjectId();
            urlBuilder.Append("/payments");
            urlBuilder.Append($"/{parentId}/subscription/regular");
            urlBuilder.Append(MerchantString);
            
            var signedRequest = CreateSignedRequest(HttpMethod.Post, urlBuilder.ToString());
            var serialized = JsonConvert.SerializeObject(request);
            signedRequest.Content = new StringContent(serialized, Encoding.UTF8, "application/json");

            var response = await _client.SendAsync(signedRequest);
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<StateMessageResponse>(await response.Content.ReadAsStringAsync());
            }

            throw new Exception($"{response.ReasonPhrase} : {await response.Content.ReadAsStringAsync()}");
        }

        public async Task<StateMessageResponse?> RealizeUsageBasedSubPayment(string parentId, UsageBasedRequest request)
        {
            var urlBuilder = GetBuilderWithProjectId();
            urlBuilder.Append("/payments");
            urlBuilder.Append($"/{parentId}/subscription/usagebased");
            urlBuilder.Append(MerchantString);
            
            var signedRequest = CreateSignedRequest(HttpMethod.Post, urlBuilder.ToString());
            var serialized = JsonConvert.SerializeObject(request);
            signedRequest.Content = new StringContent(serialized, Encoding.UTF8, "application/json");

            var response = await _client.SendAsync(signedRequest);
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<StateMessageResponse>(await response.Content.ReadAsStringAsync());
            }

            throw new Exception($"{response.ReasonPhrase} : {await response.Content.ReadAsStringAsync()}");
        }

        public async Task<StateMessageResponse?> RealizeIrregularSubPayment(string parentId, IrregularSubRequest request)
        {
            var urlBuilder = GetBuilderWithProjectId();
            urlBuilder.Append("/payments");
            urlBuilder.Append($"/{parentId}/subscription/irregular");
            urlBuilder.Append(MerchantString);
            
            var signedRequest = CreateSignedRequest(HttpMethod.Post, urlBuilder.ToString());
            var serialized = JsonConvert.SerializeObject(request);
            signedRequest.Content = new StringContent(serialized, Encoding.UTF8, "application/json");

            var response = await _client.SendAsync(signedRequest);
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<StateMessageResponse>(await response.Content.ReadAsStringAsync());
            }

            throw new Exception($"{response.ReasonPhrase} : {await response.Content.ReadAsStringAsync()}");
        }

        public async Task<StateMessageResponse?> RealizePaymentBySavedAuth(string parentId, RealizeBySavedAuthRequest request)
        {
            var urlBuilder = GetBuilderWithProjectId();
            urlBuilder.Append("/payments");
            urlBuilder.Append($"/{parentId}/savedauthorization");
            urlBuilder.Append(MerchantString);
            
            var signedRequest = CreateSignedRequest(HttpMethod.Post, urlBuilder.ToString());
            var serialized = JsonConvert.SerializeObject(request);
            signedRequest.Content = new StringContent(serialized, Encoding.UTF8, "application/json");

            var response = await _client.SendAsync(signedRequest);
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<StateMessageResponse>(await response.Content.ReadAsStringAsync());
            }

            throw new Exception($"{response.ReasonPhrase} : {await response.Content.ReadAsStringAsync()}");
        }

        public async Task<PaymentRefundResponse?> GetPaymentRefundInfo(string uid)
        {
            var urlBuilder = GetBuilderWithProjectId();
            urlBuilder.Append("/payments");
            urlBuilder.Append($"/{uid}/refund");
            urlBuilder.Append(MerchantString);
            
            var request = CreateSignedRequest(HttpMethod.Get, urlBuilder.ToString());
            var response = await _client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<PaymentRefundResponse>(await response.Content.ReadAsStringAsync());
            }

            throw new Exception($"{response.ReasonPhrase} : {await response.Content.ReadAsStringAsync()}");
        }

        public async Task RequestRefund(string uid, PaymentRefundRequest request)
        {
            var urlBuilder = GetBuilderWithProjectId();
            urlBuilder.Append("/payments");
            urlBuilder.Append($"/{uid}/refund");
            urlBuilder.Append(MerchantString);
            
            var signedRequest = CreateSignedRequest(HttpMethod.Post, urlBuilder.ToString());
            var serialized = JsonConvert.SerializeObject(request);
            signedRequest.Content = new StringContent(serialized, Encoding.UTF8, "application/json");
            
            var response = await _client.SendAsync(signedRequest);
            
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"{response.ReasonPhrase} : {await response.Content.ReadAsStringAsync()}");
            }
        }

        private StringBuilder GetBuilderWithProjectId()
        {
            var result = new StringBuilder(_config.CurrentValue.ApiUrl);
            result.Append($"projects/{_config.CurrentValue.ProjectId}");
            return result;
        }
        
        private HttpRequestMessage CreateSignedRequest(HttpMethod method, string url)
        {
            var request = new HttpRequestMessage(method, url);
            AddSignature(request);
            return request;
        }
        
        private void AddSignature(HttpRequestMessage request)
        {
            var now = $"{DateTime.UtcNow:R}";
            request.Headers.Add("Signature", SignatureHelper.GetHashSha256($"{_config.CurrentValue.MerchantId}{_config.CurrentValue.PasswordApi}{now}"));
            request.Headers.Add("SignatureDate", now);
        }
        
        private StringBuilder InsertParemeters(StringBuilder request, GetPaymentsRequest parameters)
        {
            if (parameters.Limit != 0 && parameters.Limit != 25)
            {
                request.Append($"&limit={parameters.Limit}");
            }

            if (parameters.Page > 1)
            {
                request.Append($"&page={parameters.Page}");
            }

            if (parameters.State != null)
            {
                request.Append($"&state={parameters.State}");
            }

            if (string.IsNullOrEmpty(parameters.Currency))
            {
                request.Append($"&currency={parameters.Currency}");
            }

            if (parameters.AmountFrom > 0)
            {
                request.Append($"&amount_from={parameters.AmountFrom}");
            }

            if (parameters.AmountTo > 0)
            {
                request.Append($"&amount_to={parameters.AmountTo}");
            }

            if (parameters.CreatedFrom != null)
            {
                request.Append($"&created_from={parameters.CreatedFrom}");
            }

            if (parameters.CreatedTo != null)
            {
                request.Append($"&created_to={parameters.CreatedTo}");
            }

            if (parameters.FinishedFrom != null)
            {
                request.Append($"&finished_from={parameters.FinishedFrom}");
            }

            if (parameters.FinishedTo != null)
            {
                request.Append($"&finished_to={parameters.FinishedTo}");
            }

            if (parameters.PaymentMethod != null)
            {
                request.Append($"&payment_method={parameters.PaymentMethod}");
            }
            
            return request;
        }
    }
}