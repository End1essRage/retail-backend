using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using retail_backend.Data.Repositories;

namespace retail_backend.Api.Controllers
{
    [ApiController]
    [Route("api/keys")]
    public class KeysController : ControllerBase
    {
        private readonly ConfKeysRepository _consRepository;

        public KeysController(ConfKeysRepository consRepository)
        {
            _consRepository = consRepository;
        }

        [HttpGet]
        public async Task<ActionResult<string>> GetConfData([FromQuery] string key)
        {
            var data = await _consRepository.ReadData(key);
            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);
        }

        [HttpPost]
        public async Task<ActionResult<bool>> SetConfData([FromQuery] string key, [FromQuery] string value)
        {
            return await _consRepository.AddOrUpdateData(key, value);
        }
    }
}