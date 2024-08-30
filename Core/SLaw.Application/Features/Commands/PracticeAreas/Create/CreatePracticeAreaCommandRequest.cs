using MediatR;
using Microsoft.AspNetCore.Http;

namespace SLaw.Application.Features.Commands.PracticeAreas.Create
{
    public class CreatePracticeAreaCommandRequest : IRequest
    {
        public string Name { get; set; }

        public FormFile Image { get; set; }

        public string Description { get; set; }
    }
}
