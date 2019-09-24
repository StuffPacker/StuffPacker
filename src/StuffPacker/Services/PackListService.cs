using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StuffPacker.Model;
using StuffPacker.Repositories;
using StuffPacker.ViewModel;

namespace StuffPacker.Services
{
    public class PackListService : IPackListService
    {
        private readonly IPackListsRepository _packListsRepository;

        private readonly IProductRepository _productRepository;

        public PackListService(IPackListsRepository packListsRepository, IProductRepository productRepository)
        {
            _packListsRepository = packListsRepository;
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<PackListViewModel>> Get()
        {
            var packLists = new List<PackListViewModel>();
            var list = await this._packListsRepository.Get();
            foreach (var item in list)
            {
                packLists.Add(new PackListViewModel { Name = "List name" + item.Id, Items = await GetGroups(item.Groups) });
            }
            return packLists;
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
                    list.Add(new PackListItemViewModel
                    {
                        Name = $"item {p.Name}",
                        Weight = p.Weight,
                        WeightPrefix = p.WeightPrefix,
                        Amount = 1,
                        Id = p.Id
                    });
                }
               
            }
            
            return list;
        }
    }
}
