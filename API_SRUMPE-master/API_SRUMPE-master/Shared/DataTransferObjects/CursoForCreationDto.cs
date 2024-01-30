namespace Shared.DataTransferObjects;

public record CursoForCreationDto(string Codigo,string Descripcion,string DepartamentoAcademico,string Nivel,string ProfesorAsignado,string AulasAsignadas,DateTime FechaLimiteInscripcion,string MetodosEnsenanza,
IEnumerable<CursoForCreationDto>? Cursos);
