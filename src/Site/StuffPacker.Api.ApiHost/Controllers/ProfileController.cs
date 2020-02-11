using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Contract.Dtos;
using Shared.Contract.Dtos.PackList;
using StuffPacker.Api.ApiHost.Services;
using System;
using System.Threading.Tasks;


namespace StuffPacker.Api.ApiHost.Controllers
{
    [Authorize(AuthenticationSchemes = "ApiBearer")]
    [Route("api/v1/profile")]
    public class ProfileController: BaseController
    {
        private readonly IProfileService _profileService;
        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }
        [HttpGet("nickname/{nickname}")]
        public async Task<IActionResult> GetNickname(string nickname)
        {

            var profile = await _profileService.GetByNickName(nickname);
            if(profile==null)
            {
                return this.Ok();
            }
            var dto = new ProfileDto
            {
                NickName=profile.NickName,
                FirstName=profile.FirstName,
                LastName=profile.LastName,
                Id=profile.Id
            };
            return this.Ok(dto);
        }
        [HttpPatch("{userId}/names")]
        public async Task<IActionResult> UpdateNames(Guid userId,[FromBody]UpdateUserNamesDto dto)
        {
            await _profileService.UpdateNames(userId,dto);
            return Ok();
        }
        [HttpPatch("{userId}/img")]
        public async Task<IActionResult> UpdateImg(Guid userId, [FromBody]UpdateUserImageDto dto)
        {
            await _profileService.UpdateImg(userId, dto.ImageName);
            return Ok();
        }


    }
}
