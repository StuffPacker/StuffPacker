using Shared.Contract.Dtos;
using Shared.Contract.Dtos.Product;
using StuffPacker.Api.ApiHost.Mapper;
using StuffPacker.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuffPacker.Api.ApiHost.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductMapper _productMapper;

        public ProductService(IProductRepository productRepository, IProductMapper productMapper)
        {
            _productRepository = productRepository;
            _productMapper = productMapper;
        }
        public async Task AddImg(Guid userId, Guid productId, string imageName,Guid fileId)
        {

            var model = await _productRepository.Get(productId);
            if (model.Owner != userId)
            {
                throw new Exception("Not allowed to update");
            }
            model.AddImg(fileId,imageName);
            await _productRepository.Update(model);
        }

        public async Task<ProductDto> Get(Guid productId)
        {
            var product = await _productRepository.Get(productId);
            if(product==null)
            {
                return null;
            }
            return _productMapper.Map(product);
        }
    }
}
