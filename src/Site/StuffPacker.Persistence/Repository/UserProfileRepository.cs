using System;
using System.Collections.Generic;
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
            _context.Add(model.Entity);
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
    }
}
