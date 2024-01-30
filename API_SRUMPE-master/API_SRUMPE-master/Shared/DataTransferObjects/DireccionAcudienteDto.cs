using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects
{
    public record DireccionAcudienteDto
    {
        public Guid DireccionAcudienteId { get; init; }

        public string Calle { get; init; }

        public string ColoniaBarrio { get; init; }

        public string CiudadLocalidad { get; init; }

        public string CodigoPostal { get; init; }

        public string EstadoProvincia { get; init; }

        public string Pais { get; init; }
    }
}
