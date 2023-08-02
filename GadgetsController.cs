// MyCloset/Controllers/GadgetsController.cs

using Microsoft.AspNetCore.Mvc;
using MyCloset.Models;
using MyCloset.Repositories;
using MyCLOSET.Repositories;

namespace MyCloset.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GadgetsController : ControllerBase
    {
        private readonly IGadgetRepository _gadgetRepository;

        public GadgetsController(IGadgetRepository gadgetRepository)
        {
            _gadgetRepository = gadgetRepository;
        }

        // GET: api/Gadgets
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_gadgetRepository.GetAll());
        }

        // GET: api/Gadgets/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var gadget = _gadgetRepository.GetById(id);
            if (gadget == null) return NotFound();
            return Ok(gadget);
        }

        // POST: api/Gadgets
        [HttpPost]
        public IActionResult Post(Gadget gadget)
        {
            _gadgetRepository.Add(gadget);
            return CreatedAtAction(nameof(Get), new { id = gadget.Id }, gadget);
        }

        // PUT: api/Gadgets/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Gadget gadget)
        {
            if (id != gadget.Id) return BadRequest();

            _gadgetRepository.Update(gadget);
            return NoContent();
        }

        // DELETE: api/Gadgets/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _gadgetRepository.Delete(id);
            return NoContent();
        }
    }
}
