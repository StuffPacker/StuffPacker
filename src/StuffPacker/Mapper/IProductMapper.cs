﻿using StuffPacker.Model;
using StuffPacker.Persistence.Model;
using StuffPacker.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StuffPacker.Mapper
{
    public interface IProductMapper
    {
       Task<IEnumerable<AddProductListItemViewModel>> Map(IEnumerable<ProductModel> userProducts, IEnumerable<PersonalizedProductModel> personalizedProductModels, IEnumerable<PackListModel> kits);
     Task<IEnumerable<ProductViewModel>> MapUserProducts(IEnumerable<ProductModel> products, IEnumerable<PersonalizedProductModel> personalizedProductModels);
        Task<IEnumerable<ProductListCategoryViewModel>> MapProductGroups(IEnumerable<ProductGroupModel> productGroups);
        Task<ProductListCategoryViewModel> MapProductGroup(ProductGroupModel productGroup);
        
    }
}
