using Entities.Models;
using Entities.Models.D_Acudiente;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration;
public class TelefonoAcudienteConfiguration : IEntityTypeConfiguration<TelefonoAcudiente>
{
    public void Configure(EntityTypeBuilder<TelefonoAcudiente> builder)
    {
        builder.HasData
        (
            new TelefonoAcudiente
            {
                TelefonoAcudienteId = Guid.NewGuid(),
                Numero = 555-123-4567,
                Tipo = "Móvil",
                Indicativo = "+1",
                AcudienteId = 1
            },
            new TelefonoAcudiente
            {
                TelefonoAcudienteId = Guid.NewGuid(),
                Numero = 555-987-6543,
                Tipo = "Móvil",
                Indicativo = "+1",
                AcudienteId = 2
            },
            new TelefonoAcudiente
            {
                TelefonoAcudienteId = Guid.NewGuid(),
                Numero = 555-234-5678,
                Tipo = "Fijo",
                Indicativo = "+1",
                AcudienteId = 3
            },
            new TelefonoAcudiente
            {
                TelefonoAcudienteId = Guid.NewGuid(),
                Numero = 555-876-5432,
                Tipo = "Móvil",
                Indicativo = "+1",
                AcudienteId = 4
            },
            new TelefonoAcudiente
            {
                TelefonoAcudienteId = Guid.NewGuid(),
                Numero = 911,
                Tipo = "Emergencia",
                Indicativo = "+1",
                AcudienteId = 5
            },
            new TelefonoAcudiente
            {
                TelefonoAcudienteId = Guid.NewGuid(),
                Numero =555-111-1111,
                Tipo = "Móvil",
                Indicativo = "+1",
                AcudienteId = 1
            },
            new TelefonoAcudiente
            {
                TelefonoAcudienteId = Guid.NewGuid(),
                Numero = 555-222-2222,
                Tipo = "Móvil",
                Indicativo = "+1",
                AcudienteId = 2
            },
            new TelefonoAcudiente
            {
                TelefonoAcudienteId = Guid.NewGuid(),
                Numero = 555-333-3333,
                Tipo = "Fijo",
                Indicativo = "+1",
                AcudienteId = 3
            },
            new TelefonoAcudiente
            {
                TelefonoAcudienteId = Guid.NewGuid(),
                Numero = 555-444-4444,
                Tipo = "Móvil",
                Indicativo = "+1",
                AcudienteId = 4
            },
            new TelefonoAcudiente
            {
                TelefonoAcudienteId = Guid.NewGuid(),
                Numero = 555-555-5555,
                Tipo = "Emergencia",
                Indicativo = "+1",
                AcudienteId = 5
            }
        );
    }
}