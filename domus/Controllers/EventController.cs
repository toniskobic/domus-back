using domus.Models;
using domus.Models.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace domus.Controllers
{
    [Authorize]
    [Route("api/events")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IDataRepository<Event> _dataRepository;

        public EventController(IDataRepository<Event> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET: api/events
        [HttpGet]
        public IActionResult Get()
        {
            var events = _dataRepository.GetAll();
            return Ok(events);
        }

        // GET: api/events/5
        [HttpGet("{id}", Name = "GetEvent")]
        public IActionResult Get(int id)
        {
            var entity = _dataRepository.Get(id);
            if (entity == null)
            {
                return NotFound("Događaj nije pronađen.");
            }

            return Ok(entity);
        }

        // POST: api/events
        [HttpPost]
        public IActionResult Post([FromBody] Event entity)
        {
            if (entity is null)
            {
                return BadRequest("Događaj je prazan.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _dataRepository.Add(entity);
            return CreatedAtRoute("GetEvent", new { Id = entity.Id }, null);
        }

        // PATCH: api/events/5
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromBody] Event entity)
        {
            if (entity == null)
            {
                return BadRequest("Događaj je prazan.");
            }

            var entityToUpdate = _dataRepository.Get(id);
            if (entityToUpdate == null)
            {
                return NotFound("Događaj nije pronađen.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _dataRepository.Update(entityToUpdate, entity);
            return NoContent();
        }

        // DELETE: api/events/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var entity = _dataRepository.Get(id);
            if (entity == null)
            {
                return NotFound("Događaj nije pronađen.");
            }

            _dataRepository.Delete(entity);
            return NoContent();
        }

    }
}
