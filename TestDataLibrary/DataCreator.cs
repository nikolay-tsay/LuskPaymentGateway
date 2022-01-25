using System;
using System.Globalization;
using System.IO;
using LuskPaymentGatewayServices.Enums;
using LuskPaymentGatewayServices.Models;
using LuskPaymentGatewayServices.Models.Requests;
using Newtonsoft.Json;

namespace TestDataLibrary
{
    public class DataCreator : IDataCreator
    {
        public void CreateTestPaymentRequest()
        {
            var request1 = new CreatePaymentRequest()
            {
                IsDeposit = true,
                CustomerMethodChange = true,
                PaymentMethodCode = PaymentMethodCode.Card,
                Amount = 876545,
                CurrencyCode = "CZK",
                Uid = Guid.NewGuid().ToString(),
                OrderId = "TEST3",
                DescriptionForCustomer = "Test customer message",
                DescriptionForMerchant = "Test merchant message",
                ReturnUrl = "https://example.com",
                NotifUrl = "https://example.com",
                NotifEnabled = false,
                ValidTo = DateTime.Now.AddDays(30).ToString("yyyy-MM-dd'T'HH:mm:ssK", DateTimeFormatInfo.InvariantInfo),
                SaveAuth = false,
                LanguageCode = "cs",
                Customer = new Customer
                {
                   Name = "Jane",
                   Surname = "Doe",
                   Email = "jane.doe@gmail.com",
                   Phone = "420589687963",
                   BillingAddress = new BillingAddress
                   {
                       CountryCode = "GB",
                       City = "London",
                       Zip = "NW1",
                       Street = "Baker Street 221B"
                   }
                },
                Items = new []
                {
                    new OrderItem
                    {
                        Type = OrderItemType.Item,
                        Name = "Item1",
                        Count = 2,
                        TotalPrice = 10000,
                        Ean = null
                    },
                    new OrderItem
                    {
                        Type = OrderItemType.Delivery,
                        Name = "Item2",
                        Count = 1,
                        TotalPrice = 4500,
                        Ean = null
                    },
                    new OrderItem
                    {
                        Type = OrderItemType.Discount,
                        Name = "Item3",
                        Count = 5,
                        TotalPrice = 45000,
                        Ean = null
                    }
                },
                Subscription = null
            };

            var request2 = new CreatePaymentRequest()
            {
                IsDeposit = true,
                CustomerMethodChange = true,
                PaymentMethodCode = PaymentMethodCode.Platba24,
                Amount = 250000,
                CurrencyCode = "EUR",
                Uid = Guid.NewGuid().ToString(),
                OrderId = "TEST4",
                DescriptionForCustomer = "Test customer message 2",
                DescriptionForMerchant = "Test merchant message 2",
                ReturnUrl = "https://example.com",
                NotifUrl = "https://example.com",
                NotifEnabled = false,
                ValidTo = DateTime.Now.AddDays(30).ToString("yyyy-MM-dd'T'HH:mm:ssK", DateTimeFormatInfo.InvariantInfo),
                SaveAuth = false,
                LanguageCode = "cs",
                Customer = new Customer
                {
                   Name = "Jane",
                   Surname = "Doe",
                   Email = "jane.doe@gmail.com",
                   Phone = "420589687963",
                   BillingAddress = new BillingAddress
                   {
                       CountryCode = "GB",
                       City = "London",
                       Zip = "NW1",
                       Street = "Baker Street 221B"
                   }
                },
                Items = new []
                {
                    new OrderItem
                    {
                        Type = OrderItemType.Item,
                        Name = "Item1",
                        Count = 2,
                        TotalPrice = 20000,
                        Ean = null
                    },
                    new OrderItem
                    {
                        Type = OrderItemType.Discount,
                        Name = "Item2",
                        Count = 5,
                        TotalPrice = 45000,
                        Ean = null
                    }
                },
                Subscription = new Subscription()
                {
                    Type = SubscriptionType.Regular,
                    Period = 30
                }
            };
            
             var request3 = new CreatePaymentRequest()
            {
                IsDeposit = true,
                CustomerMethodChange = true,
                PaymentMethodCode = PaymentMethodCode.Card,
                Amount = 10,
                CurrencyCode = "USD",
                Uid = Guid.NewGuid().ToString(),
                OrderId = "TEST5",
                DescriptionForCustomer = "Test customer message 3",
                DescriptionForMerchant = "Test merchant message 3",
                ReturnUrl = "https://example.com",
                NotifUrl = "https://example.com",
                NotifEnabled = true,
                ValidTo = DateTime.Now.AddDays(30).ToString("yyyy-MM-dd'T'HH:mm:ssK", DateTimeFormatInfo.InvariantInfo),
                SaveAuth = true,
                LanguageCode = "cs",
                Customer = new Customer
                {
                   Name = "Nikolay",
                   Surname = "Tsay",
                   Email = "nikolay.tsay@metait.cz",
                   Phone = "420589687963",
                   BillingAddress = new BillingAddress
                   {
                       CountryCode = "GB",
                       City = "London",
                       Zip = "NW1",
                       Street = "Baker Street 221B"
                   }
                },
                Items = new []
                {
                    new OrderItem
                    {
                        Type = OrderItemType.Item,
                        Name = "Item1",
                        Count = 2,
                        TotalPrice = 20000,
                        Ean = null
                    },
                    new OrderItem
                    {
                        Type = OrderItemType.Discount,
                        Name = "Item2",
                        Count = 5,
                        TotalPrice = 45000,
                        Ean = null
                    }
                },
                Subscription = new Subscription()
                {
                    Type = SubscriptionType.Regular,
                    Period = 14
                }
            };
            SerializeTestData(request1, 1);
            SerializeTestData(request2, 2);
            SerializeTestData(request3, 3);
        }

        private static void SerializeTestData(CreatePaymentRequest request, int num)
        {
            var fileName = $"C:\\Users\\tsayn\\Desktop\\All\\Projects\\DataTest\\test_request{num}.json"; 
            var jsonString = JsonConvert.SerializeObject(request);
            File.WriteAllText(fileName, jsonString);
        }
    }
}