using SLaw.Domain.Entities.Common;

namespace SLaw.Application.Repositories
{
    public interface IReadRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        public Task<TEntity> GetByIdAsync(string id, bool tracking = true);

        public IQueryable<TEntity> GetAll(bool tracking = true);
    }
}
