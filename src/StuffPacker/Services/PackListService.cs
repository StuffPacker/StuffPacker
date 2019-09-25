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

        public async Task Add(Guid id, string name)
        {
            var model = new PackListModel(id);
            model.Update(name);
            await this._packListsRepository.Add(model);
            _messageService.SendMessage(new StringMessage($"PackListService:Update"));
        }

        public async Task<IEnumerable<PackListViewModel>> Get()
        {
            var packLists = new List<PackListViewModel>();
            var list = await this._packListsRepository.Get();
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

        private async Task<IEnumerable<PackListGroupViewModel>> GetGroups(IEnumerable<PackListGroupModel> groups)
        {
            var list = new List<PackListGroupViewModel>();
            foreach (var item in groups)
            {
                list.Add(new PackListGroupViewModel { Name = item.Name, Items = await GetItems(item.Items) });
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
                            Weight = p.Weight,
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
