using AutoMapper;
using SLaw.Application.Features.Commands.Lawyers.Create;
using SLaw.Application.Features.Queries.Lawyers.GetAll;
using SLaw.Domain.Entities;

namespace SLaw.Application.Mappings
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            //Lawyer Mapping
            this.CreateMap<CreateLawyerCommandRequest, Lawyer>();

            this.CreateMap<Lawyer, GetAllLawyersQueryResponse>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.Name} {src.Surname}"));
        }
    }
}
