using Shared.Contract;
using StuffPacker.Persistence.Model;
using StuffPacker.ViewModel;
using System.Collections.Generic;

namespace StuffPacker.Mapper
{
    public interface IMemberMapper
    {
        IEnumerable<FriendViewModel> Map(IEnumerable<FriendModel> friends);
        FriendViewModel Map(FriendModel friend);       
       
    }
}
