using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.D_DepartamentoAcademico
{
    public partial class Materias
    {
        [Key]
        public Guid MateriaId { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public string? DepartamentoAcademico { get; set; }
        public string? Nivel { get; set; }
        public string? ProfesorAsignado { get; set; }
        public string? ModalidadEnsenanza { get; set; }
        public string? Estado { get; set; }
        public string? NotasAdicionales { get; set; }
        public string? GrupoSeccionMateria { get; set; }
        public string? MetodosEnsenanza { get; set; }

    }
}
