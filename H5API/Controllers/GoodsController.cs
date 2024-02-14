using H5API.Data;
using H5API.Dto.Create;
using H5API.Models;
using H5API.Services;
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
    public class GoodsController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly GoodsService _goodsService;

        public GoodsController(UnitOfWork unitOfWork, GoodsService goodsService)
        {
            _unitOfWork = unitOfWork;
            _goodsService = goodsService;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Get(Guid Id)
        {
            Goods good = await _unitOfWork.Goods.GetAsync(Id);

            return Ok(good);
        }

        [Authorize]
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<Goods> goods = await _unitOfWork.Goods.GetAllAsync();

            return Ok(goods);
        }

        [Authorize]
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Create(CreateGoodsDTO goodsDTO, Guid CategoryId)
        {

            bool result = await _goodsService.CreateWithRelations(goodsDTO.Adapt<Goods>(), CategoryId);
            if (!result) BadRequest();

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
            await _unitOfWork.Goods.DeleteAsync(Id);

            return NoContent();
        }
    }
}
