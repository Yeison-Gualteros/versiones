using Entities.Models.D_Estudiante;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record EstudianteDocumentosForUpdateDto(string NombreDocumento, string TipoDocumento, int NumeroDocumento, bool Estado, string Observaciones, DateTime? FechaActualizacion, string Ubicacion, int Tamaño);

    public static class EstudianteDocumentoMapper
    {
        public static EstudianteDocumentos MapToEstudianteDocumentos(EstudianteDocumentosForUpdateDto dto)
        {
            return new EstudianteDocumentos
            {
                NombreDocumento = dto.NombreDocumento,
                TipoDocumento = dto.TipoDocumento,
                NumeroDocumento = dto.NumeroDocumento,
                Estado = dto.Estado,
                Observaciones = dto.Observaciones,
                FechaActualizacion = dto.FechaActualizacion,
                Ubicacion = dto.Ubicacion,
                Tamaño = dto.Tamaño,
                
            };
        }
    }
}
