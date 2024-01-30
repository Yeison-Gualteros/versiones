using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.D_Estudiante
{
    public partial class EstudianteDocumentos

    {

        [Key]
        public Guid EstudianteDocumentosId { get; set; }
        public string? NombreDocumento { get; set; }
        public string? TipoDocumento { get; set; }
        public int NumeroDocumento { get; set; }
        public bool Estado { get; set; }
        public string? Observaciones { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public string? Ubicacion { get; set; }
        public int Tamaño { get; set; }

        //Llave
        public Guid CandidatoEstudianteId { get; set; }

    }

}
