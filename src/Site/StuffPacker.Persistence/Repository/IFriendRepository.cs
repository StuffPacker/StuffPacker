using StuffPacker.Persistence.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StuffPacker.Persistence.Repository
{
    public interface IFriendRepository
    {
        Task<IEnumerable<FriendModel>> GetFriends(Guid userId);
    }
}
