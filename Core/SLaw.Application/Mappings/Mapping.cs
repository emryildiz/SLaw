using AutoMapper;
using SLaw.Application.Dtos;
using SLaw.Application.Features.Commands.ContactForms.Create;
using SLaw.Application.Features.Commands.Lawyers.Create;
using SLaw.Application.Features.Commands.PracticeAreas.Create;
using SLaw.Application.Features.Commands.Users.Create;
using SLaw.Application.Features.Queries.AboutUs.GetAboutUs;
using SLaw.Application.Features.Queries.ContactForms.GetAll;
using SLaw.Application.Features.Queries.Lawyers.GetAll;
using SLaw.Application.Features.Queries.PracticeAreas.GetAll;
using SLaw.Application.Features.Queries.PracticeAreas.GetById;
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

            //User
            this.CreateMap<CreateUserCommandRequest, CreateUserDto>();

            //ContactForm
            this.CreateMap<CreateContactFormCommandRequest, ContactForm>();
            this.CreateMap<ContactForm, GetAllContactFormQueryResponse>();

            //PracticeArea
            this.CreateMap<CreatePracticeAreaCommandRequest, PracticeArea>();
            this.CreateMap<PracticeArea, GetAllPracticeAreaQueryResponse>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()));
            this.CreateMap<PracticeArea, GetByIdPracticeAreaQueryResponse>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()));

            //AboutUs
            this.CreateMap<AboutUs, GetAboutUsQueryResponse>();
        }
    }
}
