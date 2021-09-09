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

        // PUT: api/participants/5
        [HttpPut("{dogadjajId}/{korisnikId}")]
        public IActionResult Put(int dogadjajId, int korisnikId, [FromBody] Participant participant)
        {
            if (participant == null)
            {
                return BadRequest("Sudionik je prazan.");
            }

            var participantToUpdate = _dataRepository.Get(dogadjajId);
            if (participantToUpdate == null)
            {
                return NotFound("Oglas nije pronađen.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _dataRepository.Update(participantToUpdate, participant);
            return NoContent();
        }

        // DELETE: api/participants/5/2
        [HttpDelete("{dogadjajId}/{korisnikId}")]
        public IActionResult Delete(int id)
        {
            var ad = _dataRepository.Get(id);
            if (ad == null)
            {
                return NotFound("Oglas nije pronađen.");
            }

            _dataRepository.Delete(ad);
            return NoContent();
        }
    }
}
