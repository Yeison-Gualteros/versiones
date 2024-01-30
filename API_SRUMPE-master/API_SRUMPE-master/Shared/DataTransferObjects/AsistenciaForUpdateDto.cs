using Entities.Models.D_Notas;

namespace Shared.DataTransferObjects
{
    public record AsistenciaForUpdateDto(string NombreAsistente, DateTime FechaHoraAsistencia, string TipoEvento, string UbicacionEvento, bool Asistio, string Notas)
    {
        public static Asistencia MapToAsistencia(AsistenciaForUpdateDto dto)
        {
            return new Asistencia
            {
                NombreAsistente = dto.NombreAsistente,
                FechaHoraAsistencia = dto.FechaHoraAsistencia,
                TipoEvento = dto.TipoEvento,
                UbicacionEvento = dto.UbicacionEvento,
                Asistio = dto.Asistio,
                Notas = dto.Notas,
            };
        }
    }
}
