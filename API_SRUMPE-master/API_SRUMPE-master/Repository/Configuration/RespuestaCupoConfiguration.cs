using Entities.Models;
using Entities.Models.D_Estudiante;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration;

public class RespuestaCupoConfiguration : IEntityTypeConfiguration<RespuestaCupo>
{
    public void Configure(EntityTypeBuilder<RespuestaCupo> builder)
    {
        builder.HasData
        (
              new RespuestaCupo
              {
                  RespuestaCupoId = Guid.NewGuid(),
                  FechaRespuesta = DateTime.Now.AddDays(1),
                  EstadoRespuesta = "Aceptada",
                  MensajeRespuesta = "Respuesta 1",
                  FechaVencimiento = DateTime.Now.AddMonths(1),
                  UsuarioRespuesta = "Usuario1",
                  TipoRespuesta = "Aceptación",
                  DuracionRespuesta = TimeSpan.FromDays(30),
                  Prioridad = "Alta"
              },

            new RespuestaCupo
            {
                RespuestaCupoId = Guid.NewGuid(),
                FechaRespuesta = DateTime.Now.AddDays(2),
                EstadoRespuesta = "Rechazada",
                MensajeRespuesta = "Respuesta 2",
                FechaVencimiento = DateTime.Now.AddMonths(2),
                UsuarioRespuesta = "Usuario2",
                TipoRespuesta = "Rechazo",
                DuracionRespuesta = TimeSpan.FromDays(45),
                Prioridad = "Media"
            },

            new RespuestaCupo
            {
                RespuestaCupoId = Guid.NewGuid(),
                FechaRespuesta = DateTime.Now.AddDays(3),
                EstadoRespuesta = "Pendiente",
                MensajeRespuesta = "Respuesta 3",
                FechaVencimiento = DateTime.Now.AddMonths(3),
                UsuarioRespuesta = "Usuario3",
                TipoRespuesta = "Pendiente",
                DuracionRespuesta = TimeSpan.FromDays(60),
                Prioridad = "Baja"
            },

            new RespuestaCupo
            {
                RespuestaCupoId = Guid.NewGuid(),
                FechaRespuesta = DateTime.Now.AddDays(4),
                EstadoRespuesta = "Aceptada",
                MensajeRespuesta = "Respuesta 4",
                FechaVencimiento = DateTime.Now.AddMonths(4),
                UsuarioRespuesta = "Usuario4",
                TipoRespuesta = "Aceptación",
                DuracionRespuesta = TimeSpan.FromDays(30),
                Prioridad = "Alta"
            },

            new RespuestaCupo
            {
                RespuestaCupoId = Guid.NewGuid(),
                FechaRespuesta = DateTime.Now.AddDays(5),
                EstadoRespuesta = "Rechazada",
                MensajeRespuesta = "Respuesta 5",
                FechaVencimiento = DateTime.Now.AddMonths(5),
                UsuarioRespuesta = "Usuario5",
                TipoRespuesta = "Rechazo",
                DuracionRespuesta = TimeSpan.FromDays(45),
                Prioridad = "Media"
            },
            new RespuestaCupo
            {
                RespuestaCupoId = Guid.NewGuid(),
                FechaRespuesta = DateTime.Now.AddDays(6),
                EstadoRespuesta = "Aceptada",
                MensajeRespuesta = "Respuesta 6",
                FechaVencimiento = DateTime.Now.AddMonths(6),
                UsuarioRespuesta = "Usuario6",
                TipoRespuesta = "Aceptación",
                DuracionRespuesta = TimeSpan.FromDays(30),
                Prioridad = "Alta"
            },

            new RespuestaCupo
            {
                RespuestaCupoId = Guid.NewGuid(),
                FechaRespuesta = DateTime.Now.AddDays(7),
                EstadoRespuesta = "Rechazada",
                MensajeRespuesta = "Respuesta 7",
                FechaVencimiento = DateTime.Now.AddMonths(7),
                UsuarioRespuesta = "Usuario7",
                TipoRespuesta = "Rechazo",
                DuracionRespuesta = TimeSpan.FromDays(45),
                Prioridad = "Media"
            },

            new RespuestaCupo
            {
                RespuestaCupoId = Guid.NewGuid(),
                FechaRespuesta = DateTime.Now.AddDays(8),
                EstadoRespuesta = "Pendiente",
                MensajeRespuesta = "Respuesta 8",
                FechaVencimiento = DateTime.Now.AddMonths(8),
                UsuarioRespuesta = "Usuario8",
                TipoRespuesta = "Pendiente",
                DuracionRespuesta = TimeSpan.FromDays(60),
                Prioridad = "Baja"
            },

            new RespuestaCupo
            {
                RespuestaCupoId = Guid.NewGuid(),
                FechaRespuesta = DateTime.Now.AddDays(9),
                EstadoRespuesta = "Aceptada",
                MensajeRespuesta = "Respuesta 9",
                FechaVencimiento = DateTime.Now.AddMonths(9),
                UsuarioRespuesta = "Usuario9",
                TipoRespuesta = "Aceptación",
                DuracionRespuesta = TimeSpan.FromDays(30),
                Prioridad = "Alta"
            }
        );
    }
}
