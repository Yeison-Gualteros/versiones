using Entities.Models.D_DepartamentoAcademico;
using Entities.Models.D_Estudiante;


namespace Shared.DataTransferObjects
{
    public record MateriaForUpdateDto(string Nombre, string Descripcion, string DepartamentoAcademico, string Nivel, string ProfesorAsignado, string ModalidadEnsenanza, string Estado, string? NotasAdicionales, string? GrupoSeccionMateria, string? MetodosEnsenanza);

    public static class MateriaEstudianteMapper
    {
        public static Materias MapToMateria(MateriaForUpdateDto dto)
        {
            return new Materias
            {
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                DepartamentoAcademico=dto.DepartamentoAcademico,
                Nivel = dto.Nivel,
                ProfesorAsignado=dto.ProfesorAsignado,
                ModalidadEnsenanza=dto.ModalidadEnsenanza,
                Estado=dto.Estado,
                NotasAdicionales=dto.NotasAdicionales,  
                GrupoSeccionMateria=dto.GrupoSeccionMateria,
                MetodosEnsenanza=dto.MetodosEnsenanza,
            };
        }
    }
}