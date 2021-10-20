using DragonBallApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DragonBallApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        public readonly CharactersService _charactersService;

        public CharactersController(CharactersService charactersService)
        {
            _charactersService = charactersService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int index, int quantity)
        {
            var result = await _charactersService.SearchAllCharacters(index, quantity);

            if (result.Success)
            {
                return Ok(result.ObjectReturn);
            }
            else
            {
                return BadRequest(result);
            }
        }
    }
}
