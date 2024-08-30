using MediatR;
using Microsoft.AspNetCore.Http;

namespace SLaw.Application.Features.Commands.PracticeAreas.Update
{
    public class UpdatePracticeAreaCommandRequest : IRequest
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public FormFile Image { get; set; }

        public string Description { get; set; }
    }
}
