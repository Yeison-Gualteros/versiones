namespace Entities.Models
{
    public partial class PreMatricula
    {
        public Guid PreMatriculaId { get; set; }
       //public Guid CandidatoEstudianteId { get; set; }
        public string GradoONivel { get; set; }
        public string Turno { get; set; }
        public string Observaciones { get; set; }
        public string EstadoPreMatricula { get; set; }
        public string RequisitosDocumentacion { get; set; }
    }
}