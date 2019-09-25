using StuffPacker.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StuffPacker.Repositories
{
    public interface IPackListsRepository
    {
        Task<IEnumerable<PackListModel>> Get();
        Task<PackListModel> Get(Guid id);
        Task Add(PackListModel model);
        Task Update(PackListModel model);
    }
}
