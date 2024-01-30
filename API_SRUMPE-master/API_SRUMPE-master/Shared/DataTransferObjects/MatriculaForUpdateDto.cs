using Entities.Models;
using Entities.Models.D_Estudiante;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record MatriculaForUpdateDto(DateTime FechaMatricula, string EstadoMatricula, string TipoMatricula, int PeriodoAcademico, string Comentarios, string CategoriaMatricula, string InformacionPlanEstudios);

    public static class MatriculaMapper
    {
        public static Matricula MapToMatricula(MatriculaForUpdateDto dto)
        {
            return new Matricula
            {
                FechaMatricula = dto.FechaMatricula,
                EstadoMatricula = dto.EstadoMatricula,
                TipoMatricula = dto.TipoMatricula,
                PeriodoAcademico = dto.PeriodoAcademico,
                Comentarios = dto.Comentarios,
                CategoriaMatricula = dto.CategoriaMatricula,
                InformacionPlanEstudios= dto.InformacionPlanEstudios,
            };
        }
    }
}