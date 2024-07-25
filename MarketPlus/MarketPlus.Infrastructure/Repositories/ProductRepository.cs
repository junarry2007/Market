using MarketPlus.Domain.Products;
using MarketPlus.Infrastructure.Contexts;

namespace MarketPlus.Infrastructure.Repositories
{
    internal sealed class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
