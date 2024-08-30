using MediatR;
using SLaw.Application.Repositories.ContactForms;

namespace SLaw.Application.Features.Commands.ContactForms.Delete
{
    public class DeleteContactFormCommandHandler : IRequestHandler<DeleteContactFormCommandRequest>
    {
        private readonly IContactFormWriteRepository _contactFormWriteRepository;

        public DeleteContactFormCommandHandler(IContactFormWriteRepository contactFormWriteRepository)
        {
            this._contactFormWriteRepository = contactFormWriteRepository;
        }

        public async Task Handle(DeleteContactFormCommandRequest request, CancellationToken cancellationToken)
        {
            await this._contactFormWriteRepository.DeleteByIdAsync(request.Id);
            await this._contactFormWriteRepository.SaveChangesAsync();
        }
    }
}
