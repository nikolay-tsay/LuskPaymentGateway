using System.Threading.Tasks;
using LuskPaymentGatewayServices.Models.Requests;
using LuskPaymentGatewayServices.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LuskPaymentGatewayApi.Controllers
{
    [ApiController]
    [Route("gateway/payments")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentClient _paymentClient;
        public PaymentController(IPaymentClient paymentClient)
        {
            _paymentClient = paymentClient;
        }

        [HttpGet]
        [Route("/methods")]
        public async Task<IActionResult> GetPaymentMethods()
        {
            var response = await _paymentClient.GetPaymentMethods();
            return Ok(response);
        }
        
        [HttpGet]
        public async Task<IActionResult> GetPayments()
        {
            var response = await _paymentClient.GetPayments();
            return Ok(response);
        }
        
        [HttpGet]
        [Route("/{uid}")]
        public async Task<IActionResult> GetPaymentDetail([FromRoute]string uid )
        {
            var response = await _paymentClient.GetPaymentDetail(uid);
            return Ok(response);
        }
        
        [HttpPost]
        public async Task<IActionResult> CreatePayment([FromBody] CreatePaymentRequest body)
        {
            var response = await _paymentClient.CreateNewPayment(body);
            return Ok(response);
        }
    }
}