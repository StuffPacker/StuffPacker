using Shared.Contract;
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
        private readonly ICurrentUser _currentUSer;
        public ProductMapper(ICurrentUser currentUSer)
        {
            _currentUSer = currentUSer;
        }

        public IEnumerable<AddProductListItemViewModel> Map(IEnumerable<ProductModel> userProducts,IEnumerable<PersonalizedProductModel> personalizedProductModels )
        {
            var viewModels = new List<AddProductListItemViewModel>();
            userProducts = userProducts.OrderBy(x => x.Name).ToList();
            foreach (var item in userProducts)
            {
                var pp = personalizedProductModels.FirstOrDefault(x => x.ProductId == item.Id && x.UserId == _currentUSer.GetUserId());
                var category = "";
                if (pp != null)
                {
                    category = pp.Category;
                }
                viewModels.Add(new AddProductListItemViewModel(item.Id,item.Name,false,false,item.Weight,item.WeightPrefix, category));

            }
            return viewModels;
        }

        public IEnumerable<ProductViewModel> MapUserProducts(IEnumerable<ProductModel> products,IEnumerable<PersonalizedProductModel> personalizedProductModels)
        {
            var list = new List<ProductViewModel>();
            foreach (var item in products)
            {
                var pp=personalizedProductModels.FirstOrDefault(x=>x.ProductId==item.Id && x.UserId== _currentUSer.GetUserId());
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
