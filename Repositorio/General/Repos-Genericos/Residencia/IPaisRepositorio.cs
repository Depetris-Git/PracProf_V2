using WebITSC.Admin.Server.Repositorio;
using WebITSC.DB.Data.Entity;

namespace Repositorio.General.Repos_Genericos.Residencia
{
    public interface IPaisRepositorio : IRepositorio<Pais>
    {
        Task<List<Pais>> SelectPaisesAsync(int PaisId);
        //Task<List<Departamento>> ObtenerDepartamentosPorProvinciaAsync(int ProvinciaId);
        //Task<List<Localidad>> ObtenerLocalidadesPorDepartamentoAsync(int DepartamentoId);
        //Task<List<Provincia>> ObtenerProvinciasPorPaisAsync(int PaisId);
    }
}