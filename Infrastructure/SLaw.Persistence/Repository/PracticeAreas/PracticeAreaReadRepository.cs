using SLaw.Application.Repositories.PraticeAreas;
using SLaw.Domain.Entities;
using SLaw.Persistence.Contexts;

namespace SLaw.Persistence.Repository.PracticeAreas
{
    public class PracticeAreaReadRepository : ReadRepository<PracticeArea>, IPracticeAreaReadRepository
    {
        public PracticeAreaReadRepository(SLawDbContext context) : base(context) { }
    }
}
