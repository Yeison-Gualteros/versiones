using API.Presentation.ModelBinders;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace API.Presentation.Controllers
{
    [Route("api/matricula")]
    [ApiController]
    public class MatriculaController : ControllerBase
    {
        private readonly IServiceManager _service;

        public MatriculaController(IServiceManager service) => _service = service;

        [HttpGet]
        public IActionResult GetMatriculas()
        {
            var matriculas = _service.MatriculaService.GetAllMatriculas(trackChanges: false);

            return Ok(matriculas);
        }

        [HttpGet("{id:guid}", Name = "MatriculaById")]
        public IActionResult GetMatricula(Guid id)
        {
            var matricula = _service.MatriculaService.GetMatricula(id, trackChanges: false);
            return Ok(matricula);
        }

        [HttpGet("collection/({ids})", Name = "MatriculaCollection")]
        public IActionResult GetMatriculaCollection([ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
        {
            var matriculas = _service.MatriculaService.GetByIds(ids, trackChanges: false);

            return Ok(matriculas);
        }

        [HttpPost]
        public IActionResult CreateMatricula([FromBody] MatriculaForCreationDto matricula)
        {
            if (matricula is null)
                return BadRequest("MatriculaForCreationDto object is null");

            var createdMatricula = _service.MatriculaService.CreateMatricula(matricula);

            return CreatedAtRoute("MatriculaById", new { id = createdMatricula.MatriculaId }, createdMatricula);
        }

        [HttpPost("collection")]
        public IActionResult CreateMatriculaCollection([FromBody] IEnumerable<MatriculaForCreationDto> matriculaCollection)
        {
            var result = _service.MatriculaService.CreateMatriculaCollection(matriculaCollection);

            return CreatedAtRoute("MatriculaCollection", new { result.ids }, result.matriculas);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteMatricula(Guid id)
        {
            _service.MatriculaService.DeleteMatricula(id, trackChanges: false);
            return NoContent();
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpdateMatricula(Guid id, [FromBody] MatriculaForUpdateDto matriculaForUpdate)
        {
            if (matriculaForUpdate is null)
                return BadRequest("MatriculaForUpdateDto object is null");
            _service.MatriculaService.UpdateMatricula(id, matriculaForUpdate, trackChanges: true);
            return NoContent();
        }
    }
}

