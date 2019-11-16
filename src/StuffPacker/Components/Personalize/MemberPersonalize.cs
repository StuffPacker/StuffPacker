using StuffPacker.Services;
using StuffPacker.ViewModel.Members;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuffPacker.Components.Personalize
{
    public class MemberPersonalize : IMemberPersonalize
    {
        private readonly ICurrentUserProvider _currentUserProvider;

        public MemberPersonalize(ICurrentUserProvider currentUserProvider)
        {
            _currentUserProvider = currentUserProvider;
        }

        public async Task<IEnumerable<MemberListItemViewModel>> Personalize(IEnumerable<MemberListItemViewModel> models)
        {
            foreach (var item in models)
            {
                if (_currentUserProvider.GetUserId == item.UserId)
                {
                    item.ItsMe = true;
                }

                if (!item.ItsMe)
                {
                    var following = await _currentUserProvider.GetFollowing();
                    var f = following.FirstOrDefault(x => x.Id == item.UserId);
                    if (f != null)
                    {
                        item.Following = true;
                    }
                }
            }

            return models;
        }
    }
}
