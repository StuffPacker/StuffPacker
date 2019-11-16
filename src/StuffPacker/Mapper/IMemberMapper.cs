using Shared.Contract;
using StuffPacker.Persistence.Model;
using StuffPacker.ViewModel;
using StuffPacker.ViewModel.Members;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StuffPacker.Mapper
{
    public interface IMemberMapper
    {
        IEnumerable<FriendViewModel> Map(IEnumerable<FriendModel> friends);
        FriendViewModel Map(FriendModel friend);

        Task<IEnumerable<MemberListItemViewModel>> Map(IEnumerable<UserProfileModel> userProfiles);
       
    }
}
