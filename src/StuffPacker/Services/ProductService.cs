using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using StuffPacker.Mapper;
using StuffPacker.Persistence.Repository;
using StuffPacker.Repositories;
using StuffPacker.ViewModel;

namespace StuffPacker.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductMapper _productMapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IPersonalizedProductRepository _personalizedProductRepository;
        public ProductService(IProductRepository productRepository, IProductMapper productMapper, IHttpContextAccessor httpContextAccessor, IPersonalizedProductRepository personalizedProductRepository)
        {
            _productRepository = productRepository;
            _productMapper = productMapper;
            _httpContextAccessor = httpContextAccessor;
            _personalizedProductRepository = personalizedProductRepository;
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
            var personalizedProductModels = await _personalizedProductRepository.GetByUser(GetUserId());
            return _productMapper.MapUserProducts(products,personalizedProductModels);
        }

        private Guid GetUserId()
        {
            var userId = Guid.Parse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            return userId;
        }
    }
}
