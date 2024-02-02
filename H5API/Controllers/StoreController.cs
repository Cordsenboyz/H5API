using H5API.Data;
using H5API.Dto.Create;
using H5API.Dto.Update;
using H5API.Models;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace H5API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;

        public StoreController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Get(Guid Id)
        {
            Store? store = await _unitOfWork.Stores.GetWithAllRelations(Id);

            return Ok(store);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<Store> stores = await _unitOfWork.Stores.GetAllWithAllRelations();

            return Ok(stores);
        }

        [Authorize]
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Create(CreateStoreDTO storeDTO)
        {
            Store store = storeDTO.Adapt<Store>();

            await _unitOfWork.Stores.AddAsync(store);
            await _unitOfWork.SaveChangesAsync();

            return Created();
        }

        [Authorize]
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> Update(UpdateStoreDTO storeDTO)
        {
            Store store = await _unitOfWork.Stores.GetAsync(storeDTO.Id);

            TypeAdapter.Adapt(storeDTO, store, typeof(UpdateStoreDTO), typeof(Store));

            await _unitOfWork.Stores.UpdateAsync(store);
            await _unitOfWork.SaveChangesAsync();

            return Ok();
        }

        [Authorize]
        [HttpDelete]
        [Route("[action]")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            await _unitOfWork.Stores.DeleteAsync(Id);
            await _unitOfWork.SaveChangesAsync();

            return NoContent();
        }
    }
}
