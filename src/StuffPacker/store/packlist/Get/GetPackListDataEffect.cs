using Blazor.Fluxor;
using Microsoft.AspNetCore.Http;
using Shared.Contract;
using Stuffpacker.Api.Client.ApiClient;
using StuffPacker.Mapper;
using StuffPacker.Services;
using StuffPacker.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace StuffPacker.store.packlist.Get
{

    public class GetPackListDataEffect : Effect<GetPackListDataAction>
    {
       

        private readonly ICurrentUser _currentUser;
        private readonly IApiClient _apiClient;
        private readonly IPackListMapper _packListMapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public GetPackListDataEffect(ICurrentUser currentUser, IApiClient apiClient, IPackListMapper packListMapper, IHttpContextAccessor httpContextAccessor)
        {
          
            _currentUser = currentUser;
            _apiClient = apiClient;
            _packListMapper = packListMapper;
            _httpContextAccessor = httpContextAccessor;
        }

        protected async override Task HandleAsync(GetPackListDataAction action, IDispatcher dispatcher)
        {
            try
            {

                var userId =  _currentUser.GetUserId();

                //var packLists = await _packListService.Get(userId);
                _apiClient.SetPrincipal(_httpContextAccessor.HttpContext.User);
                var packLists =await this._apiClient.GetPackLists();
                var list = _packListMapper.Map(packLists);
                dispatcher.Dispatch(new GetPackListDataSuccessAction(list.ToArray()));
            }
            catch (Exception e)
            {
                dispatcher.Dispatch(new GetPackListDataFailedAction(errorMessage: e.Message));
            }
        }


    }
}
