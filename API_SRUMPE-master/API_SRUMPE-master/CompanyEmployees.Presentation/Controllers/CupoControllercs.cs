using API.Presentation.ModelBinders;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;


namespace API.Presentation.Controllers;

[Route("api/Cupo")]
[ApiController]
public class CupoController : ControllerBase
{
    private readonly IServiceManager _service;

    public CupoController(IServiceManager service) => _service = service;

    [HttpGet]
    public IActionResult GetCupos()
    {
        var cupos = _service.CupoService.GetAllCupos(trackChanges: false);

        return Ok(cupos);
    }

    [HttpGet("{id:guid}", Name = "CupoById")]
    public IActionResult GetCupo(Guid id)
    {
        var cupo = _service.CupoService.GetCupo(id, trackChanges: false);
        return Ok(cupo);
    }

    [HttpGet("collection/({ids})", Name = "CupoCollection")]
    public IActionResult GetCupoCollection([ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
    {
        var cupos = _service.CupoService.GetByIds(ids, trackChanges: false);

        return Ok(cupos);
    }

    [HttpPost]
    public IActionResult CreateCupo([FromBody] CupoForCreationDto cupo)
    {
        if (cupo is null)
            return BadRequest("CupoForCreationDto object is null");

        var createdCupo = _service.CupoService.CreateCupo(cupo);

        return CreatedAtRoute("CupoById", new { id = createdCupo.CupoId }, createdCupo);
    }

    [HttpPost("collection")]
    public IActionResult CreateCupoCollection([FromBody] IEnumerable<CupoForCreationDto> cupoCollection)
    {
        var result = _service.CupoService.CreateCupoCollection(cupoCollection);

        return CreatedAtRoute("CupoCollection", new { result.ids }, result.cupos);
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteCupo(Guid id)
    {
        _service.CupoService.DeleteCupo(id, trackChanges: false);
        return NoContent();
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpdateCupo(Guid id, [FromBody] CupoForUpdateDto cupo)
    {
        if (cupo is null)
            return BadRequest("CupoForUpdateDto object is null");
        _service.CupoService.UpdateCupo(id, cupo, trackChanges: true);
        return NoContent();
    }
}

