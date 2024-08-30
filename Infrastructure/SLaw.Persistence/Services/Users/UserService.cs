using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using SLaw.Application.Absractions.Services.Users;
using SLaw.Application.Dtos;
using SLaw.Application.Exceptions;
using SLaw.Domain.Entities.Identity;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SLaw.Domain.Entities;

namespace SLaw.Persistence.Services.Users
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;

        public UserService(UserManager<AppUser> userManager)
        {
            this._userManager = userManager;
        }

        public async Task CreateAsync(CreateUserDto createUserDto)
        {
            IdentityResult result = await this._userManager.CreateAsync(new()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = createUserDto.Username,
                Email = createUserDto.Email,
                Name = createUserDto.Name,
                Surname = createUserDto.Surname
            }, createUserDto.Password);

            if (result.Succeeded == false) { throw new UserCreationErrorException(); }
        }

        public async Task UpdateRefreshTokenAsync(string refreshToken, AppUser user, DateTime accessTokenDate, int addOnAccessTokenDate)
        {
            if (user != null)
            {
                user.RefreshToken        = refreshToken;
                user.RefreshTokenEndDate = accessTokenDate.AddSeconds(addOnAccessTokenDate);
                await this._userManager.UpdateAsync(user);
            }
            else
            {
                throw new NotFoundUserException();
            }
        }

        public async Task UpdatePasswordAsync(string userId, string resetToken, string newPassword)
        {
            AppUser user = await this._userManager.FindByIdAsync(userId);

            if (user != null)
            {
                byte[] tokenBytes = WebEncoders.Base64UrlDecode(resetToken);
                resetToken = Encoding.UTF8.GetString(tokenBytes);

                IdentityResult result = await this._userManager.ResetPasswordAsync(user, resetToken, newPassword);

                if (result.Succeeded)
                {
                    await this._userManager.UpdateSecurityStampAsync(user);
                }
                else
                {
                    throw new PasswordChangeFailedException();
                }
            }
        }

        public async Task<List<ListUserDto>> GetAllUserAsync(int page, int size)
        {
            List<AppUser> users = await this._userManager.Users
                                            .Skip(page * size)
                                            .Take(size)
                                            .ToListAsync();

            return users.Select(user => new ListUserDto
            {
                Id               = user.Id,
                Email            = user.Email,
                FullName         = $"{user.Name} {user.Surname}",
                UserName         = user.UserName
            }).ToList();
        }

        public async Task AssignRoleToUserAsync(string userId, string[] roles)
        {
            AppUser user = await this._userManager.FindByIdAsync(userId);

            if (user is null) { throw new NotFoundUserException(); }

            IList<string> userRoles = await this._userManager.GetRolesAsync(user);
            await this._userManager.RemoveFromRolesAsync(user, userRoles);

            await this._userManager.AddToRolesAsync(user, roles);
        }

        public async Task<string[]> GetRolesToUserAsync(string userIdOrUserName)
        {
            AppUser user = await this._userManager.FindByIdAsync(userIdOrUserName) ?? await this._userManager.FindByNameAsync(userIdOrUserName);

            if (user != null)
            {
                IList<string> userRoles = await this._userManager.GetRolesAsync(user);

                return userRoles.ToArray();
            }

            return Array.Empty<string>();
        }

        public async Task<bool> HasRolePermissionToEndpointAsync(string name, string code)
        {
            await Task.Run(() => Thread.Sleep(100));

            return true;
        }

        public int TotalUsersCount => this._userManager.Users.Count();
    }
}
