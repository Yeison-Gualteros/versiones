namespace Shared.DataTransferObjects;
public record EstudianteDocumentosDto
{
    public Guid EstudianteDocumentosId { get; set; }
    public string NombreDocumento { get; set; }
    public string TipoDocumento { get; set; }
    public int NumeroDocumento { get; set; }
    public bool Estado { get; set; }
    public string Observaciones { get; set; }
    public DateTime? FechaActualizacion { get; set; }
    public string Ubicacion { get; set; }
    public int Tamaño { get; set; }

}
        
