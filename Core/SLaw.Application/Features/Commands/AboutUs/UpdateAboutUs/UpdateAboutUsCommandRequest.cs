using MediatR;

namespace SLaw.Application.Features.Commands.AboutUs.UpdateAboutUs
{
    public class UpdateAboutUsCommandRequest : IRequest
    {
        public string Description { get; set; }
    }
}
