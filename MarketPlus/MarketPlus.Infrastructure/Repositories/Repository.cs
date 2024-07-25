using MarketPlus.Domain.Abstractions;
using MarketPlus.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace MarketPlus.Infrastructure.Repositories
{
    internal abstract class Repository<T> where T : Entity
    {
        protected readonly ApplicationDbContext DbContext;
        protected Repository(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }
        public async Task<IReadOnlyList<T?>> GetAll(CancellationToken cancellationToken = default)
        {
            return await DbContext.Set<T>().ToListAsync(cancellationToken);
        }
        public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await DbContext.Set<T>().FirstOrDefaultAsync(product => product.Id == id, cancellationToken);
        }
        public void Add(T entity)
        {
            DbContext.Add(entity);
        }
        public void Update(T entity)
        {
            DbContext.Entry(entity).State = EntityState.Modified;
        }
        public void Delete(T entity)
        {
            DbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
