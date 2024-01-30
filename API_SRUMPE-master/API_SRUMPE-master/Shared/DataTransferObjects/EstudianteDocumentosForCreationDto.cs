namespace Shared.DataTransferObjects;

public record EstudianteDocumentosForCreationDto(
        string NombreDocumento,
        string TipoDocumento,
        int NumeroDocumento,
        bool Estado,
        string Observaciones,
        DateTime? FechaActualizacion,
        string Ubicacion,
        int Tamaño);
