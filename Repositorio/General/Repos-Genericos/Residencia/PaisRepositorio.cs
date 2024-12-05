using WebITSC.Admin.Server.Repositorio;
using WebITSC.DB.Data.Entity;
using WebITSC.DB.Data;
using Microsoft.EntityFrameworkCore;

namespace Repositorio.General.Repos_Genericos.Residencia
{
    public class PaisRepositorio : Repositorio<Pais>, IPaisRepositorio
    {
        private readonly Context _context;

        public PaisRepositorio(Context context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Provincia>> SelectProvinciasPorPaisAsync(int PaisId)
        {
            try
            {
                if (PaisId == 0)
                {
                    return new List<Provincia>();  // Retorna una lista vacía si no hay país seleccionado
                }

                return await _context.Provincias
                                      .Where(p => p.PaisId == PaisId)
                                      .ToListAsync();
            }
            catch (Exception ex)
            {
                // Loguea el error
                Console.WriteLine($"Error al obtener provincias: {ex.Message}");
                return new List<Provincia>();  // Devuelve una lista vacía en caso de error
            }
        }
    }
}
