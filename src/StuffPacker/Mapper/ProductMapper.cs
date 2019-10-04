using StuffPacker.Model;
using StuffPacker.Persistence.Model;
using StuffPacker.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StuffPacker.Mapper
{
    public class ProductMapper : IProductMapper
    {
        public IEnumerable<AddProductListItemViewModel> Map(IEnumerable<ProductModel> userProducts)
        {
            var viewModels = new List<AddProductListItemViewModel>();
            userProducts = userProducts.OrderBy(x => x.Name).ToList();
            foreach (var item in userProducts)
            {
              
                viewModels.Add(new AddProductListItemViewModel
                {
                    Id = item.Id,
                    IsNew = false,
                    Selected = false,
                    Name = item.Name,                    
                });

            }
            return viewModels;
        }

        public IEnumerable<ProductViewModel> MapUserProducts(IEnumerable<ProductModel> products,IEnumerable<PersonalizedProductModel> personalizedProductModels)
        {
            var list = new List<ProductViewModel>();
            foreach (var item in products)
            {
                var pp=personalizedProductModels.FirstOrDefault(x=>x.ProductId==item.Id);
                var category = "";
                if(pp!=null)
                {
                    category= pp.Category; 
                }
                
                list.Add(new ProductViewModel
                {
                    Id=item.Id,
                    Name=item.Name,
                    Weight = item.Weight,
                    WeightPrefix = item.WeightPrefix,
                    Category= category
                });
            }
            return list;
        }
    }
}
