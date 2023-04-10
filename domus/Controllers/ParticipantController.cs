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
    [Route("api/participants")]
    [ApiController]
    public class ParticipantController : ControllerBase
    {
        private readonly IParticipantRepository<Participant> _dataRepository;

        public ParticipantController(IParticipantRepository<Participant> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET: api/participants
        [HttpGet]
        public IActionResult Get()
        {
            var participants = _dataRepository.GetAll();
            return Ok(participants);
        }

        // GET: api/participants/5
        [HttpGet("{id}", Name = "GetParticipant")]
        public IActionResult Get(int id)
        {
            var participant = _dataRepository.GetParticipants(id);
            if (participant == null)
            {
                return NotFound("Sudionik nije pronađen.");
            }

            return Ok(participant);
        }

        // POST: api/participants
        [HttpPost]
        public IActionResult Post([FromBody] Participant participant)
        {
            if (participant is null)
            {
                return BadRequest("Sudionik je prazan.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _dataRepository.Add(participant);
            return Ok(participant);
        }

        // PATCH: api/participants/5
        [HttpPatch("{eventId}/{userId}")]
        public IActionResult Patch(int eventId, string userId, [FromBody] Participant participant)
        {
            if (participant == null)
            {
                return BadRequest("Sudionik je prazan.");
            }

            var participantToUpdate = _dataRepository.GetParticipant(eventId, userId);
            if (participantToUpdate == null)
            {
                return NotFound("Sudionik nije pronađen.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _dataRepository.Update(participantToUpdate, participant);
            return NoContent();
        }

        // DELETE: api/participants/5/2
        [HttpDelete("{eventId}/{userId}")]
        public IActionResult Delete(int eventId, string userId)
        {
            var participant = _dataRepository.GetParticipant(eventId, userId);
            if (participant == null)
            {
                return NotFound("Sudionik nije pronađen.");
            }

            _dataRepository.Delete(participant);
            return NoContent();
        }
    }
}
