
namespace Shared.DataTransferObjects;
public record AulaDto
{
    public Guid AulaId { get; set; }
    public string NombreNumero { get; set; }
    public string Ubicacion { get; set; }
    public int Capacidad { get; set; }
    public string TipoAula { get; set; }
    public string EstadoAula { get; set; }
    public string HorarioDisponibilidad { get; set; }
    public string NotasAdicionales { get; set; }
    public DateTime UltimaActualizacion { get; set; }
    public string ResponsableAula { get; set; }
    public string RegistrosIncidentesProblemas { get; set; }
}