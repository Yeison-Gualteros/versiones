namespace Shared.DataTransferObjects;

public record MatriculaForCreationDto(DateTime FechaMatricula,string EstadoMatricula, string TipoMatricula,int PeriodoAcademico,string Comentarios,string CategoriaMatricula,string InformacionPlanEstudios,string RegistroCambios,
IEnumerable<MatriculaForCreationDto>? Matricula);