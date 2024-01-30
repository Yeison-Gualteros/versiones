using Entities.Models;
using Entities.Models.D_Estudiante;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration;

public class PreMatriculaConfiguration : IEntityTypeConfiguration<PreMatricula>
{
    public void Configure(EntityTypeBuilder<PreMatricula> builder)
    {
        builder.HasData
        (
            new PreMatricula
            {
                PreMatriculaId = Guid.NewGuid(),
                GradoONivel = "Quinto de Primaria",
                Turno = "Mañana",
                Observaciones = "Estudiante con requerimientos especiales.",
                EstadoPreMatricula = "Pendiente",
                RequisitosDocumentacion = "NoCumplio"
            },
            
            new PreMatricula
            {
                PreMatriculaId = Guid.NewGuid(),
                GradoONivel = "Séptimo de Secundaria",
                Turno = "Tarde",
                Observaciones = "Estudiante de transferencia.",
                EstadoPreMatricula = "Activa",
                RequisitosDocumentacion = "SiCumplio"
            },
            
            new PreMatricula
            {
                PreMatriculaId = Guid.NewGuid(),
                GradoONivel = "Tercero de Primaria",
                Turno = "Mañana",
                Observaciones = "Estudiante extranjero.",
                EstadoPreMatricula = "Pendiente",
                RequisitosDocumentacion = "SiCumplio"
            },
            
            new PreMatricula
            {
                PreMatriculaId = Guid.NewGuid(),
                GradoONivel = "Cuarto de Secundaria",
                Turno = "Tarde",
                Observaciones = "Estudiante con beca deportiva.",
                EstadoPreMatricula = "Activa",
                RequisitosDocumentacion = "SiCumplio"
            },
            
            new PreMatricula
            {
                PreMatriculaId = Guid.NewGuid(),
                GradoONivel = "Segundo de Primaria",
                Turno = "Mañana",
                Observaciones = "Estudiante con discapacidad visual.",
                EstadoPreMatricula = "Activa",
                RequisitosDocumentacion = "SiCumplio"
            
            },
            
            new PreMatricula
        
            {
                PreMatriculaId = Guid.NewGuid(),
                GradoONivel = "Octavo de Secundaria",
                Turno = "Tarde",
                Observaciones = "Estudiante sin observaciones adicionales.",
                EstadoPreMatricula = "Pendiente",
                RequisitosDocumentacion = "Si cumplio"

            }
        );
    }
}
