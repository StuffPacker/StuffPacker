using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Contract.Dtos.PackList;
using System;
using System.Threading.Tasks;

namespace StuffPacker.Api.ApiHost.Controllers
{
    [Authorize(AuthenticationSchemes = "ApiBearer")]
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

            var list = await _packListService.GetLists(GetUserId(),0);

            return this.Ok(list);
        }
        [HttpPatch("{id}/maximized")]
        public async Task<IActionResult> UpdateMaximized([FromBody] UpdatePackListMaximizedDto dto,Guid id)
        {
            await _packListService.UpdateMaximized(id,dto);

            return Ok();
        }
        [HttpPatch("{id}/kit")]
        public async Task<IActionResult> UpdateMaximized([FromBody] UpdatePackListKitDto dto, Guid id)
        {
            await _packListService.UpdateKit(id, dto);

            return Ok();
        }

        [HttpPatch("visiblelist")]
        public async Task<IActionResult> UpdateVisibleList([FromBody] UpdatePackListVisibleListDto dto)
        {
            await _packListService.UpdateVisibleList(dto);

            return Ok();
        }
       
    }
}