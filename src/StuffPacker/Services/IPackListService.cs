using StuffPacker.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StuffPacker.Services
{
    public interface IPackListService
    {
        Task<IEnumerable<PackListViewModel>> Get();
        Task Add(Guid id,string name);
        Task Update(PackListViewModel model);
    }
}
