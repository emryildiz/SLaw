using SLaw.Application.Repositories.About;
using SLaw.Domain.Entities;
using SLaw.Persistence.Contexts;

namespace SLaw.Persistence.Repository.About
{
    public class AboutReadRepository : ReadRepository<AboutUs>, IAboutReadRepository
    {
        public AboutReadRepository(SLawDbContext context) : base(context) { }
    }
}
