
namespace Shared.DataTransferObjects;


public record AulaForCreationDto(string NombreNumero,string Ubicacion,int Capacidad,string TipoAula,string EstadoAula,string HorarioDisponibilidad, string NotasAdicionales, DateTime UltimaActualizacion, string ResponsableAula, string RegistrosIncidentesProblemas, 
IEnumerable<AulaForCreationDto>? Aulas);
