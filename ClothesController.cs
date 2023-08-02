// MyCloset/Controllers/ClothesController.cs

using Microsoft.AspNetCore.Mvc;
using MyCloset.Models;
using MyCloset.Repositories;
using MyCLOSET.Models;

namespace MyCloset.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClothesController : ControllerBase
    {
        private readonly IClothesRepository _clothesRepository;

        public ClothesController(IClothesRepository clothesRepository)
        {
            _clothesRepository = clothesRepository;
        }

        // GET: api/Clothes
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_clothesRepository.GetAll());
        }

        // GET: api/Clothes/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var clothesItem = _clothesRepository.GetById(id);
            if (clothesItem == null)
            {
                return NotFound();
            }
            return Ok(clothesItem);
        }

        // POST: api/Clothes
        [HttpPost]
        public IActionResult Post(Clothes clothesItem)
        {
            _clothesRepository.Add(clothesItem);
            return CreatedAtAction(nameof(Get), new { id = clothesItem.Id }, clothesItem);
        }

        // PUT: api/Clothes/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Clothes clothesItem)
        {
            if (id != clothesItem.Id)
            {
                return BadRequest();
            }

            _clothesRepository.Update(clothesItem);
            return NoContent();
        }

        // DELETE: api/Clothes/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _clothesRepository.Delete(id);
            return NoContent();
        }
    }
}
