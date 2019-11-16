using StuffPacker.Persistence.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StuffPacker.Persistence.Repository
{
    public interface IUserProfileRepository
    {
        Task<UserProfileModel> Get(Guid userId);

        Task<IEnumerable<UserProfileModel>> Get();

        Task Add(UserProfileModel model);
    }
}
