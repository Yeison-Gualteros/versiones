using API.Presentation.ModelBinders;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace API.Presentation.Controllers
{
    [Route("api/horario")]
    [ApiController]
    public class HorariosController : ControllerBase
    {
        private readonly IServiceManager _service;

        public HorariosController(IServiceManager service) => _service = service;

        [HttpGet]
        public IActionResult GetHorarios()
        {
            var horarios = _service.HorarioService.GetAllHorarios(trackChanges: false);

            return Ok(horarios);
        }

        [HttpGet("{id:guid}", Name = "HorarioById")]
        public IActionResult GetHorario(Guid id)
        {
            var horario = _service.HorarioService.GetHorario(id, trackChanges: false);
            return Ok(horario);
        }

        [HttpGet("collection/({ids})", Name = "HorarioCollection")]
        public IActionResult GetHorarioCollection([ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
        {
            var horarios = _service.HorarioService.GetByIds(ids, trackChanges: false);

            return Ok(horarios);
        }

        [HttpPost]
        public IActionResult CreateHorario([FromBody] HorarioForCreationDto horario)
        {
            if (horario is null)
                return BadRequest("HorarioForCreationDto object is null");

            var createdHorario = _service.HorarioService.CreateHorario(horario);

            return CreatedAtRoute("HorarioById", new { id = createdHorario.HorarioId }, createdHorario);
        }

        [HttpPost("collection")]
        public IActionResult CreateHorarioCollection([FromBody] IEnumerable<HorarioForCreationDto> horarioCollection)
        {
            var result = _service.HorarioService.CreateHorarioCollection(horarioCollection);

            return CreatedAtRoute("HorarioCollection", new { result.ids }, result.horarios);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteHorario(Guid id)
        {
            _service.HorarioService.DeleteHorario(id, trackChanges: false);
            return NoContent();
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpdateHorario(Guid id, [FromBody] HorarioForUpdateDto horarioForUpdate)
        {
            if (horarioForUpdate is null)
                return BadRequest("HorarioForUpdateDto object is null");
            _service.HorarioService.UpdateHorario(id, horarioForUpdate, trackChanges: true);
            return NoContent();
        }
    }
}
