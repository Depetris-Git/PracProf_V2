using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebITSC.Shared.General.DTO.PaisesDTO
{
    public class CrearPaisDTO
    {
        [Required(ErrorMessage = "El nombre del pais es necesario")]
        public string Nombre { get; set; }

    }

    public class GetPaisDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre del pais es necesario")]
        public string Nombre { get; set; }
    }
}
