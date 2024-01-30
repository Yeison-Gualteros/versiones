namespace Shared.DataTransferObjects;

public record AsistenciaForCreationDto(string NombreAsistente,DateTime FechaHoraAsistencia,string TipoEvento,string UbicacionEvento,bool Asistio,string Notas,
IEnumerable<AsistenciaForCreationDto>? Asistencia);
