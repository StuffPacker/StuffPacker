using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shared.Contract;
using StuffPacker.Model;
using StuffPacker.Persistence.Entity;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StuffPacker.Persistence
{
    public class StuffPackerDbContext : IdentityDbContext
    {
        private readonly ICurrentUser _currentUser;

        public StuffPackerDbContext(DbContextOptions<StuffPackerDbContext> options, ICurrentUser currentUser) : base(options)
        {
            _currentUser = currentUser;
        }

        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<PackListEntity> PackLists { get; set; }
        public DbSet<PersonalizedProductEntity> PersonalizedProducts { get; set; }

        public DbSet<FriendEntity> Friends { get; set; }
        public DbSet<UserProfileEntity> UserProfiles { get; set; }

        public DbSet<FollowEntity> Follows { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ProductEntity>().ToTable("Products");
            modelBuilder.Entity<PackListEntity>().ToTable("PackLists");
        }
        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker
       .Entries()
       .Where(e => e.Entity is SoftDeleteEntityBase && (
               e.State == EntityState.Added
               || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((SoftDeleteEntityBase)entityEntry.Entity).Modified = DateTimeOffset.UtcNow;
                ((SoftDeleteEntityBase)entityEntry.Entity).ModifiedBy = GetUser();

                if (entityEntry.State == EntityState.Added)
                {
                    ((SoftDeleteEntityBase)entityEntry.Entity).Created = DateTimeOffset.UtcNow;
                    ((SoftDeleteEntityBase)entityEntry.Entity).CreatedBy = GetUser();
                }
            }

            return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private string GetUser()
        {
            return _currentUser.GetUserName();
        }
    }
}
