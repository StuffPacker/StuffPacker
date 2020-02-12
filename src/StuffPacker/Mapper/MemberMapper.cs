using Shared.Contract;
using StuffPacker.Persistence.Model;
using StuffPacker.Persistence.Repository;
using StuffPacker.Repositories;
using StuffPacker.ViewModel.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuffPacker.Mapper
{
    public class MemberMapper : IMemberMapper
    {
        private readonly IPackListsRepository _packListsRepository;
        private readonly IPersonalizedProductRepository _personalizedProductRepository;

        public MemberMapper(IPackListsRepository packListsRepository, IPersonalizedProductRepository personalizedProductRepository)
        {
            _packListsRepository = packListsRepository;
            _personalizedProductRepository = personalizedProductRepository;
        }

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
                FriendUserId = friend.FriendUserId
            };
        }

        public async Task<IEnumerable<MemberListItemViewModel>> Map(IEnumerable<UserProfileModel> userProfiles)
        {
            var list = new List<MemberListItemViewModel>();
            foreach (var item in userProfiles)
            {
                list.Add(new MemberListItemViewModel
                {
                    NickName = item.NickName,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    UserId = item.Id,
                    UserImgPath = item.UserImgPath,
                    Packlists = await GetPackListCount(item.Id),
                    Products = await GetProductsList(item.Id)
                });
            }
            return list;
        }

        private async Task<int> GetPackListCount(Guid id)
        {
            var list = await this._packListsRepository.GetByUser(id);
            if(list==null)
            {
                return 0;
            }
            return list.Count();
        }

        private async Task<int> GetProductsList(Guid id)
        {
            var list = await this._personalizedProductRepository.GetByUser(id);
            return list.Count();
        }
    }
}
