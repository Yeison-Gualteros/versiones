using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.D_DepartamentoAcademico
{
    public partial class Aulas
    {
        [Key]
        public Guid AulaId { get; set; }
        public string NombreNumero { get; set; }
        public string Ubicacion { get; set; }
        public int Capacidad { get; set; }
        public string TipoAula { get; set; }
        public string EstadoAula { get; set; }
        public string HorarioDisponibilidad { get; set; }
        public string NotasAdicionales { get; set; }
        public DateTime UltimaActualizacion { get; set; }
        public string ResponsableAula { get; set; }
        public string RegistrosIncidentesProblemas { get; set; }

    }
}
