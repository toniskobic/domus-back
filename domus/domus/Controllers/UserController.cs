using domus.Authentication;
using domus.Models;
using domus.Models.Repository;
using Microsoft.AspNetCore.Authorization;
using domus.Models.DataManager;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace domus.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IDataRepository<ApplicationUser> _dataRepository;

        public UserController(IDataRepository<ApplicationUser> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET: api/user
        [HttpGet]
        public IActionResult Get()
        {
            var users = _dataRepository.GetAll();
            return Ok(users);
        }

    }
}
