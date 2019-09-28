﻿using StuffPacker.Model;
using StuffPacker.ViewModel;
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
                    Name = item.Name
                });

            }
            return viewModels;
        }
    }
}
