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
    [Authorize(Roles = UserRoles.Admin)]
    [Route("api/cities")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly IDataRepository<City> _dataRepository;

        public CityController(IDataRepository<City> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET: api/cities
        [HttpGet]
        public IActionResult Get()
        {
            var cities = _dataRepository.GetAll();
            return Ok(cities);
        }

        // GET: api/cities/5
        [HttpGet("{id}", Name = "GetCity")]
        public IActionResult Get(int id)
        {
            var city = _dataRepository.Get(id);
            if (city == null)
            {
                return NotFound("Grad nije pronađen.");
            }

            return Ok(city);
        }

        // POST: api/cities
        [HttpPost]
        public IActionResult Post([FromBody] City city)
        {
            if (city is null)
            {
                return BadRequest("Grad je prazan.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _dataRepository.Add(city);
            return CreatedAtRoute("GetCity", new { Id = city.Id }, null);
        }

        // PUT: api/cities/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] City city)
        {
            if (city == null)
            {
                return BadRequest("Grad je prazan.");
            }

            var cityToUpdate = _dataRepository.Get(id);
            if (cityToUpdate == null)
            {
                return NotFound("Grad nije pronađen.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _dataRepository.Update(cityToUpdate, city);
            return NoContent();
        }

        // DELETE: api/cities/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var city = _dataRepository.Get(id);
            if (city == null)
            {
                return NotFound("Grad nije pronađen.");
            }

            _dataRepository.Delete(city);
            return NoContent();
        }
    }
}
