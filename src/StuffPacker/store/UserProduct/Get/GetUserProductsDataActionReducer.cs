using Blazor.Fluxor;

namespace StuffPacker.store.UserProduct.Get
{

    public class GetUserProductsDataActionReducer : Reducer<UserProductsDataState, GetUserProductsDataAction>
    {
        public override UserProductsDataState Reduce(UserProductsDataState state, GetUserProductsDataAction action)
        {
            return new UserProductsDataState(
                isLoading: true,
                errorMessage: null,
                productList: state.ProductList,
                categoryList: state.CategoryList
                );
        }
    }
}
