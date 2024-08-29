using Microsoft.EntityFrameworkCore;
using SLaw.Domain.Entities.Common;

namespace SLaw.Application.Repositories
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        public DbSet<TEntity> Table { get; }
    }
}
