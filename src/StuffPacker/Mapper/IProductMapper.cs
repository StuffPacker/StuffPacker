﻿using StuffPacker.Model;
using StuffPacker.ViewModel;
using System.Collections.Generic;

namespace StuffPacker.Mapper
{
    public interface IProductMapper
    {
        IEnumerable<AddProductListItemViewModel> Map(IEnumerable<ProductModel> userProducts);
    }
}