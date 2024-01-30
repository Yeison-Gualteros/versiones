using Entities.Models.D_DepartamentoAcademico;


namespace Shared.DataTransferObjects;

public record CursoForUpdateDto(string Codigo, string Descripcion, string DepartamentoAcademico, string Nivel, string ProfesorAsignado, string AulasAsignadas, DateTime FechaLimiteInscripcion, string MetodosEnsenanza);

public static class CursoMapper
{
    public static Cursos MapToCurso(CursoForUpdateDto dto)
    {
        return new Cursos
        {
            Codigo = dto.Codigo,
            Descripcion = dto.Descripcion,
            DepartamentoAcademico= dto.DepartamentoAcademico,
            Nivel = dto.Nivel,
            ProfesorAsignado= dto.ProfesorAsignado,
            AulasAsignadas= dto.AulasAsignadas,
            FechaLimiteInscripcion=dto.FechaLimiteInscripcion,
            MetodosEnsenanza= dto.MetodosEnsenanza,
        };
    }
}