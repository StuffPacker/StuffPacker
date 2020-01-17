using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Stuffpacker.Api.Controllers.Api
{
    [Authorize]
    [Route("api/v1/product")]
    public class ProductApiController : BaseController     
    {
        [HttpGet("")]
        public async Task<IActionResult> Test()
        {
           

            return this.Ok("Test");
        }
    }
}
