using Microsoft.AspNetCore.Mvc;
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
            var list= await _packListService.Get(GetUserId());

            return this.Ok("ok");
        }

    }
}
