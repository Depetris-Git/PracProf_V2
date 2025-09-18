using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using Repositorio.General;
using WebITSC.Admin.Server.Repositorio;
using WebITSC.DB.Data.Entity;
using WebITSC.Shared.General.DTO.Alumnos;
using WebITSC.Shared.General.DTO.Carreraa;

namespace WebITSC.Admin.Server.Controllers
{
    namespace WebITSC.Admin.Server.Controllers
    {
        [ApiController]
        [Route("api/Carreras")]
        public class CarrerasController : ControllerBase
        {
            private readonly ICarreraRepositorio eRepositorio;
            private readonly IMapper mapper;
            private readonly IOutputCacheStore outputCacheStore;
            private const string cacheKey = "Carreras";

            public CarrerasController(ICarreraRepositorio eRepositorio,
                                                IMapper mapper,
                                                IOutputCacheStore outputCacheStore)
            {
                this.eRepositorio = eRepositorio;
                this.mapper = mapper;
                this.outputCacheStore = outputCacheStore;

            }

            [HttpGet]
            [OutputCache(Tags = [cacheKey])]
            public async Task<ActionResult<List<GetCarreraDTO>>> GetAll()
            {
                var carreras = await eRepositorio.Select();
                 
                
                return Ok(carreras);
            }

           /* [HttpGet("ForSearch")]
            public async Task<ActionResult<List<GetCarreraDTO>>> GetAllByName()
            {
                var carreras = await eRepositorio.Select();

                return Ok(carreras);
            }
            */
            [HttpGet("{id:int}")]
            public async Task<ActionResult<GetCarreraDTO>> Get(int id)
            {
                // Seleccionamos la entidad Carrera
                Carrera? sel = await eRepositorio.SelectById(id);

                if (sel == null)
                {
                    return NotFound();
                }

                // Usamos AutoMapper para mapear la entidad Carrera a GetCarreraDTO
                var carreraDto = mapper.Map<GetCarreraDTO>(sel);

                return Ok(carreraDto);
            }


            [HttpGet("existe/{id:int}")]
            public async Task<ActionResult<bool>> Existe(int id)
            {
                var existe = await eRepositorio.Existe(id);
                return existe;

            }

            [HttpGet("IdByName")]
            public async Task<ActionResult<int>> GetIdByName(string name)
            {
               var a = eRepositorio.GetByNombre(name);
                if (a != null)
                {
                    var b = a.Result;
                    if (b == 0)
                    {
                        return NotFound(0);
                    }
                    else
                    {
                        return Ok(b);
                    }
                }
                else
                {
                    return BadRequest();
                }
            }
             

            [HttpPost]
            public async Task<ActionResult<int>> Post(CrearCarreraDTO entidadDTO)
            {
                try
                {
                    Carrera entidad = mapper.Map<Carrera>(entidadDTO);

                    return await eRepositorio.Insert(entidad);
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }

            [HttpPut("{id:int}")]
            public async Task<ActionResult> Put(int id, [FromBody] Carrera entidad)
            {
                if (id != entidad.Id)
                {
                    return BadRequest("Datos incorrectos");
                }
                var sel = await eRepositorio.SelectById(id);
                //sel = Seleccion

                if (sel == null)
                {
                    return NotFound("No existe el tipo de documento buscado.");
                }


                sel = mapper.Map<Carrera>(entidad);

                try
                {
                    await eRepositorio.Update(id, sel);
                    return Ok();
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }

            [HttpDelete("{id:int}")]
            public async Task<ActionResult> Delete(int id)
            {
                var existe = await eRepositorio.Existe(id);
                if (!existe)
                {
                    return NotFound($"La persona {id} no existe");
                }
                Carrera EntidadABorrar = new Carrera();
                EntidadABorrar.Id = id;

                if (await eRepositorio.Delete(id))
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
