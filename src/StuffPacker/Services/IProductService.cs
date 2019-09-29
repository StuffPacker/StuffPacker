using StuffPacker.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StuffPacker.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductViewModel>> GetById();
        Task Delete(Guid productId);
    }
}
