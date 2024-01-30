using API.Presentation.ModelBinders;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace API.Presentation.Controllers
{
    [Route("api/preMatricula")]
    [ApiController]
    public class PreMatriculaController : ControllerBase
    {
        private readonly IServiceManager _service;

        public PreMatriculaController(IServiceManager service) => _service = service;

        [HttpGet]
        public IActionResult GetPreMatriculas()
        {
            var preMatriculas = _service.PreMatriculaService.GetAllPreMatriculas(trackChanges: false);

            return Ok(preMatriculas);
        }

        [HttpGet("{id:guid}", Name = "PreMatriculaById")]
        public IActionResult GetPreMatricula(Guid id)
        {
            var preMatricula = _service.PreMatriculaService.GetPreMatricula(id, trackChanges: false);
            return Ok(preMatricula);
        }

        [HttpGet("collection/({ids})", Name = "PreMatriculaCollection")]
        public IActionResult GetPreMatriculaCollection([ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
        {
            var preMatriculas = _service.PreMatriculaService.GetByIds(ids, trackChanges: false);

            return Ok(preMatriculas);
        }

        [HttpPost]
        public IActionResult CreatePreMatricula([FromBody] PreMatriculaForCreationDto preMatricula)
        {
            if (preMatricula is null)
                return BadRequest("PreMatriculaForCreationDto object is null");

            var createdPreMatricula = _service.PreMatriculaService.CreatePreMatricula(preMatricula);

            return CreatedAtRoute("PreMatriculaById", new { id = createdPreMatricula.PreMatriculaId }, createdPreMatricula);
        }

        [HttpPost("collection")]
        public IActionResult CreatePreMatriculaCollection([FromBody] IEnumerable<PreMatriculaForCreationDto> preMatriculaCollection)
        {
            var result = _service.PreMatriculaService.CreatePreMatriculaCollection(preMatriculaCollection);

            return CreatedAtRoute("PreMatriculaCollection", new { result.ids }, result.preMatriculas);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeletePreMatricula(Guid id)
        {
            _service.PreMatriculaService.DeletePreMatricula(id, trackChanges: false);
            return NoContent();
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpdatePreMatricula(Guid id, [FromBody] PreMatriculaForUpdateDto preMatriculaForUpdate)
        {
            if (preMatriculaForUpdate is null)
                return BadRequest("PreMatriculaForUpdateDto object is null");
            _service.PreMatriculaService.UpdatePreMatricula(id, preMatriculaForUpdate, trackChanges: true);
            return NoContent();
        }
    }
}
