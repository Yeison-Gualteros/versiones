using API.Presentation.ModelBinders;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;


namespace API.Presentation.Controllers;

[Route("api/cursos")]
[ApiController]
public class CursosController : ControllerBase
{
    private readonly IServiceManager _service;

    public CursosController(IServiceManager service) => _service = service;

    [HttpGet]
    public IActionResult GetCursos()
    {
        var cursos = _service.CursoService.GetAllCursos(trackChanges: false);

        return Ok(cursos);
    }

    [HttpGet("{id:guid}", Name = "CursoById")]
    public IActionResult GetCurso(Guid id)
    {
        var curso = _service.CursoService.GetCurso(id, trackChanges: false);
        return Ok(curso);
    }

    [HttpGet("collection/({ids})", Name = "CursoCollection")]
    public IActionResult GetCursoCollection([ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
    {
        var cursos = _service.CursoService.GetByIds(ids, trackChanges: false);

        return Ok(cursos);
    }

    [HttpPost]
    public IActionResult CreateCurso([FromBody] CursoForCreationDto curso)
    {
        if (curso is null)
            return BadRequest("CursoForCreationDto object is null");

        var createdCurso = _service.CursoService.CreateCurso(curso);

        return CreatedAtRoute("CursoById", new { id = createdCurso.CursoId }, createdCurso);
    }

    [HttpPost("collection")]
    public IActionResult CreateCursoCollection([FromBody] IEnumerable<CursoForCreationDto> cursoCollection)
    {
        var result = _service.CursoService.CreateCursoCollection(cursoCollection);

        return CreatedAtRoute("CursoCollection", new { result.ids }, result.cursos);
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteCurso(Guid id)
    {
        _service.CursoService.DeleteCurso(id, trackChanges: false);
        return NoContent();
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpdateCurso(Guid id, [FromBody] CursoForUpdateDto cursoForUpdate)
    {
        if (cursoForUpdate is null)
            return BadRequest("CursoForUpdateDto object is null");
        _service.CursoService.UpdateCurso(id, cursoForUpdate, trackChanges: true);
        return NoContent();
    }
}

