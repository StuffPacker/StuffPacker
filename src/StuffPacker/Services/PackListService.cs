using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StuffPacker.Model;
using StuffPacker.Model.Messaging;
using StuffPacker.Repositories;
using StuffPacker.ViewModel;

namespace StuffPacker.Services
{
    public class PackListService : IPackListService
    {
        private readonly IPackListsRepository _packListsRepository;

        private readonly IProductRepository _productRepository;

        private readonly IMessageService _messageService;

        public PackListService(IPackListsRepository packListsRepository, IProductRepository productRepository, IMessageService messageService)
        {
            _packListsRepository = packListsRepository;
            _productRepository = productRepository;
            _messageService = messageService;
        }

        public async Task Add(Guid id, string name,Guid userId)
        {
            var model = new PackListModel(id,userId);
            model.Update(name);
            await this._packListsRepository.Add(model);
            _messageService.SendMessage(new StringMessage($"PackListService:Update"));
        }

        public async Task AddGroup(Guid listId, string name)
        {
            var model = await this._packListsRepository.Get(listId);
            var groupId = Guid.NewGuid();
            model.AddGroup(groupId,name);
            await this._packListsRepository.Update(model);
            _messageService.SendMessage(new StringMessage($"PackListService:Update"));

        }

        public async Task AddGroupItem(Guid listId,Guid groupId, string name)
        {
            var productId = Guid.NewGuid();

            var entity = new ProductEntity(productId);
            var productModel = new ProductModel(entity);
            productModel.Update(name);
            await this._productRepository.Add(productModel);

            var model = await this._packListsRepository.Get(listId);
            model.AddGroupItem(groupId,productId);
            await this._packListsRepository.Update(model);
            _messageService.SendMessage(new StringMessage($"PackListService:Update"));
        }

        public async Task DeleteProduct(Guid listId, Guid groupId, Guid productId)
        {
            var model = await this._packListsRepository.Get(listId);
            model.DeleteProductItem(groupId,productId);
            await this._packListsRepository.Update(model);
            _messageService.SendMessage(new StringMessage($"PackListService:Update"));
        }

        public async Task<IEnumerable<PackListViewModel>> Get(Guid userId)
        {
            var packLists = new List<PackListViewModel>();
            var list = await this._packListsRepository.GetByUser(userId);
            if(list==null)
            {
                return packLists;
            }
            foreach (var item in list)
            {
                packLists.Add(new PackListViewModel {Id=item.Id ,Name = item.Name, Items = await GetGroups(item.Groups) });
            }
            return packLists;
        }

        public async Task Update(PackListViewModel model)
        {
            var item = await this._packListsRepository.Get(model.Id);
            item.Update(model.Name);
            await this._packListsRepository.Update(item);
            _messageService.SendMessage(new StringMessage($"PackListService:Update"));
        }

        public async Task UpdateProduct(PackListItemViewModel model)
        {
            // var listModel = await this._packListsRepository.Get(listId);
            // var group = listModel.Groups.First(x=>x.Id==GroupId);
            var product = await this._productRepository.Get(model.Id);
            product.Update(model.Name,Convert.ToDecimal(model.Weight));
            await this._productRepository.Update(product);
            _messageService.SendMessage(new StringMessage($"PackListService:Update"));
        }

        private async Task<IEnumerable<PackListGroupViewModel>> GetGroups(IEnumerable<PackListGroupModel> groups)
        {
            var list = new List<PackListGroupViewModel>();
            foreach (var item in groups)
            {
                list.Add(new PackListGroupViewModel { Name = item.Name, Items = await GetItems(item.Items),Id=item.Id });
            }            
            return list;
        }

        private async Task<IEnumerable<PackListItemViewModel>> GetItems(IEnumerable<Guid> items)
        {
            var list = new List<PackListItemViewModel>();          
           
            foreach (var item in items)
            {
                var itemExist = list.Find(x => x.Id == item);
                if (itemExist!=null)
                {
                    itemExist.Amount = itemExist.Amount + 1;
                }
                else
                {
                    var p = await this._productRepository.Get(item);
                    if(p!=null)
                    {
                        list.Add(new PackListItemViewModel
                        {
                            Name = p.Name,
                            Weight = p.Weight.ToString(),
                            WeightPrefix = p.WeightPrefix,
                            Amount = 1,
                            Id = p.Id
                        });
                    }
                   
                }
               
            }
            
            return list;
        }
    }
}
