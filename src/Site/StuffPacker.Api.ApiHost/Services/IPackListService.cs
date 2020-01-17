
using Shared.Contract.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StuffPacker.Api.ApiHost.Controllers
{
    public interface IPackListService
    {
        Task<IEnumerable<PackListDto>> Get(Guid userId);
    }
}
