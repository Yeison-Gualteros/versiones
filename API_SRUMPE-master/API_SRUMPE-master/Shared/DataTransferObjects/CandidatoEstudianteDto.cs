namespace Shared.DataTransferObjects;

public record CandidatoEstudianteDto
{
    public Guid CandidatoEstudianteId { get; set; }
    public string Nombre { get; set; } = null!;
    public string Apellido { get; set; } = null!;
    public DateTime? FechaNacimiento { get; set; }
    public string? TipoPersona { get; set; }
}
