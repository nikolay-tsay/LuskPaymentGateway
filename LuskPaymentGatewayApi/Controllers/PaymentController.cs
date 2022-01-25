using System.Threading.Tasks;
using LuskPaymentGatewayServices.Models.Requests;
using LuskPaymentGatewayServices.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LuskPaymentGatewayApi.Controllers
{
    /// <summary>
    /// ThePay gateway controller
    /// </summary>
    [ApiController]
    [Route("api/payments")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentClient _paymentClient;

        /// <inheritdoc />
        public PaymentController(IPaymentClient paymentClient)
        {
            _paymentClient = paymentClient;
        }

        /// <summary>
        ///     Lists all available payment methods for your project.
        ///     Allowed methods settings can be changed in your ThePay merchant account.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("methods")]
        public async Task<IActionResult> GetPaymentMethods()
        {
            var response = await _paymentClient.GetPaymentMethods();
            return Ok(response);
        }

        /// <summary>
        ///     Returns a list of payments on a project.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("filtered")]
        public async Task<IActionResult> GetPayments([FromBody]GetPaymentsRequest parameters)
        {
            var response = await _paymentClient.GetPayments(parameters);
            return Ok(response);
        }

        /// <summary>
        ///     This resource represents one particular payment identified by its payment_uid.
        /// </summary>
        /// <param name="uid">UID of the payment</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{uid}")]
        public async Task<IActionResult> GetPaymentDetail([FromRoute] string uid)
        {
            var response = await _paymentClient.GetPaymentDetail(uid);
            return Ok(response);
        }

        /// <summary>
        ///     Creates new payment instance and returns URL to the payment process as well as URL to the payment detail page
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreatePayment([FromBody] CreatePaymentRequest request)
        {
            var response = await _paymentClient.CreateNewPayment(request);
            return Ok(response);
        }

        /// <summary>
        ///     This endpoint will change the current payment method, with which the payment can be paid.
        ///     Payment method change is available only for payments with state waiting_for_payment, described here.
        ///     The current payment state can be verified by calling the endpoint get payment detail.
        /// </summary>
        /// <param name="uid">UID of the payment</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{uid}/methods")]
        public async Task<IActionResult> ChangePaymentMethod([FromRoute] string uid,
            [FromBody] ChangePaymentMethodRequest request)
        {
            await _paymentClient.ChangePaymentMethod(uid, request);
            return Ok();
        }

        /// <summary>
        ///     This endpoint will invalidate a payment if it is in waiting_for_payment state.
        ///     Otherwise a bad request exception will be returned.
        /// </summary>
        /// <param name="uid">UID of the payment</param>
        /// <returns></returns>
        [HttpPut]
        [Route("{uid}/invalidate")]
        public async Task<IActionResult> InvalidatePayment([FromRoute] string uid)
        {
            await _paymentClient.InvalidatePayment(uid);
            return Ok();
        }

        /// <summary>
        ///     This endpoint will realize a preauthorized payment.
        /// </summary>
        /// <param name="uid">UID of the payment</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("{uid}/preauth")]
        public async Task<IActionResult> RealizePreauthPayment([FromRoute] string uid,
            [FromBody] RealizePreauthPaymentRequest request)
        {
            await _paymentClient.RealizePreauthPayment(uid, request);
            return Ok();
        }

        /// <summary>
        ///     This endpoint will cancel preauthorized payment.
        /// </summary>
        /// <param name="uid">UID of the payment</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{uid}/preauth")]
        public async Task<IActionResult> CancelPreauthPayment([FromRoute] string uid)
        {
            await _paymentClient.CancelPreauthPayment(uid);
            return Ok();
        }

        /// <summary>
        ///     This endpoint will realize new paid payment for the same subscription as its parent payment.
        ///     Through this endpoint, realization of subscription payment can be only done once per given period and payment
        ///     amount can't be changed.
        /// </summary>
        /// <param name="parentId">UID of payment which initialized this subscription.</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("{parentId}/subscription/regular")]
        public async Task<IActionResult> RealizeRegularSubPayment([FromRoute] string parentId,
            [FromBody] RegularSubRequest request)
        {
            var response = await _paymentClient.RealizeRegularSubPayment(parentId, request);
            return Ok(response);
        }

        /// <summary>
        ///     This endpoint will realize new paid payment for the same subscription as its parent payment
        ///     with changeable price for diferent amount of shipped products or provided services.
        ///     Through this endpoint, realization of subscription payment can be only done once per given period.
        /// </summary>
        /// <param name="parentId">UID of payment which initialized this subscription.</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("{parentId}/subscription/usagebased")]
        public async Task<IActionResult> RealizeUsageBasedSubPayment([FromRoute] string parentId,
            [FromBody] UsageBasedRequest request)
        {
            var response = await _paymentClient.RealizeUsageBasedSubPayment(parentId, request);
            return Ok(response);
        }

        /// <summary>
        ///     This endpoint will realize new paid payment for the same subscription as its parent payment.
        ///     This endpoint should be used in case the payment intervals are not known beforehand and will be thus irregular.
        ///     When using this endpoint, the payment amount can't be changed.
        /// </summary>
        /// <param name="parentId">UID of payment which initialized this subscription.</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("{parentId}/subscription/irregular")]
        public async Task<IActionResult> RealizeIrregularSubPayment([FromRoute] string parentId,
            [FromBody] IrregularSubRequest request)
        {
            var response = await _paymentClient.RealizeIrregularSubPayment(parentId, request);
            return Ok(response);
        }

        /// <summary>
        ///     This endpoint will realize new paid payment by same authorization which is save in parent payment.
        /// </summary>
        /// <param name="parentId">UID of payment with saved authorization</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("{parentId}/savedauthorization")]
        public async Task<IActionResult> RealizePaymentBySavedAuth([FromRoute] string parentId,
            [FromBody] RealizeBySavedAuthRequest request)
        {
            var response = await _paymentClient.RealizePaymentBySavedAuth(parentId, request);
            return Ok(response);
        }

        /// <summary>
        ///     Returns information about payment refund.
        /// </summary>
        /// <param name="uid">UID of the payment</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{uid}/refund")]
        public async Task<IActionResult> GetPaymentRefundInfo([FromRoute] string uid)
        {
            var response = await _paymentClient.GetPaymentRefundInfo(uid);
            return Ok(response);
        }

        /// <summary>
        ///     This endpoint will create a request for automatic refund of a payment.
        /// </summary>
        /// <param name="uid">UID of the payment</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("{uid}/refund")]
        public async Task<IActionResult> RequestPaymentRefund([FromRoute] string uid,
            [FromBody] PaymentRefundRequest request)
        {
            await _paymentClient.RequestRefund(uid, request);
            return Ok();
        }
    }
}