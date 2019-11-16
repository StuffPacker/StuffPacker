using StuffPacker.Persistence.Model;
using StuffPacker.Persistence.Repository;
using StuffPacker.Services;
using StuffPacker.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
namespace StuffPacker.Mapper
{
    public class FollowMapper : IFollowMapper
    {
        private readonly IUserProfileRepository _userProfileRepository;
       

        public FollowMapper(IUserProfileRepository userProfileRepository)
        {
            _userProfileRepository = userProfileRepository;
        }
        public async Task<IEnumerable<FollowMemberViewModel>> Map(IEnumerable<FollowModel> members, bool isFollowing,IEnumerable<Guid> UserIsFollowing)
        {
            var list = new List<FollowMemberViewModel>();
            if(members==null)
            {
                return list;
            }
            foreach (var item in members)
            {
                var firstName = string.Empty;
                var lastName = string.Empty;
                var nickName = string.Empty;
                var userId = Guid.Empty;
                var following = false;
                if (isFollowing)
                {
                    //get userinfo by item.FollowUserId
                   var uProfile= await this._userProfileRepository.Get(item.FollowUserId);
                    firstName = uProfile.FirstName;
                    lastName = uProfile.LastName;
                    nickName = uProfile.NickName;
                    userId = item.FollowUserId;
                    //check if user is following this user


                    following = UserIsFollowing.Contains(item.FollowUserId);
                    
                }
                else
                {
                    //get userinfo by item.UserId
                    var uProfile = await this._userProfileRepository.Get(item.UserId);
                    firstName = uProfile.FirstName;
                    lastName = uProfile.LastName;
                    nickName = uProfile.NickName;
                    userId = item.UserId;
                    
                    //kolla om personen följer eller ej
                    following = UserIsFollowing.Contains(item.UserId);

                }

                list.Add(new FollowMemberViewModel
                {
                    Id = userId,
                    FirstName = firstName,
                    LastName = lastName,
                    NickName = nickName,
                    Following = following
                }); ;
            }
            return list;
        }
    }
}
