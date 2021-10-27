using Microsoft.AspNetCore.Mvc;
using OzonEdu.MerchandiseService.HttpModels;

namespace OzonEdu.MerchandiseService.Controllers
{
    [ApiController]
    [Route("api/v1/merch")]
    [Produces("application/json")]
    public class MerchController : ControllerBase
    {
        [HttpPost("request")]
        public ActionResult<RequestMerchResponse> RequestMerch(RequestMerchRequest request)
        {
            return Ok(new RequestMerchResponse { Status = "Merch requested" });
        }

        [HttpGet("info")]
        public ActionResult<MerchInfoResponse> GetMerchGivingInfo([FromQuery] MerchInfoRequest request)
        {
            return Ok(new MerchInfoResponse { Status = "In progress" });
        }
    }
}
