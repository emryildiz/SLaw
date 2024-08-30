using AutoMapper;
using MediatR;
using SLaw.Application.Absractions.Services.Users;
using SLaw.Application.Dtos;

namespace SLaw.Application.Features.Commands.Users.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IUserService userService, IMapper mapper)
        {
            this._userService = userService;
            this._mapper = mapper;
        }

        public async Task Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            CreateUserDto createUserDto = this._mapper.Map<CreateUserDto>(request);

            await this._userService.CreateAsync(createUserDto);
        }
    }
}
