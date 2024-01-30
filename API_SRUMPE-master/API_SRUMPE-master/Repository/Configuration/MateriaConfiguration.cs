using Entities.Models.D_DepartamentoAcademico;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Repository.Configuration;
public class MateriaConfiguration : IEntityTypeConfiguration<Materias>
{
    public void Configure(EntityTypeBuilder<Materias> builder)
    {
        builder.HasData(
            new Materias
            {
                MateriaId = Guid.NewGuid(),
                Nombre = "Matemáticas",
                Descripcion = "Curso de Matemáticas Avanzadas",
                DepartamentoAcademico = "Departamento de Matemáticas",
                Nivel = "Avanzado",
                ProfesorAsignado = "Profesor Matemático",
                ModalidadEnsenanza = "Presencial",
                Estado = "En progreso",
                NotasAdicionales = "Se requiere calculadora científica.",
                GrupoSeccionMateria = "Grupo A",
                MetodosEnsenanza = "Clases teóricas y prácticas"
            },
            new Materias
            {
                MateriaId = Guid.NewGuid(),
                Nombre = "Historia",
                Descripcion = "Curso de Historia Mundial",
                DepartamentoAcademico = "Departamento de Historia",
                Nivel = "Intermedio",
                ProfesorAsignado = "Profesor Historiador",
                ModalidadEnsenanza = "Presencial",
                Estado = "Inscripciones abiertas",
                NotasAdicionales = "Recomendado para estudiantes de Historia.",
                GrupoSeccionMateria = "Grupo B",
                MetodosEnsenanza = "Conferencias y debates"
            },
            new Materias
            {
                MateriaId = Guid.NewGuid(),
                Nombre = "Ciencias de la Computación",
                Descripcion = "Curso de Ciencias de la Computación",
                DepartamentoAcademico = "Departamento de Informática",
                Nivel = "Avanzado",
                ProfesorAsignado = "Profesor de Informática",
                ModalidadEnsenanza = "En línea",
                Estado = "En progreso",
                NotasAdicionales = "Requiere acceso a una computadora.",
                GrupoSeccionMateria = "Grupo C",
                MetodosEnsenanza = "Clases virtuales y proyectos prácticos"
            },
            new Materias
            {
                MateriaId = Guid.NewGuid(),
                Nombre = "Literatura",
                Descripcion = "Curso de Literatura Universal",
                DepartamentoAcademico = "Departamento de Literatura",
                Nivel = "Intermedio",
                ProfesorAsignado = "Profesor Literario",
                ModalidadEnsenanza = "Presencial",
                Estado = "Inscripciones abiertas",
                NotasAdicionales = "Apto para amantes de la lectura.",
                GrupoSeccionMateria = "Grupo D",
                MetodosEnsenanza = "Lecturas y discusiones literarias"
            },
            new Materias
            {
                MateriaId = Guid.NewGuid(),
                Nombre = "Física",
                Descripcion = "Curso de Física Avanzada",
                DepartamentoAcademico = "Departamento de Física",
                Nivel = "Avanzado",
                ProfesorAsignado = "Profesor de Física",
                ModalidadEnsenanza = "Presencial",
                Estado = "Completo",
                NotasAdicionales = "Requiere conocimientos previos de física.",
                GrupoSeccionMateria = "Grupo E",
                MetodosEnsenanza = "Experimentos y clases teóricas"
            },
            new Materias
            {
                MateriaId = Guid.NewGuid(),
                Nombre = "Economía",
                Descripcion = "Curso de Economía Moderna",
                DepartamentoAcademico = "Departamento de Economía",
                Nivel = "Intermedio",
                ProfesorAsignado = "Profesor Economista",
                ModalidadEnsenanza = "En línea",
                Estado = "En progreso",
                NotasAdicionales = "Abordaremos temas financieros actuales.",
                GrupoSeccionMateria = "Grupo F",
                MetodosEnsenanza = "Clases virtuales y análisis económico"
            },
            new Materias
            {
                MateriaId = Guid.NewGuid(),
                Nombre = "Arte",
                Descripcion = "Curso de Arte Contemporáneo",
                DepartamentoAcademico = "Departamento de Arte",
                Nivel = "Intermedio",
                ProfesorAsignado = "Profesor de Arte",
                ModalidadEnsenanza = "Presencial",
                Estado = "Inscripciones abiertas",
                NotasAdicionales = "No se requiere experiencia previa en arte.",
                GrupoSeccionMateria = "Grupo G",
                MetodosEnsenanza = "Prácticas artísticas y exposiciones"
            }
        );
    }
}