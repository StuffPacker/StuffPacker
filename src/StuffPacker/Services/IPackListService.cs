using StuffPacker.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StuffPacker.Services
{
    public interface IPackListService
    {
        Task<IEnumerable<PackListViewModel>> Get();
    }
}
