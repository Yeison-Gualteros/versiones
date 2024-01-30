namespace Shared.DataTransferObjects;
public record TelefonoAcudienteForCreationDto(int Numero, string Tipo, string Indicativo, IEnumerable<TelefonoAcudienteForCreationDto>? TelefonoAcudiente);
