using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StuffPacker.Persistence.Model;

namespace StuffPacker.Persistence.Repository
{
    public class UserProfileRepository : IUserProfileRepository
    {
        private readonly StuffPackerDbContext _context;
      
        public UserProfileRepository(StuffPackerDbContext context)
        {
            _context = context;
         
        }

        public async Task Add(UserProfileModel model)
        {
            await _context.AddAsync(model.Entity);
            await _context.SaveChangesAsync();
        }

        public async Task<UserProfileModel> Get(Guid userId)
        {
            var product = await _context.UserProfiles.AsNoTracking()
       .FirstOrDefaultAsync(m => m.Id == userId);
            if (product == null)
            {
                return null;
            }
            return new UserProfileModel(product);
        }

        public async Task<IEnumerable<UserProfileModel>> Get()
        {
            var users = await _context.UserProfiles.AsNoTracking().Where(x => x.Deleted.HasValue == false).ToListAsync();
            var list = new List<UserProfileModel>();
            foreach (var item in users)
            {
                list.Add(new UserProfileModel(item));
            }
            return list;
        }
    }
}
