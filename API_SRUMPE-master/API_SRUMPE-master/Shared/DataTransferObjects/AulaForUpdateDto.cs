using Entities.Models.D_DepartamentoAcademico;

namespace Shared.DataTransferObjects;
public record AulaForUpdateDto(string NombreNumero, string Ubicacion, int Capacidad, string TipoAula, string EstadoAula, string HorarioDisponibilidad, string NotasAdicionales, DateTime UltimaActualizacion, string ResponsableAula, string RegistrosIncidentesProblemas);
public static class AulaMapper
{
    public static Aulas MapToCandidatoEstudiante(AulaForUpdateDto dto)
    {
        return new Aulas
        {
            NombreNumero = dto.NombreNumero,
            Ubicacion = dto.Ubicacion,
            Capacidad = dto.Capacidad,
            TipoAula = dto.TipoAula,
            EstadoAula = dto.EstadoAula,
            HorarioDisponibilidad= dto.HorarioDisponibilidad,
            NotasAdicionales = dto.NotasAdicionales,
            UltimaActualizacion=dto.UltimaActualizacion,
            ResponsableAula = dto.ResponsableAula,
            RegistrosIncidentesProblemas=dto.RegistrosIncidentesProblemas

        };
    }
}

