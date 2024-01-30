using Entities.Models.D_Notas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration;

internal class EstadisticaConfiguration : IEntityTypeConfiguration<Estadisticas>
{
    public void Configure(EntityTypeBuilder<Estadisticas> builder)

    {
        builder.HasData(
             new Estadisticas
             {
                 EstadisticaId = 1,
                 Materia = "Matemáticas",
                 NotaPromedio = 8.5M,
                 NotaMaxima = 9.0M,
                 NotaMinima = 7.5M,
                 CantidadExamenes = 5,
                 FechaRegistro = DateTime.Now,
                 AñoEscolar = 2023,
                 PeriodoEscolar = "Primer Trimestre"
             },
    new Estadisticas
    {
        EstadisticaId = 2,
        Materia = "Ciencias",
        NotaPromedio = 7.8M,
        NotaMaxima = 8.5M,
        NotaMinima = 6.5M,
        CantidadExamenes = 4,
        FechaRegistro = DateTime.Now,
        AñoEscolar = 2023,
        PeriodoEscolar = "Segundo Trimestre"
    },
    new Estadisticas
    {
        EstadisticaId = 3,
        Materia = "Historia",
        NotaPromedio = 9.2M,
        NotaMaxima = 9.5M,
        NotaMinima = 8.5M,
        CantidadExamenes = 3,
        FechaRegistro = DateTime.Now,
        AñoEscolar = 2023,
        PeriodoEscolar = "Tercer Trimestre"
    },
    new Estadisticas
    {
        EstadisticaId = 4,
        Materia = "Lenguaje",
        NotaPromedio = 7.2M,
        NotaMaxima = 8.0M,
        NotaMinima = 6.0M,
        CantidadExamenes = 5,
        FechaRegistro = DateTime.Now,
        AñoEscolar = 2023,
        PeriodoEscolar = "Primer Semestre"
    },
    new Estadisticas
    {
        EstadisticaId = 5,
        Materia = "Arte",
        NotaPromedio = 8.7M,
        NotaMaxima = 9.0M,
        NotaMinima = 8.0M,
        CantidadExamenes = 2,
        FechaRegistro = DateTime.Now,
        AñoEscolar = 2023,
        PeriodoEscolar = "Segundo Semestre"
    },
    new Estadisticas
    {
        EstadisticaId = 6,
        Materia = "Educación Física",
        NotaPromedio = 9.5M,
        NotaMaxima = 10.0M,
        NotaMinima = 9.0M,
        CantidadExamenes = 3,
        FechaRegistro = DateTime.Now,
        AñoEscolar = 2023,
        PeriodoEscolar = "Trimestre Extra"
    }

        );
    }
}
