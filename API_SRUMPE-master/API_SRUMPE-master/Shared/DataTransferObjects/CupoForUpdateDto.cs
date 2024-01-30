using Entities.Models.D_Estudiante;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record CupoForUpdateDto(int CantidadDisponible, DateTime FechaInicio, DateTime FechaFin, string? Descripcion, string? Ubicacion, bool Estado, TimeSpan Duracion, string? Comentarios);

    public static class CupoMapper
    {
        public static Cupo MapToCupo(CupoForUpdateDto dto)
        {
            return new Cupo
            {
                CantidadDisponible = dto.CantidadDisponible, 
                FechaInicio = dto.FechaInicio,
                FechaFin = dto.FechaFin,
                Descripcion = dto.Descripcion,
                Estado = dto.Estado,
                Duracion=dto.Duracion,
            };
        }
    }
}
