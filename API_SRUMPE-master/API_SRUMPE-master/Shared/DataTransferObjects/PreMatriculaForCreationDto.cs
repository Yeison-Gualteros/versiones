namespace Shared.DataTransferObjects;

public record PreMatriculaForCreationDto(string GradoONivel, string Turno, string Observaciones,string EstadoPreMatricula, string RequisitosDocumentacion,
    IEnumerable<PreMatriculaForCreationDto>? PreMatricula);
