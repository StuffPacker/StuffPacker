using Shared.Contract;
using StuffPacker.ViewModel;

namespace StuffPacker.Mapper
{
    public interface IUserMapper
    {
        UserViewModel Map(UserProfile profile);
    }
}
