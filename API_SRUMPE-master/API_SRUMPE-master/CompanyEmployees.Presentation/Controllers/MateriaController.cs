using API.Presentation.ModelBinders;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace API.Presentation.Controllers
{
    [Route("api/materia")] 
    [ApiController]
    public class MateriasController : ControllerBase 
    {
        private readonly IServiceManager _service;

        public MateriasController(IServiceManager service) => _service = service;

        [HttpGet]
        public IActionResult GetMaterias() 
        {
            var materias = _service.MateriaService.GetAllMaterias(trackChanges: false); 

            return Ok(materias);
        }

        [HttpGet("{id:guid}", Name = "MateriaById")] 
        public IActionResult GetMateria(Guid id)
        {
            var materia = _service.MateriaService.GetMateria(id, trackChanges: false);

            return Ok(materia);
        }

        [HttpGet("collection/({ids})", Name = "MateriaCollection")] 
        public IActionResult GetMateriaCollection([ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
        {
            var materias = _service.MateriaService.GetByIds(ids, trackChanges: false);

            return Ok(materias);
        }

        [HttpPost]
        public IActionResult CreateMateria([FromBody] MateriaForCreationDto materia) 
        {
            if (materia is null)
                return BadRequest("MateriaForCreationDto object is null");

            var createdMateria = _service.MateriaService.CreateMateria(materia);

            return CreatedAtRoute("MateriaById", new { id = createdMateria.MateriaId }, createdMateria);
        }

        [HttpPost("collection")]
        public IActionResult CreateMateriaCollection([FromBody] IEnumerable<MateriaForCreationDto> materiaCollection)
        {
            var result = _service.MateriaService.CreateMateriaCollection(materiaCollection);

            return CreatedAtRoute("MateriaCollection", new { result.ids }, result.materias);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteMateria(Guid id) 
        {
            _service.MateriaService.DeleteMateria(id, trackChanges: false);
            return NoContent();
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpdateMateria(Guid id, [FromBody] MateriaForUpdateDto materiaForUpdate) 
        {
            if (materiaForUpdate is null)
                return BadRequest("MateriaForUpdateDto object is null");

            _service.MateriaService.UpdateMateria(id, materiaForUpdate, trackChanges: true);
            return NoContent();
        }
    }
}
