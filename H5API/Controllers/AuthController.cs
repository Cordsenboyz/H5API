using H5API.Data;
using H5API.Dto.User;
using H5API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SkoErpApi.Services;
using System.IdentityModel.Tokens.Jwt;

namespace H5API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;
        public readonly UserManager<User> _userManager;
        public readonly RoleManager<Role> _roleManager;
        private readonly IClaimsService _claimsService;
        private readonly IJwtTokenService _jwtTokenService;
        private readonly IConfiguration _configuration;

        public AuthController(UnitOfWork unitOfWork, UserManager<User> user, RoleManager<Role> role, IClaimsService claimsService, IJwtTokenService jwtTokenService, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _userManager = user;
            _roleManager = role;
            _claimsService = claimsService;
            _jwtTokenService = jwtTokenService;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Register(UserRegisterDTO userRegisterDTO)
        {
            IdentityResult result;

            User newUser = new()
            {
                Email = userRegisterDTO.Email,
                UserName = userRegisterDTO.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
            };

            result = await _userManager.CreateAsync(newUser, userRegisterDTO.Password);

            if (!result.Succeeded)
                return BadRequest();

            return NoContent();
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Login(UserLoginDTO userLoginDTO)
        {
            var user = await _userManager.FindByEmailAsync(userLoginDTO.Email);

            if (user != null && await _userManager.CheckPasswordAsync(user, userLoginDTO.Password))
            {
                var userClaims = await _claimsService.GetUserClaimsAsync(user);

                var token = _jwtTokenService.GetJwtToken(userClaims);

                await _userManager.UpdateAsync(user);

                return Ok(new UserLoginResultDTO
                {
                    Succeeded = true,
                    Token = new TokenDTO
                    {
                        Token = new JwtSecurityTokenHandler().WriteToken(token),
                        Expiration = token.ValidTo
                    }
                });
            }

            return Unauthorized(new UserLoginResultDTO
            {
                Succeeded = false,
                Message = "The email and password combination was invalid."
            });
        }
    }
}
