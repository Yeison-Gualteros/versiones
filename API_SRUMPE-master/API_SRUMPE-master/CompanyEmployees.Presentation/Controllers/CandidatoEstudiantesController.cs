using API.Presentation.ModelBinders;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;


namespace API.Presentation.Controllers;

[Route("api/candidatoEstudiante")]
[ApiController]
public class CandidatoEstudiantesController : ControllerBase
{
    private readonly IServiceManager _service;

    public CandidatoEstudiantesController(IServiceManager service) => _service = service;

    [HttpGet]
    public IActionResult GetCandidatoEstudiantes()
    {
        var candidatoEstudiantes = _service.CandidatoEstudianteService.GetAllCandidatoEstudiantes(trackChanges: false);

        return Ok(candidatoEstudiantes);
    }

    [HttpGet("{id:guid}", Name = "CandidatoEstudianteById")]
    public IActionResult GetCandidatoEstudiante(Guid id)
    {
        var candidatoEstudiante = _service.CandidatoEstudianteService.GetCandidatoEstudiante(id, trackChanges: false);
        return Ok(candidatoEstudiante);
    }

    [HttpGet("collection/({ids})", Name = "CandidatoEstudianteCollection")]
    public IActionResult GetCandidatoEstudianteCollection([ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
    {
        var candidatoEstudiantes = _service.CandidatoEstudianteService.GetByIds(ids, trackChanges: false);

        return Ok(candidatoEstudiantes);
    }

    [HttpPost]
    public IActionResult CreateCandidatoEstudiantey([FromBody] CandidatoEstudianteForCreationDto candidatoEstudiante)
    {
        if (candidatoEstudiante is null)
            return BadRequest("CandidatoEstudianteForCreationDto object is null");

        var createdCandidatoEstudiante = _service.CandidatoEstudianteService.CreateCandidatoEstudiante(candidatoEstudiante);

        return CreatedAtRoute("CandidatoEstudianteById", new { id = createdCandidatoEstudiante.CandidatoEstudianteId }, createdCandidatoEstudiante);
    }

    [HttpPost("collection")]
    public IActionResult CreateCandidatoEstudianteCollection([FromBody] IEnumerable<CandidatoEstudianteForCreationDto> candidatoEstudianteCollection)
    {
        var result = _service.CandidatoEstudianteService.CreateCandidatoEstudianteCollection(candidatoEstudianteCollection);

        return CreatedAtRoute("CandidatoEstudianteCollection", new { result.ids }, result.candidatoEstudiantes);


    }
    [HttpDelete("{id:guid}")]
    public IActionResult DeleteCandidatoEstudiante(Guid id)
    {
        _service.CandidatoEstudianteService.DeleteCandidatoEstudiante(id, trackChanges: false);
        return NoContent();
    }


    [HttpPut("{id:guid}")]
    public IActionResult UpdateCandidatoEstudiante(Guid id, [FromBody] CandidatoEstudianteForUpdateDto candidatoEstudiante)
    {
        if (candidatoEstudiante is null)
            return BadRequest("CandidatoEstudianteUpdateDto object is null");
        _service.CandidatoEstudianteService.UpdateCandidatoEstudiante(id, candidatoEstudiante, trackChanges: true);
        return NoContent();
    }
}
