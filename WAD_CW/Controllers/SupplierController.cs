using Microsoft.AspNetCore.Mvc;
using SPI.Models;
using SPI.Repositories;

namespace SPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class SupplierController: ControllerBase
    {
        private readonly IRepository<Supplier> _repository;
        
        public SupplierController(IRepository<Supplier> repository)
        {
            _repository = repository;
        }

        // GET: api/<>
        [HttpGet]
        public async Task<IEnumerable<Supplier>> Get()
        {
            return await _repository.GetAllAsync();
        }


        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(int id)
        {
            var result = await _repository.GetByIDAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }
        }


        // POST api/<CategoryController>
        [HttpPost]
        public async Task<IActionResult> Create(Supplier suppliers)
        {
            await _repository.AddAsync(suppliers);
            return CreatedAtAction(nameof(GetByID), new { id = suppliers.Id }, suppliers);
        }


        // PUT api/<CategoryController>/5
        [HttpPut]
        public async Task<IActionResult> Update(Supplier suppliers)
        {
            //if(id!=items.ID) return BadRequest();
            await _repository.UpdateAsync(suppliers);
            return NoContent();
        }



        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}
