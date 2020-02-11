using Shared.Contract;
using StuffPacker.ViewModel;

namespace StuffPacker.Mapper
{
    public class UserMapper : IUserMapper
    {
        public UserViewModel Map(UserProfile profile)
        {
            return new UserViewModel
            {
                NickName = profile.NickName,
                FirstName = profile.FirstName,
                LastName = profile.LastName,
                ImgUrl = "/img/members/"+profile.UserImgPath
            };
        }
    }
}
