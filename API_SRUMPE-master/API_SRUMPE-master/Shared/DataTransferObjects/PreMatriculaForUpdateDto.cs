using Entities.Models;
using Entities.Models.D_Estudiante;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record PreMatriculaForUpdateDto(string GradoONivel, string Turno, string Observaciones, string EstadoPreMatricula, string RequisitosDocumentacion);

    public static class PreMatriculaMapper
    {
        public static PreMatricula MapToPreMatricula(PreMatriculaForUpdateDto dto)
        {
            return new PreMatricula
            {
                GradoONivel = dto.GradoONivel,
                Turno = dto.Turno,
                Observaciones = dto.Observaciones,
                EstadoPreMatricula = dto.EstadoPreMatricula,
                RequisitosDocumentacion = dto.RequisitosDocumentacion

            };
        }
    }
}
