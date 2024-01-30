using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models.D_Acudiente;

namespace Repository.Configuration
{
    internal class DireccionAcudienteConfiguration : IEntityTypeConfiguration<DireccionAcudiente>
    {
        public void Configure(EntityTypeBuilder<DireccionAcudiente> builder)
        {
            builder.HasData
            (
                new DireccionAcudiente
                {
                    DireccionAcudienteId = Guid.NewGuid(),
                    Calle = "Calle 72",
                    ColoniaBarrio = "Chapinero",
                    CiudadLocalidad = "Bogotá",
                    CodigoPostal = "110231",
                    EstadoProvincia = "Bogotá D.C.",
                    Pais = "Colombia"
                },
                new DireccionAcudiente
                {
                    DireccionAcudienteId = Guid.NewGuid(),
                    Calle = "Calle 72",
                    ColoniaBarrio = "Chapinero",
                    CiudadLocalidad = "Bogotá",
                    CodigoPostal = "110231",
                    EstadoProvincia = "Bogotá D.C.",
                    Pais = "Colombia"
                },
                new DireccionAcudiente
                {
                    DireccionAcudienteId = Guid.NewGuid(),
                    Calle = "Carrera 10",
                    ColoniaBarrio = "La Candelaria",
                    CiudadLocalidad = "Bogotá",
                    CodigoPostal = "110321",
                    EstadoProvincia = "Bogotá D.C.",
                    Pais = "Colombia"
                },

                new DireccionAcudiente
                {
                    DireccionAcudienteId = Guid.NewGuid(),
                    Calle = "Avenida Boyacá",
                    ColoniaBarrio = "Fontibón",
                    CiudadLocalidad = "Bogotá",
                    CodigoPostal = "110511",
                    EstadoProvincia = "Bogotá D.C.",
                    Pais = "Colombia"
                },

                new DireccionAcudiente
                {
                    DireccionAcudienteId = Guid.NewGuid(),
                    Calle = "Calle 80",
                    ColoniaBarrio = "Engativá",
                    CiudadLocalidad = "Bogotá",
                    CodigoPostal = "110841",
                    EstadoProvincia = "Bogotá D.C.",
                    Pais = "Colombia"
                },

                new DireccionAcudiente
                {
                    DireccionAcudienteId = Guid.NewGuid(),
                    Calle = "Carrera 7",
                    ColoniaBarrio = "Usaquén",
                    CiudadLocalidad = "Bogotá",
                    CodigoPostal = "110171",
                    EstadoProvincia = "Bogotá D.C.",
                    Pais = "Colombia"
                },

                new DireccionAcudiente
                {
                    DireccionAcudienteId = Guid.NewGuid(),
                    Calle = "Avenida 68",
                    ColoniaBarrio = "Kennedy",
                    CiudadLocalidad = "Bogotá",
                    CodigoPostal = "110841",
                    EstadoProvincia = "Bogotá D.C.",
                    Pais = "Colombia"
                }
            );
        }
    }
}