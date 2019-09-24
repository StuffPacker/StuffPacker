using Blazor.Fluxor;

namespace StuffPacker.store.packlist.Get
{

    public class GetPackListDataActionReducer : Reducer<PackListDataState, GetPackListDataAction>
    {
        public override PackListDataState Reduce(PackListDataState state, GetPackListDataAction action)
        {
            return new PackListDataState(
                isLoading: true,
                errorMessage: null
                ,packLists: state.PackLists
                );
        }
    }
}
