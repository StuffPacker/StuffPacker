using Shared.Contract.Dtos;
using Shared.Contract.Dtos.Product;
using System;
using System.Threading.Tasks;

namespace StuffPacker.Api.ApiHost.Services
{
    public interface IProductService
    {
        Task AddImg(Guid guid, Guid productId, string imageName, Guid fileId);
        Task<ProductDto> Get(Guid productId);
    }
}
