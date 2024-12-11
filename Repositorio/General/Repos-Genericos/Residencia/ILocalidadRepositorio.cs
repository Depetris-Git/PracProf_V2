using WebITSC.Admin.Server.Repositorio;
using WebITSC.DB.Data.Entity;

namespace Repositorio.General.Repos_Genericos.Residencia
{
    public interface ILocalidadRepositorio : IRepositorio<Localidad>
    {
        Task<Localidad> GetByIdAsync(int id);
        Task<List<Localidad>> SelectLocalidadesPorDepartamentoAsync(int DepartamentoId);
    }
}