using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StuffPacker.Persistence.Model;

namespace StuffPacker.Persistence.Repository
{
    public class PersonalizedProductRepository : IPersonalizedProductRepository
    {
        private readonly StuffPackerDbContext _context;

        public PersonalizedProductRepository(StuffPackerDbContext context)
        {
            _context = context;
        }

        public async Task<PersonalizedProductModel> Get(Guid userId, Guid id)
        {
            var product = await _context.PersonalizedProducts.AsNoTracking().FirstOrDefaultAsync(x => x.UserId == userId && x.ProductId==id);
          if(product==null)
            {
                return null;
            }
                return new PersonalizedProductModel(product);
           
        }

        public async Task<IEnumerable<PersonalizedProductModel>> GetByUser(Guid userId)
        {
            var products = await _context.PersonalizedProducts.AsNoTracking().Where(x => x.UserId == userId).ToListAsync();
            var list = new List<PersonalizedProductModel>();
            foreach (var item in products)
            {
                list.Add(new PersonalizedProductModel(item));
            }
            return list;
        }
    }
}
