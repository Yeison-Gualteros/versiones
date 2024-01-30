using API.Presentation.ModelBinders;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace API.Presentation.Controllers
{
    [Route("api/respuestaCupo")]
    [ApiController]
    public class RespuestaCuposController : ControllerBase
    {
        private readonly IServiceManager _service;

        public RespuestaCuposController(IServiceManager service) => _service = service;

        [HttpGet]
        public IActionResult GetRespuestaCupos()
        {
            var respuestaCupos = _service.RespuestaCupoService.GetAllRespuestaCupos(trackChanges: false);

            return Ok(respuestaCupos);
        }

        [HttpGet("{id:guid}", Name = "RespuestaCupoById")]
        public IActionResult GetRespuestaCupo(Guid id)
        {
            var respuestaCupo = _service.RespuestaCupoService.GetRespuestaCupo(id, trackChanges: false);
            return Ok(respuestaCupo);
        }

        [HttpGet("collection/({ids})", Name = "RespuestaCupoCollection")]
        public IActionResult GetRespuestaCupoCollection([ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
        {
            var respuestaCupos = _service.RespuestaCupoService.GetByIds(ids, trackChanges: false);

            return Ok(respuestaCupos);
        }

        [HttpPost]
        public IActionResult CreateRespuestaCupo([FromBody] RespuestaCupoForCreationDto respuestaCupo)
        {
            if (respuestaCupo is null)
                return BadRequest("RespuestaCupoForCreationDto object is null");

            var createdRespuestaCupo = _service.RespuestaCupoService.CreateRespuestaCupo(respuestaCupo);

            return CreatedAtRoute("RespuestaCupoById", new { id = createdRespuestaCupo.RespuestaCupoId }, createdRespuestaCupo);
        }

        [HttpPost("collection")]
        public IActionResult CreateRespuestaCupoCollection([FromBody] IEnumerable<RespuestaCupoForCreationDto> respuestaCupoCollection)
        {
            var result = _service.RespuestaCupoService.CreateRespuestaCupoCollection(respuestaCupoCollection);

            return CreatedAtRoute("RespuestaCupoCollection", new { result.ids }, result.respuestaCupos);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteRespuestaCupo(Guid id)
        {
            _service.RespuestaCupoService.DeleteRespuestaCupo(id, trackChanges: false);
            return NoContent();
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpdateRespuestaCupo(Guid id, [FromBody] RespuestaCupoForUpdateDto respuestaCupo)
        {
            if (respuestaCupo is null)
                return BadRequest("RespuestaCupoForUpdateDto object is null");
            _service.RespuestaCupoService.UpdateRespuestaCupo(id, respuestaCupo, trackChanges: true);
            return NoContent();
        }
    }
}

