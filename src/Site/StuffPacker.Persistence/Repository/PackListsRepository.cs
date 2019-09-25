using Microsoft.EntityFrameworkCore;
using StuffPacker.Model;
using StuffPacker.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuffPacker.Persistence.Repository
{
    public class PackListsRepository : IPackListsRepository
    {
        private readonly StuffPackerDbContext _context;

        public PackListsRepository(StuffPackerDbContext context)
        {
            _context = context;
        }

        public async Task Add(PackListModel model)
        {
           
                _context.Add(model.Entity);
                await _context.SaveChangesAsync();
         
           
        }

        public async Task<IEnumerable<PackListModel>> Get()
        {
            var lists = await _context.PackLists.AsNoTracking()
      .ToListAsync();
            if (!lists.Any())
            {
                return null;
            }
            var list = new List<PackListModel>();


            foreach (var item in lists)
            {
                list.Add(new PackListModel(item));
            }


            return list;
        }

        public async Task<PackListModel> Get(Guid id)
        {
            var list = await _context.PackLists.AsNoTracking().FirstOrDefaultAsync(x=>x.Id==id);
            if(list==null)
            {
                return null;
            }
            return new PackListModel(list);
        }

        public async Task Update(PackListModel model)
        {
            var modelToUpdate = await _context.PackLists.FirstOrDefaultAsync(s => s.Id == model.Id);
            modelToUpdate.Name = model.Name;
            await _context.SaveChangesAsync();
            
            
           
        }
    }
}
