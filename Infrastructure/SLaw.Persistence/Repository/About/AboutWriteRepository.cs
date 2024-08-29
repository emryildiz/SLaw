using SLaw.Application.Repositories.About;
using SLaw.Domain.Entities;
using SLaw.Persistence.Contexts;

namespace SLaw.Persistence.Repository.About
{
    public class AboutWriteRepository : WriteRepository<AboutUs>, IAboutWriteRepository
    {
        public AboutWriteRepository(SLawDbContext context) : base(context) { }
    }
}
