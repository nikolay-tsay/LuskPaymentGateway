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

        public async Task<GetPaymentMethodResponse[]> GetPaymentMethods(string language = "cs")
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

        public async Task<GetPaymentsResponse[]> GetPayments()//TODO finish request https://dataapi21.docs.apiary.io/#reference/0/project-level-resources/get-payments
        {
            var urlBuilder = GetBuilderWithProjectId();
            urlBuilder.Append("/payments");
            urlBuilder.Append(MerchantString);

            var request = CreateSignedRequest(HttpMethod.Get, urlBuilder.ToString());
            var response = await _client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<GetPaymentsResponse[]>(await response.Content.ReadAsStringAsync());
            }

            throw new Exception(response.ReasonPhrase);
        }

        public async Task<GetPaymentsResponse> GetPaymentDetail(string uid)
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

        public async Task<CreatePaymentResponse> CreateNewPayment(CreatePaymentRequest request)
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
            if (response.IsSuccessStatusCode)
            {
                return;
            }

            throw new Exception($"{response.ReasonPhrase} : {await response.Content.ReadAsStringAsync()}");
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
    }
}