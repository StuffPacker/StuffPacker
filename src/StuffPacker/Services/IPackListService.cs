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
        Task<PackListViewModel> GetListViewer(Guid listId);
        Task Add(Guid id,string name,Guid userId);
        Task Update(PackListViewModel model);
        
        Task AddGroup(Guid listId,string name);

        Task UpdateMaximized(Guid listId,bool maximized);
        Task AddGroupItem(Guid listId, Guid groupId, string name, Guid userId);

        Task UpdateProduct(ProductViewModel model);

        Task DeleteProduct(Guid listId,Guid groupId,Guid productId);

        Task DeleteList(Guid listId);

        Task UpdateGroup(Guid listId,PackListGroupViewModel model);

        Task DeleteGroup(Guid listId,Guid groupId);

        Task<IEnumerable<AddProductListItemViewModel>> GetAddableProducts(Guid userId);

        Task AddProducts(Guid userId, Guid listId, Guid groupId, IEnumerable<AddProductListItemViewModel> productlist);

        Task UpdateVisibleList(Dictionary<Guid,bool> visibleList);
    }
}
