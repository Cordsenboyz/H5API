using H5API.Data;
using H5API.Dto.Create;
using H5API.Dto.Update;
using H5API.Dto.User;
using H5API.Models;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using SkoErpApi.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace H5API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;
        public readonly UserManager<User> _userManager;
        public readonly RoleManager<Role> _roleManager;
        private readonly IConfiguration _configuration;

        public UserController(UnitOfWork unitOfWork, UserManager<User> user, RoleManager<Role> role, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _userManager = user;
            _roleManager = role;
            _configuration = configuration;
        }

        [Authorize]
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Get()
        {
            string? email = User.Claims.Where(x => x.Type == ClaimTypes.Email).FirstOrDefault()?.Value;
            User? user = await _userManager.FindByEmailAsync(email);

            return Ok(user);
        }

        [Authorize]
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAll()
        {
            var users = _userManager.Users.ToList();

            return Ok(users);
        }

/*      [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Create(CreateUserDto user)
        {
            await _unitOfWork.Users.AddAsync(user.Adapt<User>());
            await _unitOfWork.SaveChangesAsync();

            return Created();
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> Update(User updateUser)
        {
            User user = await _unitOfWork.Users.GetAsync(updateUser.Id);

            TypeAdapter.Adapt(updateUser, user, typeof(User), typeof(User));

            await _unitOfWork.Users.UpdateAsync(user);
            await _unitOfWork.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete]
        [Route("[action]")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            await _unitOfWork.Users.DeleteAsync(Id);
            await _unitOfWork.SaveChangesAsync();

            return NoContent();
        }*/
    }
}
