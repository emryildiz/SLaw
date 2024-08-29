using SLaw.Application.Repositories.Lawyers;
using SLaw.Domain.Entities;
using SLaw.Persistence.Contexts;

namespace SLaw.Persistence.Repository.Lawyers
{
    public class LawyerReadRepository : ReadRepository<Lawyer>, ILawyerReadRepository
    {
        public LawyerReadRepository(SLawDbContext context) : base(context) { }
    }
}
