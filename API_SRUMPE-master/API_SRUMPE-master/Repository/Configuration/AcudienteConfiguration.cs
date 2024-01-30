using Entities.Models.D_Acudiente;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    internal class AcudienteConfiguration : IEntityTypeConfiguration<Acudiente>
    {
        public void Configure(EntityTypeBuilder<Acudiente> builder)
        
        {
            builder.HasData (
            new Acudiente
            {
                AcudienteId = Guid.NewGuid(),
                Nombres = "María",
                Apellidos = "Pérez",
                NumeroIdentificacion = 12345,
                Genero = "Femenino",
                FechaNacimiento = new DateTime(1980, 5, 15),
                CorreoElectronico = "maria.perez@email.com",
                RelacionConEstudiante = "Madre",
                EstadoCivil = "Casada",
                Ocupacion = "Ingeniera",
                Estado = true,
                FechaRegistro = DateTime.Now
            },

          new Acudiente
          {
              AcudienteId = Guid.NewGuid(),
              Nombres = "Juan",
              Apellidos = "González",
              NumeroIdentificacion = 67890,
              Genero = "Masculino",
              FechaNacimiento = new DateTime(1975, 8, 25),
              CorreoElectronico = "juan.gonzalez@email.com",
              RelacionConEstudiante = "Padre",
              EstadoCivil = "Soltero",
              Ocupacion = "Abogado",
              Estado = true,
              FechaRegistro = DateTime.Now
          },

          new Acudiente
            {
              AcudienteId = Guid.NewGuid(),
              Nombres = "Ana",
                Apellidos = "López",
                NumeroIdentificacion = 54321,
                Genero = "Femenino",
                FechaNacimiento = new DateTime(1990, 3, 10),
                CorreoElectronico = "ana.lopez@email.com",
                RelacionConEstudiante = "Tutor Legal",
                EstadoCivil = "Divorciada",
                Ocupacion = "Médica",
                Estado = true,
                FechaRegistro = DateTime.Now
            },

           new Acudiente
            {
               AcudienteId = Guid.NewGuid(),
               Nombres = "Pedro",
                Apellidos = "Martínez",
                NumeroIdentificacion = 98765,
                Genero = "Masculino",
                FechaNacimiento = new DateTime(1988, 7, 8),
                CorreoElectronico = "pedro.martinez@email.com",
                RelacionConEstudiante = "Padre",
                EstadoCivil = "Casado",
                Ocupacion = "Profesor",
                Estado = true,
                FechaRegistro = DateTime.Now
            },

            new Acudiente
            {
                AcudienteId = Guid.NewGuid(),
                Nombres = "Luis",
                Apellidos = "Sánchez",
                NumeroIdentificacion = 13579,
                Genero = "Masculino",
                FechaNacimiento = new DateTime(1972, 12, 20),
                CorreoElectronico = "luis.sanchez@email.com",
                RelacionConEstudiante = "Padre",
                EstadoCivil = "Casado",
                Ocupacion = "Contador",
                Estado = true,
                FechaRegistro = DateTime.Now
            },
             new Acudiente
            {
                 AcudienteId = Guid.NewGuid(),
                 Nombres = "Carlos",
                Apellidos = "Rodríguez",
                NumeroIdentificacion = 24680,
                Genero = "Masculino",
                FechaNacimiento = new DateTime(1985, 9, 12),
                CorreoElectronico = "carlos.rodriguez@email.com",
                RelacionConEstudiante = "Tío",
                EstadoCivil = "Soltero",
                Ocupacion = "Ingeniero Civil",
                Estado = true,
                FechaRegistro = DateTime.Now
            },

            new Acudiente
            {
                AcudienteId = Guid.NewGuid(),
                Nombres = "Laura",
                Apellidos = "Gómez",
                NumeroIdentificacion = 86420,
                Genero = "Femenino",
                FechaNacimiento = new DateTime(1992, 6, 30),
                CorreoElectronico = "laura.gomez@email.com",
                RelacionConEstudiante = "Madre",
                EstadoCivil = "Divorciada",
                Ocupacion = "Médica",
                Estado = true,
                FechaRegistro = DateTime.Now
            },

            new Acudiente
            {
                AcudienteId = Guid.NewGuid(),
                Nombres = "Andrés",
                Apellidos = "Hernández",
                NumeroIdentificacion = 97531,
                Genero = "Masculino",
                FechaNacimiento = new DateTime(1979, 11, 5),
                CorreoElectronico = "andres.hernandez@email.com",
                RelacionConEstudiante = "Padrino",
                EstadoCivil = "Casado",
                Ocupacion = "Arquitecto",
                Estado = true,
                FechaRegistro = DateTime.Now
            },

            new Acudiente
            {
                AcudienteId = Guid.NewGuid(),
                Nombres = "Sofía",
                Apellidos = "Díaz",
                NumeroIdentificacion = 75319,
                Genero = "Femenino",
                FechaNacimiento = new DateTime(1987, 4, 18),
                CorreoElectronico = "sofia.diaz@email.com",
                RelacionConEstudiante = "Tía",
                EstadoCivil = "Soltera",
                Ocupacion = "Profesora",
                Estado = true,
                FechaRegistro = DateTime.Now
            },

            new Acudiente
            {
                AcudienteId = Guid.NewGuid(),
                Nombres = "Roberto",
                Apellidos = "Luna",
                NumeroIdentificacion = 10293,
                Genero = "Masculino",
                FechaNacimiento = new DateTime(1970, 1, 8),
                CorreoElectronico = "roberto.luna@email.com",
                RelacionConEstudiante = "Abuelo",
                EstadoCivil = "Viudo",
                Ocupacion = "Jubilado",
                Estado = true,
                FechaRegistro = DateTime.Now
            }

        );
    }
  }
}
