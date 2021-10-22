using DragonBallApi.Domain.DTO;
using DragonBallApi.Services;
using DragonBallApi.Services.Base;
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
    public class CoverImageController : ControllerBase
    {
        public readonly CoverImageService _coverImageService;
        public CoverImageController(CoverImageService coverImage)
        {
            _coverImageService = coverImage;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int index, int quantity)
        {
            var result = await _coverImageService.SearchAllCoverImages(index, quantity);

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
            var retorno = await _coverImageService.PesquisaPorId(id);

            if (retorno.Success)
            {
                return Ok(retorno.ObjectReturn);
            }
            else
            {
                return NotFound(retorno);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CICreateRequest postModel)
        {
            if (ModelState.IsValid)
            {
                var retorno = await _coverImageService.Cadastrar(postModel);
                if (!retorno.Success)
                    return BadRequest(retorno);
                else
                    return Ok(retorno.ObjectReturn);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CIUpdateRequest putModel)
        {
            if (ModelState.IsValid)
            {
                var retorno = await _coverImageService.Editar(id, putModel);
                if (!retorno.Success)
                    return BadRequest(retorno.Message);
                return Ok(retorno.ObjectReturn);
            }
            else
            {
                return BadRequest(ModelState);
            }

        }
    }
}
