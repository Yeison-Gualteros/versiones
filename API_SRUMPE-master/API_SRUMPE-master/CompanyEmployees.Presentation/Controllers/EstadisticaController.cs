using API.Presentation.ModelBinders;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace API.Presentation.Controllers;

[Route("api/estadistica")]
[ApiController]
public class EstadisticasController : ControllerBase
{
    private readonly IServiceManager _service;

    public EstadisticasController(IServiceManager service) => _service = service;

    [HttpGet]
    public IActionResult GetEstadisticas()
    {
        var estadisticas = _service.EstadisticaService.GetAllEstadisticas(trackChanges: false);

        return Ok(estadisticas);
    }

    [HttpGet("{id:int}", Name = "EstadisticaById")]
    public IActionResult GetEstadistica(int id)
    {
        var estadistica = _service.EstadisticaService.GetEstadistica(id, trackChanges: false);
        return Ok(estadistica);
    }

    [HttpGet("collection/({ids})", Name = "EstadisticaCollection")]
    public IActionResult GetEstadisticaCollection([ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<int> ids)
    {
        var estadisticas = _service.EstadisticaService.GetByIds(ids, trackChanges: false);

        return Ok(estadisticas);
    }

    [HttpPost]
    public IActionResult CreateEstadistica([FromBody] EstadisticaForCreationDto estadistica)
    {
        if (estadistica is null)
            return BadRequest("EstadisticaForCreationDto object is null");

        var createdEstadistica = _service.EstadisticaService.CreateEstadistica(estadistica);

        return CreatedAtRoute("EstadisticaById", new { id = createdEstadistica.EstadisticaId }, createdEstadistica);
    }

    [HttpPost("collection")]
    public IActionResult CreateEstadisticaCollection([FromBody] IEnumerable<EstadisticaForCreationDto> estadisticaCollection)
    {
        var result = _service.EstadisticaService.CreateEstadisticaCollection(estadisticaCollection);

        return CreatedAtRoute("EstadisticaCollection", new { result.ids }, result.estadistica);
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteEstadistica(int id)
    {
        _service.EstadisticaService.DeleteEstadistica(id, trackChanges: false);
        return NoContent();
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateEstadistica(int id, [FromBody] EstadisticaForUpdateDto estadistica)
    {
        if (estadistica is null)
            return BadRequest("EstadisticaForUpdateDto object is null");
        _service.EstadisticaService.UpdateEstadistica(id, estadistica, trackChanges: true);
        return NoContent();
    }
}
