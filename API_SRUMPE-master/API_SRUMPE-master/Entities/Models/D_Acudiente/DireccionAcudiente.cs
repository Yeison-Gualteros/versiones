using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.D_Acudiente;

public partial class DireccionAcudiente
{
    [Key]
    public Guid DireccionAcudienteId { get; set; }
    //public Guid AcudienteId { get; set; } 
    public string Calle { get; set; } 
    public string ColoniaBarrio { get; set; }
    public string CiudadLocalidad { get; set; } 
    public string CodigoPostal { get; set; } 
    public string EstadoProvincia { get; set; }
    public string Pais { get; set; } 
}
