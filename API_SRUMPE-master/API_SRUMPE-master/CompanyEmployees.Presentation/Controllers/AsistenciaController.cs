using API.Presentation.ModelBinders;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace API.Presentation.Controllers;

[Route("api/asistencia")]
[ApiController]
public class AsistenciaController : ControllerBase
{
    private readonly IServiceManager _service;

    public AsistenciaController(IServiceManager service) => _service = service;

    [HttpGet]
    public IActionResult GetAsistencias()
    {
        var asistencias = _service.AsistenciaService.GetAllAsistencia(trackChanges: false);

        return Ok(asistencias);
    }

    [HttpGet("{id:int}", Name = "AsistenciaById")]
    public IActionResult GetAsistencia(int id)
    {
        var asistencia = _service.AsistenciaService.GetAsistencia(id, trackChanges: false);
        return Ok(asistencia);
    }

    [HttpGet("collection/({ids})", Name = "AsistenciaCollection")]
    public IActionResult GetAsistenciaCollection([ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<int> ids)
    {
        var asistencias = _service.AsistenciaService.GetByIds(ids, trackChanges: false);

        return Ok(asistencias);
    }

    [HttpPost]
    public IActionResult CreateAsistencia([FromBody] AsistenciaForCreationDto asistencia)
    {
        if (asistencia is null)
            return BadRequest("AsistenciaForCreationDto object is null");

        var createdAsistencia = _service.AsistenciaService.CreateAsistencia(asistencia);

        return CreatedAtRoute("AsistenciaById", new { id = createdAsistencia.AsistenciaId }, createdAsistencia);
    }

    [HttpPost("collection")]
    public IActionResult CreateAsistenciaCollection([FromBody] IEnumerable<AsistenciaForCreationDto> asistenciaCollection)
    {
        var result = _service.AsistenciaService.CreateAsistenciaCollection(asistenciaCollection);

        return CreatedAtRoute("AsistenciaCollection", new { ids = result.ids }, result.asistencia);
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteAsistencia(int id)
    {
        _service.AsistenciaService.DeleteAsistencia(id, trackChanges: false);
        return NoContent();
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateAsistencia(int id, [FromBody] AsistenciaForUpdateDto asistencia)
    {
        if (asistencia is null)
            return BadRequest("AsistenciaForUpdateDto object is null");
        _service.AsistenciaService.UpdateAsistencia(id, asistencia, trackChanges: true);
        return NoContent();
    }
}
