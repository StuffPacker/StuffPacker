using Microsoft.EntityFrameworkCore;
using StuffPacker.Model;
using StuffPacker.Repositories;
using System;
using System.Threading.Tasks;

namespace StuffPacker.Persistence.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly StuffPackerDbContext _context;

        public ProductRepository(StuffPackerDbContext context)
        {
            _context = context;
        }

        public async Task Add(ProductModel model)
        {
            _context.Add(model.Entity);
            await _context.SaveChangesAsync();
        }

        public async Task<ProductModel> Get(Guid id)
        {
            var product = await _context.Products.AsNoTracking()
        .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return null;
            }
            return new ProductModel(product);
        }

        public async Task Update(ProductModel model)
        {
            var modelToUpdate = await _context.Products.FirstOrDefaultAsync(s => s.Id == model.Id);
            modelToUpdate.Name = model.Name;
            modelToUpdate.Weight = model.Entity.Weight;
            await _context.SaveChangesAsync();
        }
    }
}
