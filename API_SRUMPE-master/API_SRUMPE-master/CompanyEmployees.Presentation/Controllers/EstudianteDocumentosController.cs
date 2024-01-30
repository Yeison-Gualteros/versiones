using API.Presentation.ModelBinders;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace API.Presentation.Controllers;


    [Route("api/estudianteDocumentos")]
    [ApiController]
    public class EstudianteDocumentosController : ControllerBase
    {
        private readonly IServiceManager _service;

        public EstudianteDocumentosController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetEstudianteDocumentos()
        {
            var estudianteDocumentos = _service.EstudianteDocumentosService.GetAllEstudianteDocumentos(trackChanges: false);
            return Ok(estudianteDocumentos);
        }

        [HttpGet("{id:guid}", Name = "EstudianteDocumentoById")]
        public IActionResult GetEstudianteDocumento(Guid id)
        {
            var estudianteDocumento = _service.EstudianteDocumentosService.GetEstudianteDocumentos(id, trackChanges: false);
            return Ok(estudianteDocumento);
        }

        [HttpGet("collection/({ids})", Name = "EstudianteDocumentoCollection")]
        public IActionResult GetEstudianteDocumentoCollection([ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
        {
            var estudianteDocumentos = _service.EstudianteDocumentosService.GetByIds(ids, trackChanges: false);
            return Ok(estudianteDocumentos);
        }

        [HttpPost]
        public IActionResult CreateEstudianteDocumento([FromBody] EstudianteDocumentosForCreationDto estudianteDocumento)
        {
            if (estudianteDocumento is null)
                return BadRequest("EstudianteDocumentosForCreationDto object is null");

            var createdEstudianteDocumento = _service.EstudianteDocumentosService.CreateEstudianteDocumentos(estudianteDocumento);

            return CreatedAtRoute("EstudianteDocumentoById", new { id = createdEstudianteDocumento.EstudianteDocumentosId }, createdEstudianteDocumento);
        }

        [HttpPost("collection")]
        public IActionResult CreateEstudianteDocumentoCollection([FromBody] IEnumerable<EstudianteDocumentosForCreationDto> estudianteDocumentosCollection)
        {
            var result = _service.EstudianteDocumentosService.CreateEstudianteDocumentosCollection(estudianteDocumentosCollection);

            return CreatedAtRoute("EstudianteDocumentoCollection", new { result.ids }, result.estudianteDocumentos);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteEstudianteDocumento(Guid id)
        {
            _service.EstudianteDocumentosService.DeleteEstudianteDocumentos(id, trackChanges: false);
            return NoContent();
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpdateEstudianteDocumento(Guid id, [FromBody] EstudianteDocumentosForUpdateDto estudianteDocumento)
        {
            if (estudianteDocumento is null)
                return BadRequest("EstudianteDocumentosForUpdateDto object is null");

            _service.EstudianteDocumentosService.UpdateEstudianteDocumentos(id, estudianteDocumento, trackChanges: true);
            return NoContent();
        }
    }








