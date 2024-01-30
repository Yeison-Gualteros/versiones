namespace Shared.DataTransferObjects;

public record RespuestaCupoForCreationDto( DateTime FechaRespuesta,string EstadoRespuesta,string MensajeRespuesta, DateTime FechaVencimiento, string UsuarioRespuesta, string TipoRespuesta, TimeSpan DuracionRespuesta, string Prioridad,
IEnumerable<RespuestaCupoForCreationDto>? RespuestaCupo);
