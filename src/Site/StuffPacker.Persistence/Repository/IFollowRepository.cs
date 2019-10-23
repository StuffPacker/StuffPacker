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
    }
}
