using API.Presentation.ModelBinders;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace API.Presentation.Controllers;

[Route("api/aula")]
[ApiController]
public class AulasController : ControllerBase
{
    private readonly IServiceManager _service;

    public AulasController(IServiceManager service) => _service = service;

    [HttpGet]
    public IActionResult GetAulas()
    {
        var aulas = _service.AulaService.GetAllAulas(trackChanges: false);

        return Ok(aulas);
    }

    [HttpGet("{id:guid}", Name = "AulaById")]
    public IActionResult GetAula(Guid id)
    {
        var aula = _service.AulaService.GetAula(id, trackChanges: false);
        return Ok(aula);
    }

    [HttpGet("collection/({ids})", Name = "AulaCollection")]
    public IActionResult GetAulaCollection([ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
    {
        var aulas = _service.AulaService.GetByIds(ids, trackChanges: false);

        return Ok(aulas);
    }

    [HttpPost]
    public IActionResult CreateAula([FromBody] AulaForCreationDto aula)
    {
        if (aula is null)
            return BadRequest("AulaForCreationDto object is null");

        var createdAula = _service.AulaService.CreateAula(aula);

        return CreatedAtRoute("AulaById", new { id = createdAula.AulaId }, createdAula);
    }

    [HttpPost("collection")]
    public IActionResult CreateAulaCollection([FromBody] IEnumerable<AulaForCreationDto> aulaCollection)
    {
        var result = _service.AulaService.CreateAulaCollection(aulaCollection);

        return CreatedAtRoute("AulaCollection", new { result.ids }, result.aulas);
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteAula(Guid id)
    {
        _service.AulaService.DeleteAula(id, trackChanges: false);
        return NoContent();
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpdateAula(Guid id, [FromBody] AulaForUpdateDto aulaForUpdate)
    {
        if (aulaForUpdate is null)
            return BadRequest("AulaForUpdateDto object is null");
        _service.AulaService.UpdateAula(id, aulaForUpdate, trackChanges: true);
        return NoContent();
    }
}
