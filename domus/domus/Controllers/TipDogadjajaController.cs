using domus.Models;
using domus.Models.DTO;
using domus.Models.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace domus.Controllers
{
    [Route("api/eventTypes")]
    [ApiController]
    public class TipDogadjajaController : ControllerBase
    {
        private readonly IDataRepository<TipDogadjaja, TipDogadjajaDto> _dataRepository;

        public TipDogadjajaController(IDataRepository<TipDogadjaja, TipDogadjajaDto> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET: api/eventTypes
        [HttpGet]
        public IActionResult Get()
        {
            var eventTypes = _dataRepository.GetAll();
            return Ok(eventTypes);
        }
    }
}
