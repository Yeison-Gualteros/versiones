namespace Entities.Models
{
    public partial class RespuestaCupo
    {
        public Guid RespuestaCupoId { get; set; }
        public DateTime FechaRespuesta { get; set; }
        public string EstadoRespuesta { get; set; }
        public string MensajeRespuesta { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public string UsuarioRespuesta { get; set; }
        public string TipoRespuesta { get; set; }
        public TimeSpan DuracionRespuesta { get; set; }
        public string Prioridad { get; set; }
    }
}