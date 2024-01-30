using Entities.Models.D_DepartamentoAcademico;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Repository.Configuration;

public class AulaConfiguration : IEntityTypeConfiguration<Aulas>
{
    public void Configure(EntityTypeBuilder<Aulas> builder)
    {
        builder.HasData(
            new Aulas
            {
                AulaId = Guid.NewGuid(),
                NombreNumero = "Aula 101",
                Ubicacion = "Edificio Principal",
                Capacidad = 50,
                TipoAula = "Salón de Clases",
                EstadoAula = "Disponible",
                HorarioDisponibilidad = "Lunes a Viernes, 08:00 AM - 06:00 PM",
                NotasAdicionales = "Equipada con proyector",
                UltimaActualizacion = new DateTime(2023, 09, 15),
                ResponsableAula = "Profesor Responsable 1",
                RegistrosIncidentesProblemas = "Ninguno"
            },
            new Aulas
            {
                AulaId = Guid.NewGuid(),
                NombreNumero = "Aula 102",
                Ubicacion = "Edificio de Ciencias",
                Capacidad = 30,
                TipoAula = "Laboratorio de Informática",
                EstadoAula = "Ocupado",
                HorarioDisponibilidad = "Lunes a Viernes, 10:00 AM - 05:00 PM",
                NotasAdicionales = "Equipado con computadoras de última generación",
                UltimaActualizacion = new DateTime(2023, 09, 10),
                ResponsableAula = "Profesor Responsable 2",
                RegistrosIncidentesProblemas = "Reporte de fallo en una computadora"
            },
            new Aulas
            {
                AulaId = Guid.NewGuid(),
                NombreNumero = "Aula 103",
                Ubicacion = "Edificio de Eventos",
                Capacidad = 100,
                TipoAula = "Sala de Conferencias",
                EstadoAula = "Disponible",
                HorarioDisponibilidad = "Disponible previa reserva",
                NotasAdicionales = "Equipada con proyector y sistema de sonido",
                UltimaActualizacion = new DateTime(2023, 09, 20),
                ResponsableAula = "Personal de Eventos",
                RegistrosIncidentesProblemas = "Ninguno"
            },
            new Aulas
            {
                AulaId = Guid.NewGuid(),
                NombreNumero = "Aula 104",
                Ubicacion = "Edificio Principal",
                Capacidad = 40,
                TipoAula = "Salón de Clases",
                EstadoAula = "En Mantenimiento",
                HorarioDisponibilidad = "No disponible temporalmente",
                NotasAdicionales = "Mantenimiento programado",
                UltimaActualizacion = new DateTime(2023, 09, 25),
                ResponsableAula = "Personal de Mantenimiento",
                RegistrosIncidentesProblemas = "Reporte de fugas de agua en el techo"
            },
            new Aulas
            {
                AulaId = Guid.NewGuid(),
                NombreNumero = "Aula 105",
                Ubicacion = "Biblioteca",
                Capacidad = 10,
                TipoAula = "Sala de Estudio",
                EstadoAula = "Disponible",
                HorarioDisponibilidad = "Lunes a Domingo, 09:00 AM - 11:00 PM",
                NotasAdicionales = "Área de estudio tranquila",
                UltimaActualizacion = new DateTime(2023, 09, 18),
                ResponsableAula = "Bibliotecario",
                RegistrosIncidentesProblemas = "Ninguno"
            }
        );
    }
}