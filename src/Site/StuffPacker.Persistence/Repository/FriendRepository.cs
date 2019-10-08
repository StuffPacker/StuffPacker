using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StuffPacker.Persistence.Model;

namespace StuffPacker.Persistence.Repository
{
    public class FriendRepository : IFriendRepository
    {
        private readonly StuffPackerDbContext _context;

        public FriendRepository(StuffPackerDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FriendModel>> GetFriends(Guid userId)
        {
            var lists = await _context.Friends.Where(x => x.UserId == userId).AsNoTracking().ToListAsync();
            if (!lists.Any())
            {
                return null;
            }
            var list = new List<FriendModel>();
            foreach (var item in lists)
            {
                list.Add(new FriendModel(item));
            }
            return list;
        }
    }





}
