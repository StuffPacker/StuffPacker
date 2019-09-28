using Blazor.Fluxor;
using Microsoft.AspNetCore.Http;
using StuffPacker.Services;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace StuffPacker.store.packlist.Get
{

    public class GetPackListDataEffect : Effect<GetPackListDataAction>
    {
        private readonly IPackListService _packListService;

        private readonly IHttpContextAccessor _httpContextAccessor;

        public GetPackListDataEffect(IPackListService packListService, IHttpContextAccessor httpContextAccessor)
        {
            _packListService = packListService;
            _httpContextAccessor = httpContextAccessor;
        }

        protected async override Task HandleAsync(GetPackListDataAction action, IDispatcher dispatcher)
        {
            try
            {

                var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

                var packLists = await _packListService.Get(Guid.Parse(userId));
                dispatcher.Dispatch(new GetPackListDataSuccessAction(packLists.ToArray()));
            }
            catch (Exception e)
            {
                dispatcher.Dispatch(new GetPackListDataFailedAction(errorMessage: e.Message));
            }
        }


    }
}
