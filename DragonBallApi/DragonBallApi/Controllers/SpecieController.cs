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
    public class SpecieController : ControllerBase
    {
        private readonly SpecieService _service;

        public SpecieController(SpecieService service)
        {
            _service = service;
        }

		[HttpGet]
		public async Task<IActionResult> Get(int index, int qtd)
		{
			var result = await _service.Search(index, qtd);

			if (result.Success)
			{
				return Ok(result.ObjectReturn);
			}
			else
			{
				return BadRequest(result);
			}
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var result = await _service.SearchById(id);

			if (result.Success)
			{
				return Ok(result.ObjectReturn);
			}
			else
			{
				return NotFound(result);
			}
		}



		[HttpPost]
		
		public async Task<IActionResult> Post([FromBody] SpecieCreateRequest postModel)
		{
			
			if (ModelState.IsValid)
			{
				var result = await _service.Register(postModel);
				if (!result.Success)
					return BadRequest(result);
				else
					return Ok(result.ObjectReturn);
			}
			else
			{
				return BadRequest(ModelState);
			}

		}

		[HttpPut("specie/{id}")]
		
		public IActionResult Put(int id, [FromBody] SpecieCreateRequest putModel)
		{
			
			if (ModelState.IsValid)
			{
				var result = _service.Update(id, putModel);

				if (!result.Success)
					return BadRequest(result);
				else
					return Ok(result.ObjectReturn);
			}
			else
			{
				return BadRequest(ModelState);
			}


		}
	}
}
