using Shared.Contract.Dtos;
using Shared.Contract.Dtos.Product;
using StuffPacker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuffPacker.Api.ApiHost.Mapper
{
    public class ProductMapper : IProductMapper
    {
        public ProductDto Map(ProductModel product)
        {
            return new ProductDto
            {
                Name = product.Name,
                Description = product.Description,
                Id = product.Id,
                Weight = product.Weight,
                Images = product.Images

            };
        }
    }
}
