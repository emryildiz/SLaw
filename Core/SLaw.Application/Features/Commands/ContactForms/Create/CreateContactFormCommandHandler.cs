using AutoMapper;
using MediatR;
using SLaw.Application.Repositories.ContactForms;
using SLaw.Domain.Entities;

namespace SLaw.Application.Features.Commands.ContactForms.Create
{
    public class CreateContactFormCommandHandler : IRequestHandler<CreateContactFormCommandRequest>
    {
        private readonly IContactFormWriteRepository _contactFormWriteRepository;
        private readonly IMapper _mapper;

        public CreateContactFormCommandHandler(IContactFormWriteRepository contactFormWriteRepository, IMapper mapper)
        {
            this._contactFormWriteRepository = contactFormWriteRepository;
            this._mapper = mapper;
        }

        public async Task Handle(CreateContactFormCommandRequest request, CancellationToken cancellationToken)
        {
            ContactForm contactForm = this._mapper.Map<ContactForm>(request);
            await this._contactFormWriteRepository.AddAsync(contactForm);
            await this._contactFormWriteRepository.SaveChangesAsync();
        }
    }
}
