using API.Presentation.ModelBinders;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;


namespace API.Presentation.Controllers;

[Route("api/telefonoAcudiente")]
[ApiController]
public class TelefonoAcudientesController : ControllerBase
{
    private readonly IServiceManager _service;

    public TelefonoAcudientesController(IServiceManager service) => _service = service;

    [HttpGet]
    public IActionResult GetTelefonoAcudientes()
    {
        var telefonoAcudientes = _service.TelefonoAcudienteService.GetAllTelefonoAcudientes(trackChanges: false);

        return Ok(telefonoAcudientes);
    }

    [HttpGet("{id:guid}", Name = "TelefonoAcudienteById")]
    public IActionResult GetTelefonoAcudiente(Guid id)
    {
        var telefonoAcudiente = _service.TelefonoAcudienteService.GetTelefonoAcudiente(id, trackChanges: false);
        return Ok(telefonoAcudiente);
    }

    [HttpGet("collection/({ids})", Name = "TelefonoAcudienteCollection")]
    public IActionResult GetTelefonoAcudienteCollection([ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
    {
        var telefonoAcudientes = _service.TelefonoAcudienteService.GetByIds(ids, trackChanges: false);

        return Ok(telefonoAcudientes);
    }

    [HttpPost]
    public IActionResult CreateTelefonoAcudiente([FromBody] TelefonoAcudienteForCreationDto telefonoAcudiente)
    {
        if (telefonoAcudiente is null)
            return BadRequest("TelefonoAcudienteForCreationDto object is null");

        var createdTelefonoAcudiente = _service.TelefonoAcudienteService.CreateTelefonoAcudiente(telefonoAcudiente);

        return CreatedAtRoute("TelefonoAcudienteById", new { id = createdTelefonoAcudiente.TelefonoAcudienteId }, createdTelefonoAcudiente);
    }

    [HttpPost("collection")]
    public IActionResult CreateTelefonoAcudienteCollection([FromBody] IEnumerable<TelefonoAcudienteForCreationDto> telefonoAcudienteCollection)
    {
        var result = _service.TelefonoAcudienteService.CreateTelefonoAcudienteCollection(telefonoAcudienteCollection);

        return CreatedAtRoute("TelefonoAcudienteCollection", new { result.ids }, result.telefonoAcudientes);
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteTelefonoAcudiente(Guid id)
    {
        _service.TelefonoAcudienteService.DeleteTelefonoAcudiente(id, trackChanges: false);
        return NoContent();
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpdateTelefonoAcudiente(Guid id, [FromBody] TelefonoAcudienteForUpdateDto telefonoAcudiente)
    {
        if (telefonoAcudiente is null)
            return BadRequest("TelefonoAcudienteForUpdateDto object is null");
        _service.TelefonoAcudienteService.UpdateTelefonoAcudiente(id, telefonoAcudiente, trackChanges: true);
        return NoContent();
    }
}
