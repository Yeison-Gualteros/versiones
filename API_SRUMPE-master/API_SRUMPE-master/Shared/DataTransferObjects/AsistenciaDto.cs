namespace Shared.DataTransferObjects;

public record AsistenciaDto
{
    public int AsistenciaId { get; set; }
    public string NombreAsistente { get; set; }
    public DateTime FechaHoraAsistencia { get; set; }
    public string TipoEvento { get; set; }
    public string UbicacionEvento { get; set; }
    public bool Asistio { get; set; }
    public string Notas { get; set; }
}