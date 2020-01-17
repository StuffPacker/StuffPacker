using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace StuffPacker.Api.ApiHost.Controllers
{
    // [Authorize(AuthenticationSchemes = "ApiBearer")]
    [Route("api/v1/packlist")]
    public class PackListController : BaseController
    {
        private readonly IPackListService _packListService;

        public PackListController(IPackListService packListService)
        {
            _packListService = packListService;
        }

        [HttpGet("")]
        public async Task<IActionResult> Get()
        {
             var tempid = Guid.Parse("4f22d3fc-80fc-44b6-9e4b-f760d8b57876");

            var list = await _packListService.Get(tempid);

            return this.Ok("ok");
        }

    }
}
