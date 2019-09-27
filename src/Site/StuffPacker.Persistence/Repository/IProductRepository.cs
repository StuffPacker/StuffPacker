using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StuffPacker.Model;
namespace StuffPacker.Repositories
{
    public interface IProductRepository
    {
        Task<ProductModel> Get(Guid item);
        Task Add(ProductModel productModel);
        Task Update(ProductModel model);
    }
}
