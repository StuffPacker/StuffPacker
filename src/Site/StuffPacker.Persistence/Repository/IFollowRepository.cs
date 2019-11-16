using StuffPacker.Persistence.Entity;
using StuffPacker.Persistence.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StuffPacker.Persistence.Repository
{
    public interface IFollowRepository
    {
        Task<IEnumerable<FollowModel>> GetFollowers(Guid userId);
        Task<IEnumerable<FollowModel>> GetFollowing(Guid userId);
        Task<FollowModel> Get(Guid currentUser, Guid userId);

        Task Delete(FollowModel model);
        Task Add(FollowModel model);
    }
}
