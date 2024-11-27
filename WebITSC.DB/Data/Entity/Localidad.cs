using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebITSC.DB.Data.Entity
{
    public class Localidad: EntityBase
    {
        [Required(ErrorMessage = "El nombre de la localidad es necesario")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El departamento de la localidad es necesario")]
        public int DepartamentoId { get; set; }
        public Departamento Departamento { get; set; }

    }
}
