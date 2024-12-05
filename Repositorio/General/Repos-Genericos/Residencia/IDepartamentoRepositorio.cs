using WebITSC.Admin.Server.Repositorio;
using WebITSC.DB.Data.Entity;

namespace Repositorio.General.Repos_Genericos.Residencia
{
    public interface IDepartamentoRepositorio : IRepositorio<Departamento>
    {
        Task<List<Departamento>> SelectDepartamentosPorProvinciaAsync(int ProvinciaId);
    }
}