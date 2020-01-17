using StuffPacker.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace StuffPacker.store.UserProduct
{
    public class UserProductsDataState
    {
        public bool IsLoading { get; set; }
        public string ErrorMessage { get; set; }
        public List<ProductViewModel> ProductList { get; set; }
        public List<ProductListCategoryViewModel> CategoryList { get; set; }

        public UserProductsDataState()
        {
            ProductList = new List<ProductViewModel>();
            CategoryList = new List<ProductListCategoryViewModel>();
        }

        public UserProductsDataState(bool isLoading, string errorMessage, IEnumerable<ProductViewModel> productList, IEnumerable<ProductListCategoryViewModel> categoryList)
        {
            IsLoading = isLoading;
            ErrorMessage = errorMessage;
            ProductList = productList == null ? null : productList.ToList();
            CategoryList = categoryList == null ? null : categoryList.ToList();
        }
    }
}
