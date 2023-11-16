using AutoMapper;
using Challenge_2.DTOs;
using Challenge_2.Services;
using Microsoft.AspNetCore.Mvc;

namespace Challenge_2.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ReceitasController : ControllerBase
    {
        private readonly ReceitasService _service;

        public ReceitasController(ReceitasService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<ReceitasDTO>>> Get()
        {
            var receitasDto = await _service.GetAll();
            return Ok(receitasDto);
        }

        [HttpGet("{id:int}", Name = "ObterReceita")]
        public async Task<ActionResult<ReceitasDTO>> GetById(int id) 
        {
            var receitaDto = await _service.GetById(id);
            if(receitaDto == null)
            {
                return NotFound();
            }
            return Ok(receitaDto);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ReceitasDTO dto)
        {
            if(dto == null)
            {
                return BadRequest();
            }

            await _service.Post(dto);
            return new CreatedAtRouteResult("ObterReceita",
                new { id = dto.Id }, dto);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] ReceitasDTO dto)
        {
            var receita = _service.GetById(id);
            if (receita == null)
            {
                return NotFound();
            }

            await _service.Put(dto);
            return Ok(dto);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ReceitasDTO>> Delete(int id)
        {
            var receitaDto = await _service.GetById(id);
            if (receitaDto == null)
            {
                return NotFound();
            }
            _service.Delete(receitaDto);
            return NoContent();
        }
    }
}
