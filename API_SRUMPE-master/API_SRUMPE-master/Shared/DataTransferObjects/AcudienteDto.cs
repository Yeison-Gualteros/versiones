
namespace Shared.DataTransferObjects;

public record AcudienteDto
{
    public Guid AcudienteId { get; set; }
    public string? Nombres { get; set; }
    public string? Apellidos { get; set; }
    public int NumeroIdentificacion { get; set; }
    public string? Genero { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public string? CorreoElectronico { get; set; }
    public string? RelacionConEstudiante { get; set; }
    public string? EstadoCivil { get; set; }
    public string? Ocupacion { get; set; }
    public bool Estado { get; set; }
    public DateTime FechaRegistro { get; set; }
}
