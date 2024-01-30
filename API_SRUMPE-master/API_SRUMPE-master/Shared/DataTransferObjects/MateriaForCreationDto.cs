namespace Shared.DataTransferObjects;

public record MateriaForCreationDto(string Nombre,string Descripcion,string DepartamentoAcademico,string Nivel,string ProfesorAsignado,string ModalidadEnsenanza,string Estado,string? NotasAdicionales,string? GrupoSeccionMateria,string? MetodosEnsenanza,
IEnumerable<MateriaForCreationDto>? Materias);