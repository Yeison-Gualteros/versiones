using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Entities.Models.D_DepartamentoAcademico;

namespace Repository.Configuration;

public class EdicionCursoConfiguration : IEntityTypeConfiguration<EdicionCurso>
{
    public void Configure(EntityTypeBuilder<EdicionCurso> builder)
    {
        builder.HasData(
            new EdicionCurso
            {
                EdicionCursoId = 1,
                FechaInicio = new DateTime(2023, 10, 1),
                FechaFinalizacion = new DateTime(2023, 11, 15),
                CupoMaximo = 30,
                CupoActual = 25,
                Estado = "En progreso",
                Descripcion = "Curso de Programación Avanzada",
                Modalidad = "Presencial"
            },
            new EdicionCurso
            {
                EdicionCursoId = 2,
                FechaInicio = new DateTime(2023, 9, 20),
                FechaFinalizacion = new DateTime(2023, 12, 10),
                CupoMaximo = 50,
                CupoActual = 48,
                Estado = "Inscripciones abiertas",
                Descripcion = "Curso de Diseño Gráfico",
                Modalidad = "En línea"
            },
            new EdicionCurso
            {
                EdicionCursoId = 3,
                FechaInicio = new DateTime(2023, 11, 5),
                FechaFinalizacion = new DateTime(2023, 11, 30),
                CupoMaximo = 20,
                CupoActual = 20,
                Estado = "Completo",
                Descripcion = "Curso de Marketing Digital",
                Modalidad = "Presencial"
            },
            new EdicionCurso
            {
                EdicionCursoId = 4,
                FechaInicio = new DateTime(2023, 10, 15),
                FechaFinalizacion = new DateTime(2023, 11, 30),
                CupoMaximo = 40,
                CupoActual = 38,
                Estado = "Inscripciones abiertas",
                Descripcion = "Curso de Desarrollo Web",
                Modalidad = "En línea"
            },
            new EdicionCurso
            {
                EdicionCursoId = 5,
                FechaInicio = new DateTime(2023, 9, 25),
                FechaFinalizacion = new DateTime(2023, 10, 30),
                CupoMaximo = 15,
                CupoActual = 12,
                Estado = "En progreso",
                Descripcion = "Curso de Inglés Avanzado",
                Modalidad = "Presencial"
            }
        );
    }
}

