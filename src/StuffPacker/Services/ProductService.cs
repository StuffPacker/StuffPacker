using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using StuffPacker.Mapper;
using StuffPacker.Repositories;
using StuffPacker.ViewModel;

namespace StuffPacker.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductMapper _productMapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ProductService(IProductRepository productRepository, IProductMapper productMapper, IHttpContextAccessor httpContextAccessor)
        {
            _productRepository = productRepository;
            _productMapper = productMapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task Delete(Guid productId)
        {
            var product = await this._productRepository.Get(productId);
            if(product.Owner!=GetUserId())
            {
                throw new Exception("You dont have access to delete this product");
            }
            await _productRepository.Delete(product.Id);
        }

        public async Task<IEnumerable<ProductViewModel>> GetById()
        {
            var products = await _productRepository.GetByOwner(GetUserId());
            return _productMapper.MapUserProducts(products);
        }

        private Guid GetUserId()
        {
            var userId = Guid.Parse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            return userId;
        }
    }
}
