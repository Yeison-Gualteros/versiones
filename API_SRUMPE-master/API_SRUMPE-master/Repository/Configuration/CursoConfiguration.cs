using Entities.Models.D_DepartamentoAcademico;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Repository.Configuration;

public class CursoConfiguration : IEntityTypeConfiguration<Cursos>
{
    public void Configure(EntityTypeBuilder<Cursos> builder)
    {
        builder.HasData(
            new Cursos
            {
                CursoId = Guid.NewGuid(),
                Curso = 101,
                Codigo = "CS101",
                Descripcion = "Introducción a la Programación",
                DepartamentoAcademico = "Ciencias de la Computación",
                Nivel = "Primer Semestre",
                ProfesorAsignado = "Profesor 1",
                AulasAsignadas = "Aula 101, Aula 102",
                FechaLimiteInscripcion = new DateTime(2023, 09, 30),
                MetodosEnsenanza = "Clases magistrales, laboratorios prácticos"
            },
            new Cursos
            {
                CursoId = Guid.NewGuid(),
                Curso = 201,
                Codigo = "ENG201",
                Descripcion = "Advanced English Composition",
                DepartamentoAcademico = "English Department",
                Nivel = "Second Semester",
                ProfesorAsignado = "Professor 2",
                AulasAsignadas = "Classroom 201, Classroom 202",
                FechaLimiteInscripcion = new DateTime(2023, 10, 10),
                MetodosEnsenanza = "Lectures, writing assignments, group discussions"
            },
            new Cursos
            {
                CursoId = Guid.NewGuid(),
                Curso = 301,
                Codigo = "MATH301",
                Descripcion = "Advanced Calculus",
                DepartamentoAcademico = "Mathematics Department",
                Nivel = "Third Semester",
                ProfesorAsignado = "Professor 3",
                AulasAsignadas = "Math Classroom 301",
                FechaLimiteInscripcion = new DateTime(2023, 09, 25),
                MetodosEnsenanza = "Lectures, problem sets, exams"
            },
            new Cursos
            {
                CursoId = Guid.NewGuid(),
                Curso = 401,
                Codigo = "CHEM401",
                Descripcion = "Organic Chemistry",
                DepartamentoAcademico = "Chemistry Department",
                Nivel = "Second Semester",
                ProfesorAsignado = "Professor 4",
                AulasAsignadas = "Chemistry Lab 201",
                FechaLimiteInscripcion = new DateTime(2023, 10, 5),
                MetodosEnsenanza = "Lectures, laboratory experiments"
            },
            new Cursos
            {
                CursoId = Guid.NewGuid(),
                Curso = 501,
                Codigo = "HIST501",
                Descripcion = "Introduction to History",
                DepartamentoAcademico = "History Department",
                Nivel = "First Semester",
                ProfesorAsignado = "Professor 5",
                AulasAsignadas = "History Classroom 101",
                FechaLimiteInscripcion = new DateTime(2023, 09, 20),
                MetodosEnsenanza = "Lectures, discussions, research papers"
            }
        );
    }
}


