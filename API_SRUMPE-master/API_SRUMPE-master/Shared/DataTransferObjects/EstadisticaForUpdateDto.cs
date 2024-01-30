using Entities.Models.D_Notas;

namespace Shared.DataTransferObjects;

public record EstadisticaForUpdateDto(string Materia, decimal NotaPromedio, decimal NotaMaxima, decimal NotaMinima, int CantidadExamenes, DateTime FechaRegistro, int AñoEscolar, string PeriodoEscolar)
{
    public static Estadisticas MapToEstadistica(EstadisticaForUpdateDto dto)
    {
        return new Estadisticas
        {
            Materia = dto.Materia,
            NotaPromedio = dto.NotaPromedio,
            NotaMaxima = dto.NotaMaxima,
            NotaMinima = dto.NotaMinima,
            CantidadExamenes = dto.CantidadExamenes,
            FechaRegistro = dto.FechaRegistro,
            AñoEscolar = dto.AñoEscolar,
            PeriodoEscolar = dto.PeriodoEscolar
        };
    }
}
