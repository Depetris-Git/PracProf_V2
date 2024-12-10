using AutoMapper;
using WebITSC.Admin.Server.Repositorio;
using WebITSC.DB.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using WebITSC.Shared.General.DTO.PaisesDTO;
using Repositorio.General.Repos_Genericos.Residencia;
using WebITSC.Shared.General.DTO.ProvinciaDptoLocal;


namespace WebITSC.Admin.Server.Controllers
{
    [ApiController]
    [Route("api/Paises")]
    public class PaisesController : ControllerBase
    {
        private readonly IPaisRepositorio eRepositorio;
        private readonly IMapper mapper;

        public PaisesController(IPaisRepositorio eRepositorio, IMapper mapper)
        {
            this.eRepositorio = eRepositorio;
            this.mapper = mapper;
        }

        // Obtener todos los paises
        [HttpGet]
        public async Task<ActionResult<List<GetPaisDTO>>> GetAll()
        {
            var paises = await eRepositorio.Select();
            // Mapeamos la lista de entidades Pais a GetPaisDTO
            var paisesDto = mapper.Map<List<GetPaisDTO>>(paises);
            return Ok(paisesDto);
        }

        // Obtener un pais por su ID
        [HttpGet("{id:int}")]
        public async Task<ActionResult<GetPaisDTO>> Get(int id)
        {
            // Seleccionamos la entidad Pais
            Pais? pais = await eRepositorio.SelectById(id);

            if (pais == null)
            {
                return NotFound();
            }

            // Mapeamos la entidad Pais a GetPaisDTO
            var paisDto = mapper.Map<GetPaisDTO>(pais);

            return Ok(paisDto);
        }

        // Verificar si el pais existe por ID
        [HttpGet("existe/{id:int}")]
        public async Task<ActionResult<bool>> Existe(int id)
        {
            var existe = await eRepositorio.Existe(id);
            return existe;
        }

        //// Obtener las provincias por país
        //[HttpGet("{PaisId}/Provincias")]
        //public async Task<ActionResult<List<GetProvinciaDTO>>> GetProvinciasPorPais(int PaisId)
        //{
        //    // Verificamos si el país existe
        //    var pais = await eRepositorio.SelectById(PaisId);
        //    if (pais == null)
        //    {
        //        return NotFound($"No se encontró el país con ID {PaisId}");
        //    }

        //    // Llamamos al repositorio para obtener las provincias asociadas
        //    var provincias = await eRepositorio.SelectProvinciasPorPaisAsync(PaisId);

        //    // Si no hay provincias, devolvemos una lista vacía
        //    if (provincias == null || !provincias.Any())
        //    {
        //        return Ok(new List<GetProvinciaDTO>());
        //    }

        //    // Mapeamos las provincias a un DTO
        //    var provinciasDto = mapper.Map<List<GetProvinciaDTO>>(provincias);

        //    return Ok(provinciasDto);
        //}


        // Crear un nuevo pais
        [HttpPost]
        public async Task<ActionResult<int>> Post(CrearPaisDTO paisDTO)
        {
            try
            {
                // Mapeamos el DTO CrearPaisDTO a la entidad Pais
                Pais pais = mapper.Map<Pais>(paisDTO);
                // Insertamos el nuevo pais
                return await eRepositorio.Insert(pais);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // Actualizar un pais existente
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] Pais pais)
        {
            if (id != pais.Id)
            {
                return BadRequest("Datos incorrectos");
            }

            var paisExistente = await eRepositorio.SelectById(id);

            if (paisExistente == null)
            {
                return NotFound("No existe el pais buscado.");
            }

            paisExistente = mapper.Map<Pais>(pais);

            try
            {
                await eRepositorio.Update(id, paisExistente);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // Eliminar un pais
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await eRepositorio.Existe(id);
            if (!existe)
            {
                return NotFound($"El pais con ID {id} no existe.");
            }

            Pais paisABorrar = new Pais { Id = id };

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


