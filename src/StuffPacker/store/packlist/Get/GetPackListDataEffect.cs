using Blazor.Fluxor;
using StuffPacker.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace StuffPacker.store.packlist.Get
{

    public class GetPackListDataEffect : Effect<GetPackListDataAction>
    {
        private readonly IPackListService _packListService;

        public GetPackListDataEffect(IPackListService packListService)
        {
            _packListService = packListService;
        }

        protected async override Task HandleAsync(GetPackListDataAction action, IDispatcher dispatcher)
        {
            try
            {
                var packLists = await _packListService.Get();
                dispatcher.Dispatch(new GetPackListDataSuccessAction(packLists.ToArray()));
            }
            catch (Exception e)
            {
                dispatcher.Dispatch(new GetPackListDataFailedAction(errorMessage: e.Message));
            }
        }


    }
}
