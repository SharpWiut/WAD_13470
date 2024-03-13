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
            var resultedToDo = await _sparePartsRepository.GetByIDAsync(id);
            return resultedToDo == null ? NotFound() : Ok(resultedToDo);
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
    }
}
