using Shared.Contract.Dtos;
using Shared.Contract.Dtos.Product;
using StuffPacker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuffPacker.Api.ApiHost.Mapper
{
    public interface IProductMapper
    {
        ProductDto Map(ProductModel product);
    }
}
