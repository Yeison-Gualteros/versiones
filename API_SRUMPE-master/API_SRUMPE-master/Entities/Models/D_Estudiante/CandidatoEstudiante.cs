using System.ComponentModel.DataAnnotations;

namespace Entities.Models.D_Estudiante;

public partial class CandidatoEstudiante

{
    [Key]
    public Guid CandidatoEstudianteId { get; set; }

    [Required(ErrorMessage = "CandidatoEstudiante name is a required field.")]
    [MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters.")]
    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public DateTime? FechaNacimiento { get; set; }

    public string? TipoPersona { get; set; }

    //public int? EdicionCursoId { get; set; }

    //public virtual ICollection<AcudienteEstudiante1> AcudienteEstudiante1s { get; set; } = new List<AcudienteEstudiante1>();

    //public virtual ICollection<Cupo> Cupos { get; set; } = new List<Cupo>();

    //public virtual ICollection<DireccionResidencium1> DireccionResidencium1s { get; set; } = new List<DireccionResidencium1>();

    //public virtual EdicionCurso1? EdicionCurso { get; set; }

    //public virtual ICollection<EstudianteDocumento> EstudianteDocumentos { get; set; } = new List<EstudianteDocumento>();

    //public virtual ICollection<TelefonoEstudiante1> TelefonoEstudiante1s { get; set; } = new List<TelefonoEstudiante1>();


}
