﻿using H5API.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace SkoErpApi.Services
{
    public interface IClaimsService
    {
        Task<List<Claim>> GetUserClaimsAsync(User user);
    }

    public class ClaimsService : IClaimsService
    {
        private readonly UserManager<User> _userManager;

        public ClaimsService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<List<Claim>> GetUserClaimsAsync(User user)
        {
            List<Claim> userClaims = new()
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
            };

            var userRoles = await _userManager.GetRolesAsync(user);

            foreach (var userRole in userRoles)
            {
                userClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            return userClaims;
        }
    }
}
