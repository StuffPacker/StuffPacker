using Blazor.Fluxor;

namespace StuffPacker.store.packlist.Get
{

    public class GetPackListDataFailedActionReducer : Reducer<PackListDataState, GetPackListDataFailedAction>
    {
        public override PackListDataState Reduce(PackListDataState state, GetPackListDataFailedAction action)
        {
            return new PackListDataState(
                isLoading: false,
                errorMessage: action.ErrorMessage
                , null
                );
        }
    }
}
