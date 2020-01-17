using Microsoft.EntityFrameworkCore;
using StuffPacker.Persistence.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuffPacker.Persistence.Repository
{
    public class ProductGroupRepository : IProductGroupRepository
    {
        private readonly StuffPackerDbContext _context;

        public ProductGroupRepository(StuffPackerDbContext context)
        {
            _context = context;

        }

        public async Task Add(ProductGroupModel model)
        {
            _context.Add(model.Entity);
            await _context.SaveChangesAsync();
        }

        public async  Task Delete(Guid id)
        {
            var modelToUpdate = await _context.ProductGroups.FirstOrDefaultAsync(s => s.Id == id);
            _context.Remove(modelToUpdate);
            await _context.SaveChangesAsync();
        }

        public async Task<ProductGroupModel> GetByName(Guid userId, string name)
        {
            var models = await _context.ProductGroups.AsNoTracking().Where(x => x.Name == name).FirstOrDefaultAsync();
            if (models == null)
            {
                return null;
            }

            return new ProductGroupModel(models);

        }

        public async Task<IEnumerable<ProductGroupModel>> GetByUser(Guid userId)
        {
            try
            {
                var models = await _context.ProductGroups.AsNoTracking().Where(x => x.Owner == userId).ToListAsync();
                var list = new List<ProductGroupModel>();
                foreach (var item in models)
                {
                    list.Add(new ProductGroupModel(item));
                }
                return list;
            }
            catch (Exception e)
            {
                var bla = "";
                throw;
            }
          
        }

        public async Task UpdateMaximized(Guid id, bool maximized)
        {
            var model = await _context.ProductGroups.FirstOrDefaultAsync(x => x.Id == id);
            if (model == null)
            {
                throw new DllNotFoundException();
            }
            model.UpdateMaximized(maximized);

            await _context.SaveChangesAsync();
        }
    }
}
