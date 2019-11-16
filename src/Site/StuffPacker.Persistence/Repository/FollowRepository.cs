using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StuffPacker.Persistence.Entity;
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

        public async Task<FollowModel> Get(Guid currentUser, Guid userId)
        {
            var list = await _context.Follows.AsNoTracking().FirstOrDefaultAsync(x => x.UserId == currentUser && x.FollowUserId==userId && x.Deleted.HasValue == false);
            if (list == null)
            {
                return null;
            }
            return new FollowModel(list);
        }

        public async Task<IEnumerable<FollowModel>> GetFollowers(Guid userId)
        {
            var lists = await _context.Follows.Where(x => x.FollowUserId == userId && x.Deleted.HasValue==false).AsNoTracking().ToListAsync();
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
            var lists = await _context.Follows.Where(x => x.UserId == userId && x.Deleted.HasValue == false).AsNoTracking().ToListAsync();
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

        public async Task Delete(FollowModel model)
        {
            var modelToUpdate = await _context.Follows.FirstOrDefaultAsync(s => s.Id == model.Id);
            _context.Remove(modelToUpdate);
            await _context.SaveChangesAsync();
        }

        public async Task Add(FollowModel model)
        {
            _context.Add(model.Entity);
            await _context.SaveChangesAsync();
        }
    }
}
