using MediatR;
using SLaw.Application.Repositories.Lawyers;

namespace SLaw.Application.Features.Commands.Lawyers.Delete
{
    public class DeleteLawyerCommandHandler :IRequestHandler<DeleteLawyerCommandRequest>
    {
        private readonly ILawyerWriteRepository _writeRepository;

        public DeleteLawyerCommandHandler(ILawyerWriteRepository writeRepository)
        {
            this._writeRepository = writeRepository;
        }

        public async Task Handle(DeleteLawyerCommandRequest request, CancellationToken cancellationToken)
        {
            await this._writeRepository.DeleteByIdAsync(request.Id);
            await this._writeRepository.SaveChangesAsync();
        }
    }
}
