using H5API.Data;
using H5API.Dto.Create;
using H5API.Models;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System.Security.Claims;

namespace H5API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;
        public readonly UserManager<User> _userManager;

        public OrderController(UnitOfWork unitOfWork, UserManager<User> user)
        {
            _unitOfWork = unitOfWork;
            _userManager = user;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Get(Guid Id)
        {
            Order order = await _unitOfWork.Orders.GetWithRelationsAsnyc(Id);

            return Ok(order);
        }

        [Authorize]
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAll()
        {
            var email = User.Claims.Where(x => x.Type == ClaimTypes.Email).FirstOrDefault()?.Value;
            if (email is null) return BadRequest();

            var user = await _userManager.FindByEmailAsync(email);
            if(user is null) return BadRequest();

            IEnumerable<Order> orders = await _unitOfWork.Orders.GetAllByUser(user.Id);

            return Ok(orders);
        }

        [Authorize]
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Create(CreateOrderDTO orderDto)
        {
            var email = User.Claims.Where(x => x.Type == ClaimTypes.Email).FirstOrDefault()?.Value;
            if (email is null) return BadRequest();

            var user = await _userManager.FindByEmailAsync(email);
            if (user is null) return BadRequest();

            TypeAdapterConfig config = new();
            config.NewConfig<CreateOrderDTO, Order>().Map(dest => dest.User, src => user);

            Order order = orderDto.Adapt<Order>(config);

            await _unitOfWork.Orders.AddAsync(order);
            await _unitOfWork.SaveChangesAsync();

            return Created();
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> Update()
        {
            return Ok();
        }

        [HttpDelete]
        [Route("[action]")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            await _unitOfWork.Orders.DeleteAsync(Id);

            return NoContent();
        }
    }
}
