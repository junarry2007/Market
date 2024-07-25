using MarketPlus.Domain.Abstractions;
using MarketPlus.Domain.Products;
using MarketPlus.Infrastructure.Seeders;
using Microsoft.EntityFrameworkCore;

namespace MarketPlus.Infrastructure.Contexts
{
    public sealed class ApplicationDbContext : DbContext, IUnitOfWork
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var result = await base.SaveChangesAsync(cancellationToken);
            return result;
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Configure entities         
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            //Seeders
            //Configure seeders
            new ProductSeeder(builder.Entity<Product>());

            base.OnModelCreating(builder);
        }
    }
}
