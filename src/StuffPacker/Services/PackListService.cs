using Shared.Contract;
using StuffPacker.Mapper;
using StuffPacker.Model;
using StuffPacker.Model.Messaging;
using StuffPacker.Persistence.Model;
using StuffPacker.Persistence.Repository;
using StuffPacker.Repositories;
using StuffPacker.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuffPacker.Services
{
    public class PackListService : IPackListService
    {
        private readonly IPackListsRepository _packListsRepository;

        private readonly IProductRepository _productRepository;

        private readonly IMessageService _messageService;

        private readonly IProductMapper _productMapper;

        private readonly IPersonalizedProductRepository _personalizedProductRepository;

        private readonly ICurrentUser _currentUser;

        public PackListService(IPackListsRepository packListsRepository, IProductRepository productRepository, IMessageService messageService, IProductMapper productMapper, IPersonalizedProductRepository personalizedProductRepository, ICurrentUser currentUser)
        {
            _packListsRepository = packListsRepository;
            _productRepository = productRepository;
            _messageService = messageService;
            _productMapper = productMapper;
            _personalizedProductRepository = personalizedProductRepository;
            _currentUser = currentUser;
        }

        public async Task Add(Guid id, string name, Guid userId)
        {
            var model = new PackListModel(id, userId);
            model.Update(name,WeightPrefix.Gram,false);
            await this._packListsRepository.Add(model);
            _messageService.SendMessage(new StringMessage($"PackListService:Update"));
        }

        public async Task AddGroup(Guid listId, string name)
        {
            var model = await this._packListsRepository.Get(listId);
            var groupId = Guid.NewGuid();
            model.AddGroup(groupId, name);
            await this._packListsRepository.Update(model);
            _messageService.SendMessage(new StringMessage($"PackListService:Update"));

        }

        public async Task AddGroupItem(Guid listId, Guid groupId, string name, Guid userId)
        {
            var productId = Guid.NewGuid();

            var entity = new ProductEntity(productId, userId);
            var productModel = new ProductModel(entity);
            productModel.Update(name,Convert.ToDecimal(0),WeightPrefix.Gram,string.Empty);
            await this._productRepository.Add(productModel);

            var model = await this._packListsRepository.Get(listId);
            model.AddGroupItem(groupId, productId);
            await this._packListsRepository.Update(model);
            _messageService.SendMessage(new StringMessage($"PackListService:Update"));
        }

        public async Task AddProducts(Guid userId, Guid listId, Guid groupId, IEnumerable<AddProductListItemViewModel> productlist)
        {
            var selected = productlist.Where(x => x.Selected).ToList();
            var list = await this._packListsRepository.Get(listId);
            foreach (var item in selected)
            {
                var productId = item.Id;
                if (item.IsNew)
                {
                    var entity = new ProductEntity(productId, userId);
                    var productModel = new ProductModel(entity);
                    productModel.Update(item.Name,Convert.ToDecimal(0),WeightPrefix.Gram,string.Empty);
                    await this._productRepository.Add(productModel);
                }
               
                list.AddGroupItem(groupId, productId);
            }
            await this._packListsRepository.Update(list);
            _messageService.SendMessage(new StringMessage($"PackListService:Update"));

        }

        public async Task DeleteGroup(Guid listId, Guid groupId)
        {
            var item = await this._packListsRepository.Get(listId);
            item.DeleteGroup(groupId);
            await this._packListsRepository.Update(item);
            _messageService.SendMessage(new StringMessage($"PackListService:Update"));
        }

        public async Task DeleteList(Guid listId)
        {
            var item = await this._packListsRepository.Get(listId);

            await this._packListsRepository.Delete(item);
            _messageService.SendMessage(new StringMessage($"PackListService:Update"));
        }

        public async Task DeleteProduct(Guid listId, Guid groupId, Guid productId)
        {
            var model = await this._packListsRepository.Get(listId);
            model.DeleteProductItem(groupId, productId);
            await this._packListsRepository.Update(model);
            _messageService.SendMessage(new StringMessage($"PackListService:Update"));
        }

        public async Task<IEnumerable<PackListViewModel>> Get(Guid userId)
        {
            var packLists = new List<PackListViewModel>();
            var list = await this._packListsRepository.GetByUser(userId);
            if (list == null)
            {
                return packLists;
            }
            foreach (var item in list)
            {
                packLists.Add(new PackListViewModel { UserId=item.UserId,IsPublic=item.IsPublic,Id = item.Id, Name = item.Name, Items = await GetGroups(item.Groups,item.WeightPrefix,item.UserId),WeightPrefix=item.WeightPrefix });
            }
            return packLists;
        }

        public async Task<IEnumerable<AddProductListItemViewModel>> GetAddableProducts(Guid userId)
        {
            var userProducts = await this._productRepository.GetByOwner(userId);
            var personalizedProductModels = await this._personalizedProductRepository.GetByUser(userId);
            return _productMapper.Map(userProducts, personalizedProductModels);
        }

        public async Task<PackListViewModel> GetList(Guid listId)
        {
            var packList =  await this._packListsRepository.Get(listId);
            if (packList == null)
            {
                return new PackListViewModel(); 
            }
           
          return      new PackListViewModel {IsPublic=packList.IsPublic,UserId=packList.UserId ,Id = packList.Id, Name = packList.Name, Items = await GetGroups(packList.Groups, packList.WeightPrefix,packList.UserId), WeightPrefix = packList.WeightPrefix };
          
        }

        public async Task Update(PackListViewModel model)
        {
            var item = await this._packListsRepository.Get(model.Id);
            item.Update(model.Name,model.WeightPrefix,model.IsPublic);
            await this._packListsRepository.Update(item);
            _messageService.SendMessage(new StringMessage($"PackListService:Update"));
        }

        public async Task UpdateGroup(Guid listId, PackListGroupViewModel model)
        {
            var item = await this._packListsRepository.Get(listId);
            item.UpdateGroup(model.Id, model.Name);
            await this._packListsRepository.Update(item);
            _messageService.SendMessage(new StringMessage($"PackListService:Update"));
        }

        public async Task UpdateProduct(ProductViewModel model)
        {
            var userId = _currentUser.GetUserId();
            var product = await this._productRepository.Get(model.Id);
            product.Update(model.Name, Convert.ToDecimal(model.Weight),model.WeightPrefix,model.Description);

            var pModel = await _personalizedProductRepository.Get(userId,model.Id);
            if(pModel==null)
            {
                pModel = new PersonalizedProductModel(Guid.Empty,userId,model.Id);
            }
            pModel.Update(model.Category,model.Star,model.Wearable,model.Consumables);
            await this._productRepository.Update(product,pModel);
            _messageService.SendMessage(new StringMessage($"PackListService:Update"));
        }

        private async Task<IEnumerable<PackListGroupViewModel>> GetGroups(IEnumerable<PackListGroupModel> groups, WeightPrefix weightPrefix,Guid userId)
        {
            var list = new List<PackListGroupViewModel>();
            foreach (var item in groups)
            {
                list.Add(new PackListGroupViewModel(weightPrefix) { Name = item.Name, Items = await GetItems(item.Items,userId), Id = item.Id });
            }
            return list;
        }

        private async Task<IEnumerable<ProductViewModel>> GetItems(IEnumerable<Guid> items,Guid userId)
        {
            var list = new List<ProductViewModel>();
            var personalizedProductList = await _personalizedProductRepository.GetByUser(userId);
            foreach (var item in items)
            {
                var itemExist = list.Find(x => x.Id == item);
                if (itemExist != null)
                {
                    itemExist.Amount = itemExist.Amount + 1;
                }
                else
                {
                    var p = await this._productRepository.Get(item);
                    var pp = personalizedProductList.FirstOrDefault(x=>x.ProductId==item);
                    var category = "";
                    bool star = false;
                    bool wearable = false;
                    bool consumables = false;
                    if (pp!=null)
                    {
                        category = pp.Category;
                        wearable = pp.Wearable;
                        consumables = pp.Consumables;
                        star = pp.Star;
                    }
                    if (p != null)
                    {
                        list.Add(new ProductViewModel
                        {
                            Name = p.Name,
                            Weight = p.Weight,
                            WeightPrefix = p.WeightPrefix,
                            Amount = 1,
                            Id = p.Id,
                            Category=category,
                            Star=star,
                            Wearable= wearable,
                            Consumables= consumables,
                            Description=p.Description
                        });
                    }

                }

            }

            return list;
        }
    }
}
