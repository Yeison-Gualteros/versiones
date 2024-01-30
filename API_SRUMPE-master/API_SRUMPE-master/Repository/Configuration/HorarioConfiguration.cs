using Entities.Models.D_DepartamentoAcademico;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration;

public class HorarioConfiguration : IEntityTypeConfiguration<Horarios>
{
    public void Configure(EntityTypeBuilder<Horarios> builder)
    {
        builder.HasData(
            new Horarios
            {
                HorarioId = Guid.NewGuid(),
                DiaSemana = "Lunes",
                HoraInicio = TimeSpan.Parse("09:00:00"),
                HoraFin = TimeSpan.Parse("11:00:00"),
                PeriodoAcademico = "Semestre de Otoño",
                GrupoSeccion = "Grupo A",
                FechaInicioClases = new DateTime(2023, 09, 05),
                FechaFinClases = new DateTime(2023, 12, 15),
                EstadoHorario = "Activo",
                DuracionClaseMinutos = 120,
                SalaAula = "Aula 101",
                ProfesorAsistente = "Profesor Asistente 1",
                NotificacionCambioHorario = "No"
            },
            new Horarios
            {
                HorarioId = Guid.NewGuid(),
                DiaSemana = "Martes",
                HoraInicio = TimeSpan.Parse("14:00:00"),
                HoraFin = TimeSpan.Parse("16:00:00"),
                PeriodoAcademico = "Semestre de Primavera",
                GrupoSeccion = "Grupo B",
                FechaInicioClases = new DateTime(2023, 01, 10),
                FechaFinClases = new DateTime(2023, 04, 25),
                EstadoHorario = "Activo",
                DuracionClaseMinutos = 120,
                SalaAula = "Aula 203",
                ProfesorAsistente = "Profesor Asistente 2",
                NotificacionCambioHorario = "Sí"
            },
            new Horarios
            {
                HorarioId = Guid.NewGuid(),
                DiaSemana = "Miércoles",
                HoraInicio = TimeSpan.Parse("11:30:00"),
                HoraFin = TimeSpan.Parse("13:30:00"),
                PeriodoAcademico = "Semestre de Verano",
                GrupoSeccion = "Grupo C",
                FechaInicioClases = new DateTime(2023, 06, 05),
                FechaFinClases = new DateTime(2023, 08, 15),
                EstadoHorario = "Activo",
                DuracionClaseMinutos = 120,
                SalaAula = "Aula 305",
                ProfesorAsistente = "Profesor Asistente 3",
                NotificacionCambioHorario = "No"
            },
            new Horarios
            {
                HorarioId = Guid.NewGuid(),
                DiaSemana = "Jueves",
                HoraInicio = TimeSpan.Parse("16:30:00"),
                HoraFin = TimeSpan.Parse("18:30:00"),
                PeriodoAcademico = "Semestre de Invierno",
                GrupoSeccion = "Grupo D",
                FechaInicioClases = new DateTime(2023, 11, 20),
                FechaFinClases = new DateTime(2024, 03, 05),
                EstadoHorario = "Activo",
                DuracionClaseMinutos = 120,
                SalaAula = "Aula 401",
                ProfesorAsistente = "Profesor Asistente 4",
                NotificacionCambioHorario = "Sí"
            },
            new Horarios
            {
                HorarioId = Guid.NewGuid(),
                DiaSemana = "Viernes",
                HoraInicio = TimeSpan.Parse("08:00:00"),
                HoraFin = TimeSpan.Parse("10:00:00"),
                PeriodoAcademico = "Semestre de Primavera",
                GrupoSeccion = "Grupo E",
                FechaInicioClases = new DateTime(2023, 01, 10),
                FechaFinClases = new DateTime(2023, 04, 25),
                EstadoHorario = "Activo",
                DuracionClaseMinutos = 120,
                SalaAula = "Aula 102",
                ProfesorAsistente = "Profesor Asistente 5",
                NotificacionCambioHorario = "No"
            }
        );
    }
}

