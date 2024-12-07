using WebITSC.Admin.Server.Repositorio;
using WebITSC.DB.Data.Entity;

namespace Repositorio.General.Repos_Genericos.Residencia
{
    public interface IProvinciaRepositorio : IRepositorio<Provincia>
    {
        Task<List<Provincia>> SelectProvinciasPorPaisAsync(int PaisId);
        Task<List<Departamento>> SelectDepartamentosPorProvincia(int ProvinciaId);
    }  
}