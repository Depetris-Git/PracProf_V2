using WebITSC.DB.Data.Entity;
using WebITSC.Shared.General.DTO;

namespace WebITSC.Admin.Server.Repositorio
{
    public interface IMateriaEnPlanEstudioRepositorio : IRepositorio<MateriaEnPlanEstudio>
    {
        Task DeleteByMateriaId(int materiaId);
        Task DeleteByPlanEstudioId(int planEstudioId);
        Task<List<MateriaEnPlanEstudio>> FullGetAll();
        Task<MateriaEnPlanEstudio> FullGetById(int id);

        /// <summary>
        /// Le pasas el ID de una materia para que te pase todas las instancias
        /// en que esa materia se relaciona con un Plan de Estudio
        /// </summary>
        /// <param name="materiaId"></param>
        /// <returns>Devuelve la lista de materiaEnPlanEstudio que tengan el mismo materiaId</returns>
        Task<List<MateriaEnPlanEstudio>> FullGetByMateria(int materiaId);

        /// <summary>
        /// Le pasas el ID de un Plan de Estudio para que te pase todas las instancias
        /// en una materia se relaciona con ese plan
        /// </summary>
        /// <param name="planEstudioId"></param>
        /// <returns>Devuelve la lista de MateriasEnPlanEstudio de un Plan de Estudio en particular</returns>
        Task<List<TraerMateriaEnPlanDTO>> FullGetByPlanEstudio(int planEstudioId);
    }
}