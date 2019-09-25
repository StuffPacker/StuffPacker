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
    }
}
