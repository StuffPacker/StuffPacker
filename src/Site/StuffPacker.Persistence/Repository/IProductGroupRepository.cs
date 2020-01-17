using StuffPacker.Persistence.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StuffPacker.Persistence.Repository
{
    public interface IProductGroupRepository
    {
        Task<IEnumerable<ProductGroupModel>> GetByUser(Guid guid);
        Task UpdateMaximized(Guid id, bool maximized);
        Task Add(ProductGroupModel model);
        Task<ProductGroupModel> GetByName(Guid userId, string name);
        Task Delete(Guid id);
    }
}
