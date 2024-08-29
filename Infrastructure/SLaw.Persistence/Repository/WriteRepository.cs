using Microsoft.EntityFrameworkCore;
using SLaw.Application.Repositories;
using SLaw.Domain.Entities.Common;
using SLaw.Persistence.Contexts;

namespace SLaw.Persistence.Repository
{
    public class WriteRepository<TEntity> : IWriteRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly SLawDbContext _context;

        public WriteRepository(SLawDbContext context)
        {
            this._context = context;

            this.Table = this._context.Set<TEntity>();
        }

        public DbSet<TEntity> Table { get; }

        public async Task AddAsync(TEntity entity) => await this.Table.AddAsync(entity);

        public void Update(TEntity entity) => this.Table.Update(entity);

        public void Delete(TEntity entity) => this.Table.Remove(entity);

        public async Task DeleteByIdAsync(string id)
        {
            TEntity entity = await this.Table.FirstAsync(x => x.Id == Guid.Parse(id));

            this.Table.Remove(entity);
        }

        public async Task SaveChangesAsync()
        {
            await this._context.SaveChangesAsync();
        }
    }
}
