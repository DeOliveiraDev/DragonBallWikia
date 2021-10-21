using DragonBallApi.Domain.DTO;
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
            if (ModelState.IsValid)
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
            else
            {
                return BadRequest(ModelState);
            }
            
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if(ModelState.IsValid)
            {
                var result = await _charactersService.SearchCharactersById(id);

                if (result.Success)
                {
                    return Ok(result.ObjectReturn);
                }
                else
                {
                    return BadRequest(result);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CharactersCreateRequest postModel)
        {if (ModelState.IsValid)
            {
                var result = await _charactersService.PostCharacters(postModel);
                if (result.Success)
                {
                    return Ok(result.ObjectReturn);
                }
                else
                {
                    return BadRequest(result);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CharactersUpdateRequest putModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _charactersService.UpdateCharactersIfo(id, putModel);

                if(result.Success)
                {
                    return Ok(result.ObjectReturn);
                }
                else
                {
                    return BadRequest(result);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
