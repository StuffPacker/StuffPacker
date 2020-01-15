using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using StuffPacker.Mapper;
using StuffPacker.Model.Messaging;
using StuffPacker.Persistence.Model;
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
        private readonly IProductGroupRepository _productGroupRepository;
        private readonly IMessageService _messageService;
        public ProductService(IProductRepository productRepository, IProductMapper productMapper, IHttpContextAccessor httpContextAccessor, IPersonalizedProductRepository personalizedProductRepository, IProductGroupRepository productGroupRepository,
            IMessageService messageService)
        {
            _productRepository = productRepository;
            _productMapper = productMapper;
            _httpContextAccessor = httpContextAccessor;
            _personalizedProductRepository = personalizedProductRepository;
            _productGroupRepository = productGroupRepository;
            _messageService = messageService;
        }

        public async Task Delete(Guid productId)
        {
            var product = await this._productRepository.Get(productId);
            if(product.Owner!=GetUserId())
            {
                throw new Exception("You dont have access to delete this product");
            }
            await _productRepository.Delete(product.Id);
            _messageService.SendMessage(new StringMessage($"ProductService:Update"));
        }

        public async Task DeleteProductGroup(Guid id)
        {
            await _productGroupRepository.Delete(id);

        }

        public async Task<IEnumerable<ProductViewModel>> GetById()
        {
            var products = await _productRepository.GetByOwner(GetUserId());
            var personalizedProductModels = await _personalizedProductRepository.GetByUser(GetUserId());
            return await _productMapper.MapUserProducts(products,personalizedProductModels);
        }

        public async Task<IEnumerable<ProductListCategoryViewModel>> GetProductGroups()
        {
            var productGroups = await _productGroupRepository.GetByUser(GetUserId());
            return await _productMapper.MapProductGroups(productGroups);
        }

        public async Task<Guid> UpsertProductGroupsExpandCollapse(Guid id, bool maximized,string name)
        {
            var newId= Guid.NewGuid();
            if(id==Guid.Empty)
            {
                var model = new ProductGroupModel(new Persistence.Entity.ProductGroupEntity { Id= newId,Name=name,Owner=GetUserId(),Maximized=maximized});
                await _productGroupRepository.Add(model);
                id = newId;
            }

            await _productGroupRepository.UpdateMaximized(id,maximized);
            _messageService.SendMessage(new StringMessage($"ProductService:Update"));
            return id;
        }

        private Guid GetUserId()
        {
            var userId = Guid.Parse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            return userId;
        }

       
    }
}
