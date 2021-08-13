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
    [Route("api/ad")]
    [ApiController]
    public class AdController : ControllerBase
    {
        private readonly IDataRepository<Ad> _dataRepository;

        public AdController(IDataRepository<Ad> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET: api/ad
        [HttpGet]
        public IActionResult Get()
        {
            var ads = _dataRepository.GetAll();
            return Ok(ads);
        }

        // GET: api/ad/5
        [HttpGet("{id}", Name = "GetAd")]
        public IActionResult Get(int id)
        {
            var ad = _dataRepository.Get(id);
            if (ad == null)
            {
                return NotFound("Oglas nije pronađen.");
            }

            return Ok(ad);
        }

        // POST: api/ad
        [HttpPost]
        public IActionResult Post([FromBody] Ad ad)
        {
            if (ad is null)
            {
                return BadRequest("Oglas je prazan.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _dataRepository.Add(ad);
            return CreatedAtRoute("GetAd", new { Id = ad.Id }, null);
        }

        // PUT: api/ad/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Ad ad)
        {
            if (ad == null)
            {
                return BadRequest("Oglas je prazan.");
            }

            var adToUpdate = _dataRepository.Get(id);
            if (adToUpdate == null)
            {
                return NotFound("Oglas nije pronađen.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _dataRepository.Update(adToUpdate, ad);
            return NoContent();
        }

        // DELETE: api/ad/5
        [HttpDelete("{id}")]
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
