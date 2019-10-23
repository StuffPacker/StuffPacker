using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StuffPacker.Persistence.Model;

namespace StuffPacker.Persistence.Repository
{
    public class FollowRepository : IFollowRepository
    {
        private readonly StuffPackerDbContext _context;

        public FollowRepository(StuffPackerDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<FollowModel>> GetFollowers(Guid userId)
        {
            var lists = await _context.Follows.Where(x => x.FollowUserId == userId).AsNoTracking().ToListAsync();
            if (!lists.Any())
            {
                return null;
            }
            var list = new List<FollowModel>();
            foreach (var item in lists)
            {
                list.Add(new FollowModel(item));
            }
            return list;
        }

        public async Task<IEnumerable<FollowModel>> GetFollowing(Guid userId)
        {
            var lists = await _context.Follows.Where(x => x.UserId == userId).AsNoTracking().ToListAsync();
            if (!lists.Any())
            {
                return null;
            }
            var list = new List<FollowModel>();
            foreach (var item in lists)
            {
                list.Add(new FollowModel(item));
            }
            return list;
        }
    }
}
