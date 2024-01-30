using Entities.Models;
using Entities.Models.D_Acudiente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record TelefonoAcudienteForUpdateDto(int Numero, string? Tipo, string Indicativo);

    public static class TelefonoAcudienteMapper
    {
        public static TelefonoAcudiente MapToTelefonoAcudiente(TelefonoAcudienteForUpdateDto dto)
        {
            return new TelefonoAcudiente
            {
                Numero = dto.Numero,
                Tipo = dto.Tipo,
                Indicativo = dto.Indicativo
            };
        }
    }
}
