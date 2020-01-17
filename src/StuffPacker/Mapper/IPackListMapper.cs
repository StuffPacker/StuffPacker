using Shared.Contract.Dtos;
using StuffPacker.ViewModel;
using System.Collections.Generic;

namespace StuffPacker.Mapper
{
    public interface IPackListMapper
    {
        IEnumerable<PackListViewModel> Map(IEnumerable<PackListDto> packLists);
        PackListViewModel Map(PackListDto packList);
    }
}
