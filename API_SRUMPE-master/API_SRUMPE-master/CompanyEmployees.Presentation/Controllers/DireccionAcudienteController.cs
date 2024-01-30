using API.Presentation.ModelBinders;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;


namespace API.Presentation.Controllers;

[Route("api/direccionAcudiente")]
[ApiController]
public class DireccionAcudientesController : ControllerBase
{
    private readonly IServiceManager _service;

    public DireccionAcudientesController(IServiceManager service) => _service = service;

    [HttpGet]
    public IActionResult GetDireccionAcudientes()
    {
        var direccionAcudientes = _service.DireccionAcudienteService.GetAllDireccionAcudientes(trackChanges: false);

        return Ok(direccionAcudientes);
    }

    [HttpGet("{id:guid}", Name = "DireccionAcudienteById")]
    public IActionResult GetDireccionAcudiente(Guid id)
    {
        var direccionAcudiente = _service.DireccionAcudienteService.GetDireccionAcudiente(id, trackChanges: false);
        return Ok(direccionAcudiente);
    }

    [HttpGet("collection/({ids})", Name = "DireccionAcudienteCollection")]
    public IActionResult GetDireccionAcudienteCollection([ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
    {
        var direccionAcudientes = _service.DireccionAcudienteService.GetByIds(ids, trackChanges: false);

        return Ok(direccionAcudientes);
    }

    [HttpPost]
    public IActionResult CreateDireccionAcudiente([FromBody] DireccionAcudienteForCreationDto direccionAcudiente)
    {
        if (direccionAcudiente is null)
            return BadRequest("DireccionAcudienteForCreationDto object is null");

        var createdDireccionAcudiente = _service.DireccionAcudienteService.CreateDireccionAcudiente(direccionAcudiente);

        return CreatedAtRoute("DireccionAcudienteById", new { id = createdDireccionAcudiente.DireccionAcudienteId }, createdDireccionAcudiente);
    }

    [HttpPost("collection")]
    public IActionResult CreateDireccionAcudienteCollection([FromBody] IEnumerable<DireccionAcudienteForCreationDto> direccionAcudienteCollection)
    {
        var result = _service.DireccionAcudienteService.CreateDireccionAcudienteCollection(direccionAcudienteCollection);

        return CreatedAtRoute("DireccionAcudienteCollection", new { result.ids }, result.direccionAcudientes);
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteDireccionAcudiente(Guid id)
    {
        _service.DireccionAcudienteService.DeleteDireccionAcudiente(id, trackChanges: false);
        return NoContent();
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpdateDireccionAcudiente(Guid id, [FromBody] DireccionAcudienteForUpdateDto direccionAcudiente)
    {
        if (direccionAcudiente is null)
            return BadRequest("DireccionAcudienteForUpdateDto object is null");
        _service.DireccionAcudienteService.UpdateDireccionAcudiente(id, direccionAcudiente, trackChanges: true);
        return NoContent();
    }
}
