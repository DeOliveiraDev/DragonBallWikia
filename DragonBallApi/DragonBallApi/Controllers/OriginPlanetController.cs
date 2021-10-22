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
    public class OriginPlanetController : ControllerBase
    {
        private readonly OriginPlanetService _Service;

        public OriginPlanetController(OriginPlanetService service)
        {
            _Service = service;
        }

		[HttpGet]
		public async Task<IActionResult> Get(int index, int qtd)
		{
			var result = await _Service.Search(index, qtd);

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
			var result = await _Service.SearchById(id);

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
		// FromBody para indicar de o corpo da requisição deve ser mapeado para o modelo
		public async Task<IActionResult> Post([FromBody] OriginPlanetCreateRequest postModel)
		{
			//Validação modelo de entrada
			if (ModelState.IsValid)
			{
				var result = await _Service.Register(postModel);
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


		[HttpPut("{id}")]
		public async Task<IActionResult> Edita(int id, [FromBody] OriginPlanetUpdateRequest putModel)
		{
			if (ModelState.IsValid)
			{
				var result = await _Service.Update(id, putModel);
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
