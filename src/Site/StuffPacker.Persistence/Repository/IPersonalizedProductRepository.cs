using StuffPacker.Persistence.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StuffPacker.Persistence.Repository
{
    public interface IPersonalizedProductRepository
    {
        Task<IEnumerable<PersonalizedProductModel>> GetByUser(Guid guid);
        Task<PersonalizedProductModel> Get(Guid userId, Guid id);
    }
}
