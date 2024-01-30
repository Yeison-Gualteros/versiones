using Entities.Models.D_Acudiente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record DireccionAcudienteForUpdateDto(string Calle, string ColoniaBarrio, string CiudadLocalidad, string CodigoPostal, string EstadoProvincia, string Pais);

    public static class DireccionAcudienteMapper
    {
        public static DireccionAcudiente MapToDireccionAcudiente(DireccionAcudienteForUpdateDto dto)
        {
            return new DireccionAcudiente
            {
                Calle = dto.Calle,
                ColoniaBarrio = dto.ColoniaBarrio,
                CiudadLocalidad = dto.CiudadLocalidad,
                CodigoPostal = dto.CodigoPostal,
                EstadoProvincia = dto.EstadoProvincia,
                Pais = dto.Pais
            };
        }
    }
}
