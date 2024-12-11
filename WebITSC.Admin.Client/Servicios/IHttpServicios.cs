using WebITSC.DB.Data.Entity;

namespace WebITSC.Admin.Client.Servicios
{
    public interface IHttpServicios
    {
        Task<HttpRespuesta<O>> Get<O>(string url);
        Task<HttpRespuesta<object>> GetNotasByTurno(string url);
        Task<List<Departamento>> SelectDepartamentosPorProvinciaAsync(int ProvinciaId);
        Task<List<Localidad>> SelectLocalidadesPorDepartamentoAsync(int DepartamentoId);
        Task<List<Pais>> SelectPaisesAsync();
        Task<List<Provincia>> SelectProvinciasPorPaisAsync(int PaisId);
        Task<HttpRespuesta<object>> Post<O>(string url, O entidad);
        Task<HttpRespuesta<object>> Put<O>(string url, O entidad);
        Task<HttpRespuesta<object>> Delete(string url);
    }
}