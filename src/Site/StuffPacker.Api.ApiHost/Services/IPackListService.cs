
using Shared.Contract.Dtos;
using Shared.Contract.Dtos.PackList;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StuffPacker.Api.ApiHost.Controllers
{
    public interface IPackListService
    {
        Task<IEnumerable<PackListDto>> Get(Guid userId);
        Task UpdateMaximized(Guid id,UpdatePackListMaximizedDto dto);
        Task UpdateVisibleList(UpdatePackListVisibleListDto dto);
    }
}
