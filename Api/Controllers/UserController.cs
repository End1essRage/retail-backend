using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using retail_backend.Data.Repositories.Abstractions;

namespace retail_backend.Api.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("{userName}")]
        public async Task<ActionResult<int>> GetUserRole(string userName)
        {
            Console.WriteLine("Hitted get user role");
            return Ok(await _userRepository.GetUserRoleByName(userName));
        }
    }
}