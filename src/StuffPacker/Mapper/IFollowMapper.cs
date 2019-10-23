using StuffPacker.Persistence.Model;
using StuffPacker.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StuffPacker.Mapper
{
    public interface IFollowMapper
    {
        Task<IEnumerable<FollowMemberViewModel>> Map(IEnumerable<FollowModel> members, bool isFollowing, IEnumerable<Guid> UserIsFollowing);
    }
}
