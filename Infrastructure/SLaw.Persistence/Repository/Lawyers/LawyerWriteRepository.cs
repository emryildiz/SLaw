using SLaw.Application.Repositories.Lawyers;
using SLaw.Domain.Entities;
using SLaw.Persistence.Contexts;

namespace SLaw.Persistence.Repository.Lawyers
{
    public class LawyerWriteRepository : WriteRepository<Lawyer>, ILawyerWriteRepository
    {
        public LawyerWriteRepository(SLawDbContext context) : base(context) { }
    }
}
