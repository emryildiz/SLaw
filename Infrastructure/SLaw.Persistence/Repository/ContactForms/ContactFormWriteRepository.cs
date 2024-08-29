using SLaw.Application.Repositories.ContactForms;
using SLaw.Domain.Entities;
using SLaw.Persistence.Contexts;

namespace SLaw.Persistence.Repository.ContactForms
{
    public class ContactFormWriteRepository : WriteRepository<ContactForm>, IContactFormWriteRepository
    {
        public ContactFormWriteRepository(SLawDbContext context) : base(context) { }
    }
}
