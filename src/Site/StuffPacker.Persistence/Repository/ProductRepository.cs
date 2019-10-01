﻿using Microsoft.EntityFrameworkCore;
using StuffPacker.Model;
using StuffPacker.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task Delete(Guid id)
        {
            var modelToUpdate = await _context.Products.FirstOrDefaultAsync(s => s.Id == id);
            _context.Remove(modelToUpdate);
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

        public async Task<IEnumerable<ProductModel>> GetByOwner(Guid userId)
        {
            var products = await _context.Products.AsNoTracking().Where(x=>x.Owner==userId).ToListAsync();
            var list = new List<ProductModel>();
            foreach (var item in products)
            {
                list.Add(new ProductModel(item));
            }
            return list;
        }

        public async Task Update(ProductModel model)
        {
            var modelToUpdate = await _context.Products.FirstOrDefaultAsync(s => s.Id == model.Id);
            modelToUpdate.Name = model.Name;
            modelToUpdate.Weight = model.Entity.Weight;
            modelToUpdate.WeightPrefix = model.Entity.WeightPrefix;
            await _context.SaveChangesAsync();
        }
    }
}
