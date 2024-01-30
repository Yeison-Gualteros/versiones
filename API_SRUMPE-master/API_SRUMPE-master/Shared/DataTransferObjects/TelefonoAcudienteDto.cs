namespace Shared.DataTransferObjects
{
    public record TelefonoAcudienteDto
    {
        public Guid TelefonoAcudienteId { get; set; }
        public int? Numero { get; set; }
        public string? Tipo { get; set; }
        public string? Indicativo { get; set; }
    }
}
