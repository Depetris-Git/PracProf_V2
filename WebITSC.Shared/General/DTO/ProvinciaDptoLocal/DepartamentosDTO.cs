using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebITSC.Shared.General.DTO.ProvinciaDptoLocal
{
    public class CrearDepartamentosDTO
    {
        [Required(ErrorMessage = "El nombre del departamento es necesario")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La provincia del departamento es necesaria")]
        public int ProvinciaId { get; set; }
    }
    public class GetDepartamentosDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del departamento es necesario")]
        public string Nombre { get; set; }

        
    }
}
