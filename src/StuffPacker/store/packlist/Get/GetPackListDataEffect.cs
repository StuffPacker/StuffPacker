using Blazor.Fluxor;
using Microsoft.AspNetCore.Http;
using Shared.Contract;
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
        private readonly IPackListService _packListService;

        private readonly ICurrentUser _currentUser;

        public GetPackListDataEffect(IPackListService packListService, ICurrentUser currentUser)
        {
            _packListService = packListService;
            _currentUser = currentUser;
        }

        protected async override Task HandleAsync(GetPackListDataAction action, IDispatcher dispatcher)
        {
            try
            {

                var userId =  _currentUser.GetUserId();

                 var packLists = await _packListService.Get(userId);
              
                dispatcher.Dispatch(new GetPackListDataSuccessAction(packLists.ToArray()));
            }
            catch (Exception e)
            {
                dispatcher.Dispatch(new GetPackListDataFailedAction(errorMessage: e.Message));
            }
        }


    }
}
