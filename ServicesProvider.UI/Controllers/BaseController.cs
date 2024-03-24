using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicesProvider.Core.DTOs.Shared;

namespace AuthJwt.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        //public IActionResult SendResponce(BaseResponce responce)
        //{
        //    if (!responce.IsSuccess)
        //    {
        //        return BadRequest(responce);
        //    }
        //    return Ok(responce);
        //}


    }
}
