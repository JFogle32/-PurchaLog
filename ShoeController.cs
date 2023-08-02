using Microsoft.AspNetCore.Mvc;
using MyCLOSET.Repositories;

namespace MyCLOSET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoeController : ControllerBase
    {
        private readonly IShoeRepository _shoeRepository;

        public ShoeController(IShoeRepository shoeRepository)
        {
            _shoeRepository = shoeRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_shoeRepository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var shoe = _shoeRepository.GetById(id);
            if (shoe == null)
            {
                return NotFound();
            }
            return Ok(shoe);
        }

        [HttpPost]
        public IActionResult Post(MyCloset.Models.Shoe shoe)
        {
            _shoeRepository.Add(shoe);
            return CreatedAtAction(nameof(Get), new { id = shoe.Id }, shoe);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, MyCloset.Models.Shoe shoe)
        {
            if (id != shoe.Id)
            {
                return BadRequest();
            }

            _shoeRepository.Update(shoe);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _shoeRepository.Delete(id);
            return NoContent();
        }
    }
}
