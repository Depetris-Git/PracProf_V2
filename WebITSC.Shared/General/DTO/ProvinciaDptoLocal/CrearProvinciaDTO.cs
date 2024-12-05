using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebITSC.Shared.General.DTO.ProvinciaDptoLocal
{
    public class CrearProvinciaDTO
    {
        public string Nombre { get; set; }
        public int PaisId { get; set; }
    }
    public class GetProvinciaDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}
