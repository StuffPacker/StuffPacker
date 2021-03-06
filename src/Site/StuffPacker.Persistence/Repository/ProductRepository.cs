﻿using Microsoft.EntityFrameworkCore;
using Shared.Contract;
using StuffPacker.Model;
using StuffPacker.Persistence.Model;
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
        private readonly ICurrentUser _currentUser;
        public ProductRepository(StuffPackerDbContext context, ICurrentUser currentUser)
        {
            _context = context;
            _currentUser = currentUser;
        }

        public async Task Add(ProductModel model)
        {
            await _context.AddAsync(model.Entity);
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
            var products = await _context.Products.AsNoTracking().Where(x => x.Owner == userId).ToListAsync();
            var list = new List<ProductModel>();
            foreach (var item in products)
            {
                list.Add(new ProductModel(item));
            }
            return list;


        }

        public async Task Update(ProductModel model, PersonalizedProductModel pModel)
        {

            var modelToUpdate = await _context.Products.FirstOrDefaultAsync(s => s.Id == model.Id);
            modelToUpdate.Name = model.Name;
            modelToUpdate.Weight = model.Entity.Weight;
            modelToUpdate.WeightPrefix = model.Entity.WeightPrefix;
            modelToUpdate.Description = model.Entity.Description;
            modelToUpdate.Images = model.Entity.Images;
            var userId = _currentUser.GetUserId();
            var personalizedProductsModel = await _context.PersonalizedProducts.FirstOrDefaultAsync(x => x.ProductId == model.Id && x.UserId == userId);
            if (personalizedProductsModel != null)
            {
                personalizedProductsModel.Category = pModel.Category;
                personalizedProductsModel.Star = pModel.Star;
                personalizedProductsModel.Wearable = pModel.Wearable;
                personalizedProductsModel.Consumables = pModel.Consumables;
            }
            else
            {
                PersonalizedProductModel pp = new PersonalizedProductModel(Guid.NewGuid(), userId, model.Id);
                pp.Update(pModel.Category, pModel.Star, pModel.Wearable, pModel.Consumables);
                await _context.AddAsync(pp.Entity);
            }

            await _context.SaveChangesAsync();


        }

        public async Task Update(ProductModel model)
        {
            var modelToUpdate = await _context.Products.FirstOrDefaultAsync(s => s.Id == model.Id);
            modelToUpdate.Name = model.Name;
            modelToUpdate.Weight = model.Entity.Weight;
            modelToUpdate.WeightPrefix = model.Entity.WeightPrefix;
            modelToUpdate.Description = model.Entity.Description;
            modelToUpdate.Images = model.Entity.Images;
            var userId = _currentUser.GetUserId(); 

            await _context.SaveChangesAsync();
        }
    }
}
