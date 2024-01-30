using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.D_DepartamentoAcademico
{
    public partial class EdicionCurso
    {
        public int EdicionCursoId { get; set; }
        
        //public int IdCurso { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinalizacion { get; set; }
        public int CupoMaximo { get; set; }
        public int CupoActual { get; set; }
        public string Estado { get; set; }
        public string Descripcion { get; set; }
        public string Modalidad { get; set; }
    }
}
