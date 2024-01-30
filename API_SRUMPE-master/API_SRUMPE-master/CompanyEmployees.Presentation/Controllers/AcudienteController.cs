using API.Presentation.ModelBinders;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace API.Presentation.Controllers;

[Route("api/acudiente")]
[ApiController]
public class AcudientesController : ControllerBase
{
    private readonly IServiceManager _service;

    public AcudientesController(IServiceManager service) => _service = service;

    [HttpGet]
    public IActionResult GetAcudientes()
    {
        var acudientes = _service.AcudienteService.GetAllAcudiente(trackChanges: false);

        return Ok(acudientes);
    }

    [HttpGet("{id:guid}", Name = "AcudienteById")]
    public IActionResult GetAcudiente(Guid id)
    {
        var acudiente = _service.AcudienteService.GetAcudiente(id, trackChanges: false);
        return Ok(acudiente);
    }

    [HttpGet("collection/({ids})", Name = "AcudienteCollection")]
    public IActionResult GetAcudienteCollection([ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
    {
        var acudientes = _service.AcudienteService.GetByIds(ids, trackChanges: false);

        return Ok(acudientes);
    }

    [HttpPost]
    public IActionResult CreateAcudiente([FromBody] AcudienteForCreationDto acudiente)
    {
        if (acudiente is null)
            return BadRequest("AcudienteForCreationDto object is null");

        var createdAcudiente = _service.AcudienteService.CreateAcudiente(acudiente);

        return CreatedAtRoute("AcudienteById", new { id = createdAcudiente.AcudienteId }, createdAcudiente);
    }

    [HttpPost("collection")]
    public IActionResult CreateAcudienteCollection([FromBody] IEnumerable<AcudienteForCreationDto> acudienteCollection)
    {
        var result = _service.AcudienteService.CreateAcudienteCollection(acudienteCollection);

        return CreatedAtRoute("AcudienteCollection", new { result.ids }, result.acudiente);
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteAcudiente(Guid id)
    {
        _service.AcudienteService.DeleteAcudiente(id, trackChanges: false);
        return NoContent();
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpdateAcudiente(Guid id, [FromBody] AcudienteForUpdateDto acudiente)
    {
        if (acudiente is null)
            return BadRequest("AcudienteForUpdateDto object is null");
        _service.AcudienteService.UpdateAcudiente(id, acudiente, trackChanges: true);
        return NoContent();
    }
}

