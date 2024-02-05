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
                Telefono = 123456,
                Direccion = "calle 10",
                FechaNacimiento = new DateTime(1995, 5, 15),
                TipoPersona = "Estudiante"
            },
            new CandidatoEstudiante
            {
                CandidatoEstudianteId = Guid.NewGuid(),
                Nombre = "Juan",
                Apellido = "Castro",
                Telefono = 123456,
                Direccion = "calle 9",
                FechaNacimiento = new DateTime(1990, 8, 22),
                TipoPersona = "Estudiante"
            },
            new CandidatoEstudiante
            {
                CandidatoEstudianteId = Guid.NewGuid(),
                Nombre = "Carlos",
                Apellido = "Sánchez",
                Telefono = 123456,
                Direccion = "calle 8",
                FechaNacimiento = new DateTime(1987, 3, 10),
                TipoPersona = "Estudiante"
            },
            new CandidatoEstudiante
            {
                CandidatoEstudianteId = Guid.NewGuid(),
                Nombre = "Laura",
                Apellido = "López",
                Telefono = 123456,
                Direccion = "calle 7",
                FechaNacimiento = new DateTime(2000, 11, 7),
                TipoPersona = "Estudiante"
            },
            new CandidatoEstudiante
            {
                CandidatoEstudianteId = Guid.NewGuid(),
                Nombre = "Pedro",
                Apellido = "Ramírez",
                Telefono = 123456,
                Direccion = "calle 6",
                FechaNacimiento = new DateTime(1998, 9, 3),
                TipoPersona = "Estudiante"
            },
            new CandidatoEstudiante
            {
                CandidatoEstudianteId = Guid.NewGuid(),
                Nombre = "Ana",
                Apellido = "Martínez",
                Telefono = 123456,
                Direccion = "calle 5",
                FechaNacimiento = new DateTime(1993, 7, 18),
                TipoPersona = "Estudiante"
            },
            new CandidatoEstudiante
            {
                CandidatoEstudianteId = Guid.NewGuid(),
                Nombre = "Roberto",
                Apellido = "Fernández",
                Telefono = 123456,
                Direccion = "calle 4",
                FechaNacimiento = new DateTime(1989, 12, 5),
                TipoPersona = "Estudiante"
            },
            new CandidatoEstudiante
            {
                CandidatoEstudianteId = Guid.NewGuid(),
                Nombre = "Isabel",
                Apellido = "Gómez",
                Telefono = 123456,
                Direccion = "calle 3",
                FechaNacimiento = new DateTime(1996, 2, 25),
                TipoPersona = "Estudiante"
            },
            new CandidatoEstudiante
            {
                CandidatoEstudianteId = Guid.NewGuid(),
                Nombre = "Francisco",
                Apellido = "Díaz",
                Telefono = 123456,
                Direccion = "calle 2",
                FechaNacimiento = new DateTime(1991, 6, 14),
                TipoPersona = "Estudiante"
            },
            new CandidatoEstudiante
            {
                CandidatoEstudianteId = Guid.NewGuid(),
                Nombre = "Sofía",
                Apellido = "Hernández",
                Telefono = 123456,
                Direccion = "calle 1",
                FechaNacimiento = new DateTime(1994, 4, 30),
                TipoPersona = "Estudiante"
            }
        );
    }
}