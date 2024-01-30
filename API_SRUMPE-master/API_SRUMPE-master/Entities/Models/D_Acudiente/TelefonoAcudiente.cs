namespace Entities.Models.D_Acudiente;

public partial class TelefonoAcudiente
{
    public Guid TelefonoAcudienteId { get; set; }

    public int Numero { get; set; }

    public string? Tipo { get; set; }
    public string Indicativo { get; set; } = null!;

    // Foreign Key
    public int? AcudienteId { get; set; }
}
