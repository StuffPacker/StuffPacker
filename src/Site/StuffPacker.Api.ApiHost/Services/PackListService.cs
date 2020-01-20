

using Shared.Contract.Dtos;
using Shared.Contract.Dtos.PackList;
using StuffPacker.Model;
using StuffPacker.Persistence.Repository;
using StuffPacker.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StuffPacker.Api.ApiHost.Controllers
{
    public class PackListService : IPackListService
    {
        private readonly IPackListsRepository _packListsRepository;
        private readonly IPersonalizedProductRepository _personalizedProductRepository;
        private readonly IProductRepository _productRepository;
        public PackListService(IPackListsRepository packListsRepository, IPersonalizedProductRepository personalizedProductRepository, IProductRepository productRepository)
        {
            _packListsRepository = packListsRepository;
            _personalizedProductRepository = personalizedProductRepository;
            _productRepository = productRepository;
        }
        public async Task<IEnumerable<PackListDto>> Get(Guid userId)
        {
            var packLists = new List<PackListDto>();
            var list = await this._packListsRepository.GetByUser(userId);
            if (list == null)
            {
                return packLists;
            }
            foreach (var item in list)
            {
                packLists.Add(new PackListDto {Maximized=item.Maximized, UserId = item.UserId, IsPublic = item.IsPublic, Id = item.Id, Name = item.Name, Items = await GetGroups(item.Groups, item.WeightPrefix, item.UserId), WeightPrefix = item.WeightPrefix, Modified = item.Modified });
            }
            return packLists;
        }

        public async Task UpdateMaximized(Guid id,UpdatePackListMaximizedDto dto)
        {
            var packlist = await _packListsRepository.Get(id);
            packlist.UpdateMaximized(dto.Maximized);
            await _packListsRepository.Update(packlist);

        }

       

        private async Task<IEnumerable<PackListGroupDto>> GetGroups(IEnumerable<PackListGroupModel> groups, WeightPrefix weightPrefix, Guid userId)
        {
            var list = new List<PackListGroupDto>();
            foreach (var item in groups)
            {
                list.Add(new PackListGroupDto(weightPrefix) { Name = item.Name, Items = await GetItems(item.Items, userId), Id = item.Id });
            }
            return list;
        }
        private async Task<IEnumerable<ProductDto>> GetItems(IEnumerable<Guid> items, Guid userId)
        {
            var list = new List<ProductDto>();
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
                    var pp = personalizedProductList.FirstOrDefault(x => x.ProductId == item);
                    var category = "";
                    bool star = false;
                    bool wearable = false;
                    bool consumables = false;
                    if (pp != null)
                    {
                        category = pp.Category;
                        wearable = pp.Wearable;
                        consumables = pp.Consumables;
                        star = pp.Star;
                    }
                    if (p != null)
                    {
                        list.Add(new ProductDto
                        {
                            Name = p.Name,
                            Weight = p.Weight,
                            WeightPrefix = p.WeightPrefix,
                            Amount = 1,
                            Id = p.Id,
                            Category = category,
                            Star = star,
                            Wearable = wearable,
                            Consumables = consumables,
                            Description = p.Description
                        });
                    }

                }

            }

            return list;
        }
    }
}
