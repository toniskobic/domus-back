using domus.Authentication;
using domus.Models;
using domus.Models.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace domus.Controllers
{
    [Route("api/event-types")]
    [ApiController]
    public class EventTypeController : ControllerBase
    {
        private readonly IDataRepository<EventType> _dataRepository;

        public EventTypeController(IDataRepository<EventType> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET: api/event-types
        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            var eventTypes = _dataRepository.GetAll();
            return Ok(eventTypes);
        }

        // GET: api/event-types/5
        [Authorize(Roles = UserRoles.Admin)]
        [HttpGet("{id}", Name = "GetEventType")]
        public IActionResult Get(int id)
        {
            var eventType = _dataRepository.Get(id);
            if (eventType == null)
            {
                return NotFound("Tip događaja nije pronađen.");
            }

            return Ok(eventType);
        }

        // POST: api/event-types
        [Authorize(Roles = UserRoles.Admin)]
        [HttpPost]
        public IActionResult Post([FromBody] EventType eventType)
        {
            if (eventType is null)
            {
                return BadRequest("Tip događaja je prazan.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _dataRepository.Add(eventType);
            return CreatedAtRoute("GetEventType", new { Id = eventType.Id }, null);
        }

        // PUT: api/event-types/5
        [Authorize(Roles = UserRoles.Admin)]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] EventType eventType)
        {
            if (eventType == null)
            {
                return BadRequest("Tip događaja je prazan.");
            }

            var eventTypeToUpdate = _dataRepository.Get(id);
            if (eventTypeToUpdate == null)
            {
                return NotFound("Tip događaja nije pronađen.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _dataRepository.Update(eventTypeToUpdate, eventType);
            return NoContent();
        }

        // DELETE: api/event-types/5
        [Authorize(Roles = UserRoles.Admin)]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var eventType = _dataRepository.Get(id);
            if (eventType == null)
            {
                return NotFound("Tip događaja nije pronađen.");
            }

            _dataRepository.Delete(eventType);
            return NoContent();
        }
    }
}
