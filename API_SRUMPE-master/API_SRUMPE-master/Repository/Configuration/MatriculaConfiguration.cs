using Entities.Models;
using Entities.Models.D_Estudiante;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration;

public class MatriculaConfiguration : IEntityTypeConfiguration<Matricula>
{
    public void Configure(EntityTypeBuilder<Matricula> builder)
    {
        builder.HasData
        (
            new Matricula
                {
            
                MatriculaId = Guid.NewGuid(),
                FechaMatricula = DateTime.Now,
                EstadoMatricula = "Activa",
                TipoMatricula = "Matrícula Regular",
                PeriodoAcademico = DateTime.Now.Year,
                Comentarios = "Comentario sobre la matrícula 1",
                CategoriaMatricula = "Estudiante de Tiempo Completo",
                InformacionPlanEstudios = "Plan de estudios 2023",
                RegistroCambios = "Registro de cambios 1"
                },

            new Matricula
            {
                MatriculaId = Guid.NewGuid(),
                FechaMatricula = DateTime.Now.AddMonths(1),
                EstadoMatricula = "Pendiente",
                TipoMatricula = "Matrícula Parcial",
                PeriodoAcademico = DateTime.Now.Year,
                Comentarios = "Comentario sobre la matrícula 2",
                CategoriaMatricula = "Estudiante de Tiempo Parcial",
                InformacionPlanEstudios = "Plan de estudios 2023",
                RegistroCambios = "Registro de cambios 2"
            },
        
            new Matricula
            {
                MatriculaId = Guid.NewGuid(),
                FechaMatricula = DateTime.Now.AddMonths(2),
                EstadoMatricula = "Cancelada",
                TipoMatricula = "Matrícula Regular",
                PeriodoAcademico = DateTime.Now.Year,
                Comentarios = "Comentario sobre la matrícula 3",
                CategoriaMatricula = "Estudiante Internacional",
                InformacionPlanEstudios = "Plan de estudios 2023",
                RegistroCambios = "Registro de cambios 3"
            },
        
            new Matricula
            {
                MatriculaId = Guid.NewGuid(),
                FechaMatricula = DateTime.Now.AddMonths(3),
                EstadoMatricula = "Activa",
                TipoMatricula = "Matrícula Regular",
                PeriodoAcademico = DateTime.Now.Year,
                Comentarios = "Comentario sobre la matrícula 4",
                CategoriaMatricula = "Estudiante de Tiempo Completo",
                InformacionPlanEstudios = "Plan de estudios 2023",
                RegistroCambios = "Registro de cambios 4"
            },
        
        
            new Matricula
            {
                MatriculaId = Guid.NewGuid(),
                FechaMatricula = DateTime.Now.AddMonths(4),
                EstadoMatricula = "Activa",
                TipoMatricula = "Matrícula Regular",
                PeriodoAcademico = DateTime.Now.Year,
                Comentarios = "Comentario sobre la matrícula 5",
                CategoriaMatricula = "Estudiante de Tiempo Completo",
                InformacionPlanEstudios = "Plan de estudios 2023",
                RegistroCambios = "Registro de cambios 5"
            }
        );
    }
}