using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebITSC.Admin.Server.Repositorio;
using WebITSC.DB.Data.Entity;
using WebITSC.DB.Data;
using Microsoft.EntityFrameworkCore;

namespace Repositorio.General.Repos_Genericos.Residencia
{
    public class DepartamentoRepositorio : Repositorio<Departamento>, IDepartamentoRepositorio
    {
        private readonly Context _context;

        public DepartamentoRepositorio(Context context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Departamento>> SelectDepartamentosPorProvinciaAsync(int ProvinciaId)
        {
            return await _context.Departamentos
                                 .Where(d => d.ProvinciaId == ProvinciaId)
                                 .ToListAsync();
        }
      
    }
}
