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
    [Route("api/dormitories")]
    [ApiController]
    public class DormitoryController : ControllerBase
    {
        private readonly IDataRepository<Dormitory> _dataRepository;

        public DormitoryController(IDataRepository<Dormitory> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET: api/dormitories
        [HttpGet]
        public IActionResult Get()
        {
            var dormitories = _dataRepository.GetAll();
            return Ok(dormitories);
        }

        // GET: api/dormitory/5
        [Authorize(Roles = UserRoles.Admin)]
        [HttpGet("{id}", Name = "GetDormitory")]
        public IActionResult Get(int id)
        {
            var dormitory = _dataRepository.Get(id);
            if (dormitory == null)
            {
                return NotFound("Dom nije pronađen.");
            }

            return Ok(dormitory);
        }

        // POST: api/dormitory
        [Authorize(Roles = UserRoles.Admin)]
        [HttpPost]
        public IActionResult Post([FromBody] Dormitory dormitory)
        {
            if (dormitory is null)
            {
                return BadRequest("Dom je prazan.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _dataRepository.Add(dormitory);
            return CreatedAtRoute("GetDormitory", new { Id = dormitory.Id }, null);
        }

        // PUT: api/dormitory/5
        [Authorize(Roles = UserRoles.Admin)]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Dormitory dormitory)
        {
            if (dormitory == null)
            {
                return BadRequest("Dom je prazan.");
            }

            var dormitoryToUpdate = _dataRepository.Get(id);
            if (dormitoryToUpdate == null)
            {
                return NotFound("Dom nije pronađen.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _dataRepository.Update(dormitoryToUpdate, dormitory);
            return NoContent();
        }

        // DELETE: api/dormitory/5
        [Authorize(Roles = UserRoles.Admin)]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var dormitory = _dataRepository.Get(id);
            if (dormitory == null)
            {
                return NotFound("Dom nije pronađen.");
            }

            _dataRepository.Delete(dormitory);
            return NoContent();
        }
    }
}
