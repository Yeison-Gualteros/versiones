using System.ComponentModel.DataAnnotations;

namespace Entities.Models.D_Notas;
public partial class Estadisticas
{
    [Key]
    public int EstadisticaId { get; set; }
    public string Materia { get; set; }
    public decimal NotaPromedio { get; set; }
    public decimal NotaMaxima { get; set; }
    public decimal NotaMinima { get; set; }
    public int CantidadExamenes { get; set; }
    public DateTime FechaRegistro { get; set; }
    public int AñoEscolar { get; set; }
    public string PeriodoEscolar { get; set; }
}

