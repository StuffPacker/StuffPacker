using StuffPacker.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StuffPacker.Services
{
    public interface IPackListService
    {
        Task<IEnumerable<PackListViewModel>> Get(Guid userId);
        Task Add(Guid id,string name,Guid userId);
        Task Update(PackListViewModel model);
        
        Task AddGroup(Guid listId,string name);
        Task AddGroupItem(Guid listId, Guid groupId, string name);

        Task UpdateProduct(PackListItemViewModel model);

        Task DeleteProduct(Guid listId,Guid groupId,Guid productId);

        Task DeleteList(Guid listId);

        Task UpdateGroup(Guid listId,PackListGroupViewModel model);
    }
}
