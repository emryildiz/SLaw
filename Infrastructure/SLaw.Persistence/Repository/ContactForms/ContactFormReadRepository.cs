using SLaw.Application.Repositories.ContactForms;
using SLaw.Domain.Entities;
using SLaw.Persistence.Contexts;

namespace SLaw.Persistence.Repository.ContactForms
{
    public class ContactFormReadRepository : ReadRepository<ContactForm>, IContactFormReadRepository
    {
        public ContactFormReadRepository(SLawDbContext context) : base(context) { }
    }
}
