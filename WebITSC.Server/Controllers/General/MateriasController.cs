using AutoMapper;
using WebITSC.Admin.Server.Repositorio;

using WebITSC.DB.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using WebITSC.Shared.General.DTO;
using WebITSC.DB.Data;

namespace WebITSC.Admin.Server.Controllers
{
    namespace WebITSC.Admin.Server.Controllers
    {
        [ApiController]
        [Route("api/Materias")]
        public class MateriasController : ControllerBase
        {
            private readonly IRepositorio<Materia> repositorio;
            private readonly IMapper mapper;

            public MateriasController(IRepositorio<Materia> repositorio,
                                      IMapper mapper)
            {

                this.repositorio = repositorio;
                this.mapper = mapper;
            }
 
            #region Peticiones Get

            [HttpGet]
           public async Task<ActionResult<List<Materia>>> Get()
           {
               return await repositorio.Select();
           }

            [HttpGet("{id:int}")]
           public async Task<ActionResult<Materia>> Get(int id)
           {
               Materia? sel = await repositorio.SelectById(id);
               if (sel == null)
               {
                    return NotFound();
               }
                   return sel;
           }


            [HttpGet("existe/{id:int}")]
            public async Task<ActionResult<bool>> Existe(int id)
            {
                var existe = await repositorio.Existe(id);
              return existe;

            }

            #endregion

            [HttpPost]
            public async Task<ActionResult<int>> Post(CrearMateriaDTO entidadDTO)
            {
                try
                {
                    Materia entidad = mapper.Map<Materia>(entidadDTO);

                    return await repositorio.Insert(entidad);
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }

            [HttpPut("{id:int}")]
            public async Task<ActionResult> Put(int id, [FromBody] Materia entidad)
            {

                if (id != entidad.Id)
                {
                    return BadRequest("Datos incorrectos");
                }
                var sel = await repositorio.SelectById(id);
                //sel = Seleccion

                if (sel == null)
                {
                    return NotFound("No existe el tipo de documento buscado.");
                }


                sel = mapper.Map<Materia>(entidad);

                try
                {
                    await repositorio.Update(id, sel);
                    return Ok();
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }

            [HttpPut("Actualizar/{id}")]
            public async Task<ActionResult> UpdateMateria(int id, [FromBody] PutNombreMateriaDTO materiaDTO)
            {
                var materia = await repositorio.SelectById(id);
                if (materia == null)
                {
                    return NotFound("Materia no encontrada");
                }

                materia.Nombre = materiaDTO.Nombre;
                await repositorio.Update(id, materia);

                return NoContent();
            }

            [HttpDelete("{id:int}")]
            public async Task<ActionResult> Delete(int id)
            {
                var existe = await repositorio.Existe(id);
                if (!existe)
                {
                    return NotFound($"La persona {id} no existe");
                }
                Materia EntidadABorrar = new Materia();
                EntidadABorrar.Id = id;

                if (await repositorio.Delete(id))
                {
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }

            }



        }

    }
}
