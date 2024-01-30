using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.D_DepartamentoAcademico
{
    public partial class Horarios
    {
        [Key]
        public Guid HorarioId { get; set; }

       // public int IdMateria { get; set; }
       //public int IdAula { get; set; }
       //public int IdProfesor { get; set; }
        public string DiaSemana { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
        public string PeriodoAcademico { get; set; }
        public string GrupoSeccion { get; set; }
        public DateTime FechaInicioClases { get; set; }
        public DateTime FechaFinClases { get; set; }
        public string EstadoHorario { get; set; }
        public int DuracionClaseMinutos { get; set; }
        public string SalaAula { get; set; }
        public string ProfesorAsistente { get; set; }
        public string NotificacionCambioHorario{ get; set;}

    }
}
