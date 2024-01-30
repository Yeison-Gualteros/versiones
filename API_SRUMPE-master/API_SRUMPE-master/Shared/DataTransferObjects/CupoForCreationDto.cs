namespace Shared.DataTransferObjects;

public record CupoForCreationDto(int CantidadDisponible,DateTime FechaInicio,DateTime FechaFin,string? Descripcion,string? Ubicacion,bool Estado,TimeSpan Duracion, string? Comentarios,
IEnumerable<CupoForCreationDto>? Cupo);
