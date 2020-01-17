using Blazor.Fluxor;

namespace StuffPacker.store.UserProduct.Get
{

    public class GetUserProductsDataFailedActionReducer : Reducer<UserProductsDataState, GetUserProductsDataFailedAction>
    {
        public override UserProductsDataState Reduce(UserProductsDataState state, GetUserProductsDataFailedAction action)
        {
            return new UserProductsDataState(
                isLoading: false,
                errorMessage: action.ErrorMessage,
                 null,
                null
                );
        }
    }
}
