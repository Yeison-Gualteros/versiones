using Entities.Models.D_Acudiente;
using Entities.Models.D_Notas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration;

internal class AsistenciaConfiguration : IEntityTypeConfiguration<Asistencia>
{
    public void Configure(EntityTypeBuilder<Asistencia> builder)

    {
        builder.HasData(
            new Asistencia
            {
                AsistenciaId = 1,
                NombreAsistente = "Juan Pérez",
                FechaHoraAsistencia = DateTime.Parse("2023-10-03 09:00:00"),
                TipoEvento = "Conferencia",
                UbicacionEvento = "Salón A",
                Asistio = true,
                Notas = "Asistió puntualmente."
            },

        new Asistencia
        {
            AsistenciaId = 2,
            NombreAsistente = "María Rodríguez",
            FechaHoraAsistencia = DateTime.Parse("2023-10-04 15:30:00"),
            TipoEvento = "Reunión",
            UbicacionEvento = "Sala de juntas",
            Asistio = false,
            Notas = "No pudo asistir debido a un compromiso previo."
        },

        new Asistencia
        {
            AsistenciaId = 3,
            NombreAsistente = "Carlos González",
            FechaHoraAsistencia = DateTime.Parse("2023-10-05 14:00:00"),
            TipoEvento = "Taller",
            UbicacionEvento = "Aula 101",
            Asistio = true,
            Notas = "Participó activamente en el taller."
        },

        new Asistencia
        {
            AsistenciaId = 4,
            NombreAsistente = "Ana López",
            FechaHoraAsistencia = DateTime.Parse("2023-10-06 10:30:00"),
            TipoEvento = "Conferencia",
            UbicacionEvento = "Salón B",
            Asistio = true,
            Notas = "Tomó notas detalladas durante la conferencia."
        },

        new Asistencia
        {
            AsistenciaId = 5,
            NombreAsistente = "Pedro Ramírez",
            FechaHoraAsistencia = DateTime.Parse("2023-10-07 18:00:00"),
            TipoEvento = "Reunión",
            UbicacionEvento = "Sala de conferencias",
            Asistio = true,
            Notas = "Participó en la discusión de temas importantes."
        },

        new Asistencia
        {
            AsistenciaId = 6,
            NombreAsistente = "Laura Martínez",
            FechaHoraAsistencia = DateTime.Parse("2023-10-08 11:45:00"),
            TipoEvento = "Seminario",
            UbicacionEvento = "Auditorio",
            Asistio = true,
            Notas = "Hizo preguntas interesantes durante el seminario."
        }

        );
    }
}