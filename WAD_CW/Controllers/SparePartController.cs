using Microsoft.AspNetCore.Mvc;
using SPI.Models;
using SPI.Repositories;

namespace SPI.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SparePartController: ControllerBase
    {
        private readonly IRepository<SparePart> _sparePartsRepository;

        public SparePartController(IRepository<SparePart> sparePartsRepository)
        {
            _sparePartsRepository = sparePartsRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<SparePart>> GetAll() => await _sparePartsRepository.GetAllAsync();


        [HttpGet("{id}")]
        [ProducesResponseType(typeof(SparePart), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByID(int id)
        {
            var result = await _sparePartsRepository.GetByIDAsync(id);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(SparePart items)
        {
            await _sparePartsRepository.AddAsync(items);
            return Ok(items);
        }


        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(SparePart items)
        {
            await _sparePartsRepository.UpdateAsync(items);
            return NoContent();
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await _sparePartsRepository.DeleteAsync(id);
            return NoContent();


        }


        [HttpGet]
        public async Task<int> Count() => await _sparePartsRepository.CountAsync();

        [HttpPut("{id}/UpdateQuantity")]
        public async Task<IActionResult> UpdateQuantity(int id, int quantityDelta)
        {
            try
            {
                await _sparePartsRepository.UpdateQuantityAsync(id, quantityDelta);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
