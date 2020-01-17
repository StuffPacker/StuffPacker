using Blazor.Fluxor;

namespace StuffPacker.store.UserProduct.Get
{

    public class GetUserProductsDataSuccessActionReducer : Reducer<UserProductsDataState, GetUserProductsDataSuccessAction>
    {
        public override UserProductsDataState Reduce(UserProductsDataState state, GetUserProductsDataSuccessAction action)
        {
            return new UserProductsDataState(
                isLoading: false,
                errorMessage: null,
                action.ProductList,
                action.CategoryList
                );
        }
    }
}
