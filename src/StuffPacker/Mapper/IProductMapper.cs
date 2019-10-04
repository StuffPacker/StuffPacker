using StuffPacker.Model;
using StuffPacker.Persistence.Model;
using StuffPacker.ViewModel;
using System.Collections.Generic;

namespace StuffPacker.Mapper
{
    public interface IProductMapper
    {
        IEnumerable<AddProductListItemViewModel> Map(IEnumerable<ProductModel> userProducts);
        IEnumerable<ProductViewModel> MapUserProducts(IEnumerable<ProductModel> products, IEnumerable<PersonalizedProductModel> personalizedProductModels);
    }
}
