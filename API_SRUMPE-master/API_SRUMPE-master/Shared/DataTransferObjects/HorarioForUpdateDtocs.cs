using Entities.Models.D_DepartamentoAcademico;
using Entities.Models.D_Estudiante;


namespace Shared.DataTransferObjects
{
    public record HorarioForUpdateDto(string DiaSemana, TimeSpan HoraInicio, TimeSpan HoraFin, string PeriodoAcademico, string GrupoSeccion, DateTime FechaInicioClases, DateTime FechaFinClases, string EstadoHorario, int DuracionClaseMinutos, string SalaAula, string ProfesorAsistente, string NotificacionCambioHorario);

    public static class HorarioMapper
    {
        public static Horarios MapToHorario(HorarioForUpdateDto dto)
        {
            return new Horarios
            {
                DiaSemana = dto.DiaSemana,
                HoraFin = dto.HoraFin,
                HoraInicio = dto.HoraInicio,
                PeriodoAcademico = dto.PeriodoAcademico,
                GrupoSeccion = dto.GrupoSeccion,
                FechaFinClases = dto.FechaFinClases,
                FechaInicioClases = dto.FechaFinClases,
                EstadoHorario = dto.EstadoHorario,
                DuracionClaseMinutos= dto.DuracionClaseMinutos,
                SalaAula = dto.SalaAula,
                ProfesorAsistente=dto.ProfesorAsistente,
                NotificacionCambioHorario=dto.NotificacionCambioHorario,
            };
        }
    }
}