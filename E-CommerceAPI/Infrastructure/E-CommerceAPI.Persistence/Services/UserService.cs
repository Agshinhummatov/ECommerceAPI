﻿using E_CommerceAPI.Application.Abstractions.Services;
using E_CommerceAPI.Application.DTOs.User;
using E_CommerceAPI.Application.Exceptions;
using E_CommerceAPI.Application.Features.Commands.AppUser.CreateUser;
using E_CommerceAPI.Application.Helpers;
using E_CommerceAPI.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceAPI.Persistence.Services
{
    public class UserService : IUserService
    {
        readonly UserManager<AppUser> _userManager;

        public UserService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<CreateUserResponse> CreateAsync(CreateUser model)
        {
            IdentityResult result = await _userManager.CreateAsync(new()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = model.Username,
                Email = model.Email,
                NameSurname = model.NameSurname,
            }, model.Password);

            CreateUserResponse response = new() { Succeeded = result.Succeeded };

            if (result.Succeeded)
                response.Message = "Kullanıcı başarıyla oluşturulmuştur.";
            else
                foreach (var error in result.Errors)
                    response.Message += $"{error.Code} - {error.Description}\n";

            return response;
        }

  

        public async Task UpdateRefreshTokenAsync(string refreshToken, AppUser user, DateTime accsessTokenDate, int addOnAccsessTokenDate)
        {
    
            if (user != null)
            {
                user.RefreshToken = refreshToken;
                user.RefreshTokenEndDate = accsessTokenDate.AddSeconds(addOnAccsessTokenDate); 
            }else
            throw new NotFoundUserExeption();
        }


        public async Task UpdatePasswordAsync(string userId, string resetToken, string newPassword)
        {
              AppUser user = await  _userManager.FindByIdAsync(userId);

            if (user != null)
            {
                resetToken = resetToken.UrlDecode();
                IdentityResult result = await _userManager.ResetPasswordAsync(user, resetToken, newPassword);
                if (result.Succeeded)
                    await _userManager.UpdateSecurityStampAsync(user); 
            }
            else
                throw new PasswordChangeFailedExeption();
        }
    }
}
