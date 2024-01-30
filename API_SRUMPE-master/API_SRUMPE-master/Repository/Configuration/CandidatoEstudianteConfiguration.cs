using Entities.Models.D_Estudiante;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration;

public class CandidatoEstudianteConfiguration : IEntityTypeConfiguration<CandidatoEstudiante>
{
    public void Configure(EntityTypeBuilder<CandidatoEstudiante> builder)
    {
        builder.HasData
        (
            new CandidatoEstudiante
            {
                CandidatoEstudianteId = Guid.NewGuid(),
                Nombre = "Axl",
                Apellido = "Acuña",
                FechaNacimiento = new DateTime(1995, 5, 15),
                TipoPersona = "Estudiante"
            },
            new CandidatoEstudiante
            {
                CandidatoEstudianteId = Guid.NewGuid(),
                Nombre = "Juan",
                Apellido = "Castro",
                FechaNacimiento = new DateTime(1990, 8, 22),
                TipoPersona = "Estudiante"
            },
            new CandidatoEstudiante
            {
                CandidatoEstudianteId = Guid.NewGuid(),
                Nombre = "Carlos",
                Apellido = "Sánchez",
                FechaNacimiento = new DateTime(1987, 3, 10),
                TipoPersona = "Estudiante"
            },
            new CandidatoEstudiante
            {
                CandidatoEstudianteId = Guid.NewGuid(),
                Nombre = "Laura",
                Apellido = "López",
                FechaNacimiento = new DateTime(2000, 11, 7),
                TipoPersona = "Estudiante"
            },
            new CandidatoEstudiante
            {
                CandidatoEstudianteId = Guid.NewGuid(),
                Nombre = "Pedro",
                Apellido = "Ramírez",
                FechaNacimiento = new DateTime(1998, 9, 3),
                TipoPersona = "Estudiante"
            },
            new CandidatoEstudiante
            {
                CandidatoEstudianteId = Guid.NewGuid(),
                Nombre = "Ana",
                Apellido = "Martínez",
                FechaNacimiento = new DateTime(1993, 7, 18),
                TipoPersona = "Estudiante"
            },
            new CandidatoEstudiante
            {
                CandidatoEstudianteId = Guid.NewGuid(),
                Nombre = "Roberto",
                Apellido = "Fernández",
                FechaNacimiento = new DateTime(1989, 12, 5),
                TipoPersona = "Estudiante"
            },
            new CandidatoEstudiante
            {
                CandidatoEstudianteId = Guid.NewGuid(),
                Nombre = "Isabel",
                Apellido = "Gómez",
                FechaNacimiento = new DateTime(1996, 2, 25),
                TipoPersona = "Estudiante"
            },
            new CandidatoEstudiante
            {
                CandidatoEstudianteId = Guid.NewGuid(),
                Nombre = "Francisco",
                Apellido = "Díaz",
                FechaNacimiento = new DateTime(1991, 6, 14),
                TipoPersona = "Estudiante"
            },
            new CandidatoEstudiante
            {
                CandidatoEstudianteId = Guid.NewGuid(),
                Nombre = "Sofía",
                Apellido = "Hernández",
                FechaNacimiento = new DateTime(1994, 4, 30),
                TipoPersona = "Estudiante"
            }
        );
    }
}