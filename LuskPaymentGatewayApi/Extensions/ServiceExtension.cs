using System.Net.Http;
using LuskPaymentGatewayServices;
using LuskPaymentGatewayServices.Helpers;
using LuskPaymentGatewayServices.Services;
using LuskPaymentGatewayServices.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LuskPaymentGatewayApi.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddThePay(this IServiceCollection services, IConfigurationSection thePayConfigSection)
        {
            services.Configure<ThePayConfig>(thePayConfigSection);
            SignatureHelper.Password = thePayConfigSection["PasswordApi"];
            services.AddHttpClient<IPaymentClient, PaymentClient>().ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
            {
                AllowAutoRedirect = false
            });
            return services;
        }
    }
}