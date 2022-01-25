using Microsoft.AspNetCore.Mvc;
using TestDataLibrary;

namespace LuskPaymentGatewayApi.Controllers
{
    [ApiController]
    [Route("test")]
    public class TestController : ControllerBase
    {
        private IDataCreator _dataCreator;

        public TestController(IDataCreator dataCreator)
        {
            _dataCreator = dataCreator;
        }

        [HttpPost]
        [Route("/data")]
        public IActionResult CreateTestData()
        {
            _dataCreator.CreateTestPaymentRequest();
            return Ok();
        }
    }
}