using Microsoft.EntityFrameworkCore;
using SLaw.Application.Repositories;
using SLaw.Domain.Entities.Common;
using SLaw.Persistence.Contexts;

namespace SLaw.Persistence.Repository
{
    public class ReadRepository<TEntity> : IReadRepository<TEntity> where TEntity : BaseEntity
    {
        public ReadRepository(SLawDbContext context)
        {
            this.Table = context.Set<TEntity>();
        }

        public DbSet<TEntity> Table { get; }

        public async Task<TEntity> GetByIdAsync(string id, bool tracking = true)
        {
            IQueryable<TEntity> query = this.GetAll(tracking);

            return await query.FirstAsync(x => x.Id == Guid.Parse(id));
        }

        public IQueryable<TEntity> GetAll(bool tracking = true)
        {
            IQueryable<TEntity> query = this.Table.AsQueryable();

            if (tracking == false)
            {
                query = query.AsNoTracking();
            }

            return query;
        }
    }
}
