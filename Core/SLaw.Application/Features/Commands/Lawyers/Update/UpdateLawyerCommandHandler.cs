using MediatR;
using SLaw.Application.Repositories.Lawyers;
using SLaw.Domain.Entities;

namespace SLaw.Application.Features.Commands.Lawyers.Update
{
    public class UpdateLawyerCommandHandler : IRequestHandler<UpdateLawyerCommandRequest>
    {
        private readonly ILawyerWriteRepository _lawyerWriteRepository;
        private readonly ILawyerReadRepository _lawyerReadRepository;

        public UpdateLawyerCommandHandler(ILawyerWriteRepository lawyerWriteRepository, ILawyerReadRepository lawyerReadRepository)
        {
            this._lawyerWriteRepository = lawyerWriteRepository;
            this._lawyerReadRepository = lawyerReadRepository;
        }

        public async Task Handle(UpdateLawyerCommandRequest request, CancellationToken cancellationToken)
        {
            Lawyer lawyer = await this._lawyerReadRepository.GetByIdAsync(request.Id);

            lawyer.Name = request.Name;
            lawyer.Surname = request.Surname;
            lawyer.Email = request.Email;
            lawyer.CellPhone = request.CellPhone;
            lawyer.Phone = request.Phone;
            lawyer.Title = request.Title;

            await this._lawyerWriteRepository.SaveChangesAsync();
        }
    }
}
