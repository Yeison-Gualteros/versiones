namespace Shared.DataTransferObjects;

public record CandidatoEstudianteForCreationDto(string Nombre, string Apellido,
    IEnumerable<EstudianteDocumentosForCreationDto>? EstudianteDocumentos);

