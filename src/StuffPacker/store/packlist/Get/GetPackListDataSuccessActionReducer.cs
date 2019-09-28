using Blazor.Fluxor;

namespace StuffPacker.store.packlist.Get
{

    public class GetPackListDataSuccessActionReducer : Reducer<PackListDataState, GetPackListDataSuccessAction>
    {
        public override PackListDataState Reduce(PackListDataState state, GetPackListDataSuccessAction action)
        {
            return new PackListDataState(
                isLoading: false,
                errorMessage: null,
                action.PackLists
                );
        }
    }
}
