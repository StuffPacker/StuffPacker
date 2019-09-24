using StuffPacker.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StuffPacker.Repositories
{
    public interface IPackListsRepository
    {
        Task<IEnumerable<PackListModel>> Get();
    }
}
