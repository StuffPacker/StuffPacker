using StuffPacker.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StuffPacker.Services
{
    public interface IPackListService
    {
        Task<IEnumerable<PackListViewModel>> Get(Guid userId);
        Task<PackListViewModel> GetList(Guid listId);
        Task Add(Guid id,string name,Guid userId);
        Task Update(PackListViewModel model);
        
        Task AddGroup(Guid listId,string name);
        Task AddGroupItem(Guid listId, Guid groupId, string name, Guid userId);

        Task UpdateProduct(ProductViewModel model);

        Task DeleteProduct(Guid listId,Guid groupId,Guid productId);

        Task DeleteList(Guid listId);

        Task UpdateGroup(Guid listId,PackListGroupViewModel model);

        Task<IEnumerable<AddProductListItemViewModel>> GetAddableProducts(Guid userId);

        Task AddProducts(Guid userId, Guid listId, Guid groupId, IEnumerable<AddProductListItemViewModel> productlist);
    }
}
