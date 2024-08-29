using SLaw.Application.Repositories.PraticeAreas;
using SLaw.Domain.Entities;
using SLaw.Persistence.Contexts;

namespace SLaw.Persistence.Repository.PracticeAreas
{
    public class PracticeAreaWriteRepository : WriteRepository<PracticeArea>, IPracticeAreaWriteRepository
    {
        public PracticeAreaWriteRepository(SLawDbContext context) : base(context) { }
    }
}
