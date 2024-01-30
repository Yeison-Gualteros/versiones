namespace Shared.DataTransferObjects;

public record EstadisticaForCreationDto(string Materia,decimal NotaPromedio,decimal NotaMaxima,decimal NotaMinima,int CantidadExamenes,DateTime FechaRegistro,int AñoEscolar, string PeriodoEscolar,
IEnumerable<EstadisticaForCreationDto>? Estadisticas);
