using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StuffPacker.Model;

namespace StuffPacker.Persistence
{
    public class StuffPackerDbContext : IdentityDbContext
    {
        public StuffPackerDbContext(DbContextOptions<StuffPackerDbContext> options) : base(options)
        {
        }

        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<PackListEntity> PackLists { get; set; }


        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ProductEntity>().ToTable("Products");
            modelBuilder.Entity<PackListEntity>().ToTable("PackLists");
        }
    }
}
