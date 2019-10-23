using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.Contract;
using StuffPacker.Persistence.Model;
using StuffPacker.ViewModel;

namespace StuffPacker.Mapper
{
    public class MemberMapper : IMemberMapper
    {
       

        public IEnumerable<FriendViewModel> Map(IEnumerable<FriendModel> friends)
        {
            var list = new List<FriendViewModel>();
            foreach (var item in friends)
            {
                list.Add(Map(item));
            }
            return list;
        }

        public FriendViewModel Map(FriendModel friend)
        {
            return new FriendViewModel
            {
                UserId = friend.UserId,
                FriendUserId=friend.FriendUserId
            };
        }
    }
}
