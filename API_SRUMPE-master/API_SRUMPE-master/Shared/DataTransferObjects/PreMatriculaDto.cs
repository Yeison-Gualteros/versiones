using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects;

public record PreMatriculaDto
{
    public Guid PreMatriculaId { get; set; }
    public string GradoONivel { get; set; }
    public string Turno { get; set; }
    public string Observaciones { get; set; }
    public string EstadoPreMatricula { get; set; }
    public string RequisitosDocumentacion { get; set; }
}