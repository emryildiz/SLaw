using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SLaw.Application.Repositories.PraticeAreas;

namespace SLaw.Application.Features.Commands.PracticeAreas.Delete
{
    public class DeletePracticeAreaCommandHandler : IRequestHandler<DeletePracticeAreaCommandRequest>
    {
        private readonly IPracticeAreaWriteRepository _repository;

        public DeletePracticeAreaCommandHandler(IPracticeAreaWriteRepository repository)
        {
            this._repository = repository;
        }

        public async Task Handle(DeletePracticeAreaCommandRequest request, CancellationToken cancellationToken)
        {
            await this._repository.DeleteByIdAsync(request.Id);
            await this._repository.SaveChangesAsync();
        }
    }
}
