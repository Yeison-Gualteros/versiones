using Entities.Models;
using Entities.Models.D_Estudiante;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record RespuestaCupoForUpdateDto(DateTime FechaRespuesta, string EstadoRespuesta, string MensajeRespuesta, DateTime FechaVencimiento, string UsuarioRespuesta, string TipoRespuesta, TimeSpan DuracionRespuesta, string Prioridad);

    public static class RespuestaCupoMapper
    {
        public static RespuestaCupo MapToRespuestaCupo(RespuestaCupoForUpdateDto dto)
        {
            return new RespuestaCupo
            {
                FechaRespuesta = dto.FechaRespuesta,
                EstadoRespuesta = dto.EstadoRespuesta,
                MensajeRespuesta = dto.MensajeRespuesta,
                FechaVencimiento = dto.FechaVencimiento,
                UsuarioRespuesta = dto.UsuarioRespuesta,
                TipoRespuesta = dto.TipoRespuesta,
                DuracionRespuesta = dto.DuracionRespuesta,
                Prioridad = dto.Prioridad

            };
        }
    }
}