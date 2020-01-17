using StuffPacker.ViewModel;
using System.Collections.Generic;

namespace StuffPacker.store.UserProduct.Get
{

    public class GetUserProductsDataSuccessAction
    {
        public List<ProductViewModel> ProductList { get; set; }
        public List<ProductListCategoryViewModel> CategoryList { get; set; }

        public GetUserProductsDataSuccessAction(List<ProductViewModel> productList, List<ProductListCategoryViewModel> categoryList)
        {
            ProductList = productList;
            CategoryList = categoryList;
        }
    }
}
