using SLaw.Application.Dtos;
using SLaw.Domain.Entities.Identity;

namespace SLaw.Application.Absractions.Services.Users
{
    public interface IUserService
    {
        public Task CreateAsync(CreateUserDto createUserDto);

        public Task UpdateRefreshTokenAsync(string refreshToken, AppUser user, DateTime accessTokenDate, int addOnAccessTokenDate);

        public Task<List<ListUserDto>> GetAllUserAsync(int page, int size);

        public Task AssignRoleToUserAsync(string userId, string[] roles);

        public Task<string[]> GetRolesToUserAsync(string userIdOrUserName);

        public Task<bool> HasRolePermissionToEndpointAsync(string name, string code);

        public int TotalUsersCount { get; }
    }
}
