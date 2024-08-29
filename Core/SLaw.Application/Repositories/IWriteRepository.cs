using Microsoft.EntityFrameworkCore;
using SLaw.Domain.Entities.Common;

namespace SLaw.Application.Repositories
{
    public interface IWriteRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        public Task AddAsync(TEntity entity);

        public void Update(TEntity entity);

        public void Delete(TEntity entity);

        public Task DeleteByIdAsync(string id);

        public Task SaveChangesAsync();
    }
}
