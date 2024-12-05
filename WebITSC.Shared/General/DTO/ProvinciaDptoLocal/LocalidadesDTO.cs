using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebITSC.Shared.General.DTO.ProvinciaDptoLocal
{
    public class CrearLocalidadesDTO
    {
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El departamento de la localidad es necesario")]
        public int DepartamentoId { get; set; }
    }
    public class GetLocalidadesDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

    }
}
