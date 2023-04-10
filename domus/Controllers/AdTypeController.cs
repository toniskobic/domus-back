    using domus.Authentication;
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
    [Route("api/ad-types")]
    [ApiController]
    public class AdTypeController : ControllerBase
    {
        private readonly IDataRepository<AdType> _dataRepository;

        public AdTypeController(IDataRepository<AdType> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET: api/ad-types
        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            var adTypes = _dataRepository.GetAll();
            return Ok(adTypes);
        }

        // GET: api/ad-types/5
        [Authorize(Roles = UserRoles.Admin)]
        [HttpGet("{id}", Name = "GetAdType")]
        public IActionResult Get(int id)
        {
            var adType = _dataRepository.Get(id);
            if (adType == null)
            {
                return NotFound("Tip oglasa nije pronađen.");
            }

            return Ok(adType);
        }

        // POST: api/ad-types
        [Authorize(Roles = UserRoles.Admin)]
        [HttpPost]
        public IActionResult Post([FromBody] AdType adType)
        {
            if (adType is null)
            {
                return BadRequest("Tip oglasa je prazan.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _dataRepository.Add(adType);
            return CreatedAtRoute("GetAdType", new { Id = adType.Id }, null);
        }

        // PUT: api/ad-types/5
        [Authorize(Roles = UserRoles.Admin)]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] AdType adType)
        {
            if (adType == null)
            {
                return BadRequest("Tip oglasa je prazan.");
            }

            var adTypeToUpdate = _dataRepository.Get(id);
            if (adTypeToUpdate == null)
            {
                return NotFound("Tip oglasa nije pronađen.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _dataRepository.Update(adTypeToUpdate, adType);
            return NoContent();
        }

        // DELETE: api/ad-types/5
        [Authorize(Roles = UserRoles.Admin)]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var adType = _dataRepository.Get(id);
            if (adType == null)
            {
                return NotFound("Tip oglasa nije pronađen.");
            }

            _dataRepository.Delete(adType);
            return NoContent();
        }

    }
}
