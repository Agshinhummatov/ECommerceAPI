using E_CommerceAPI.Application.DTOs.User;
using E_CommerceAPI.Domain.Entities.Identity;

namespace E_CommerceAPI.Application.Abstractions.Services
{
    public interface IUserService
    {
        Task<CreateUserResponse> CreateAsync(CreateUser model);
        Task UpdateRefreshTokenAsync(string refreshToken, AppUser user, DateTime accsessTokenDate, int addOnAccsessTokenDate);

        Task UpdatePasswordAsync(string userId, string resetToken, string newPassword);

    }
}
