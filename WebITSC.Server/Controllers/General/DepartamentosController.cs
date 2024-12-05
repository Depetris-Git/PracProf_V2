using AutoMapper;
using WebITSC.Admin.Server.Repositorio;
using WebITSC.DB.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using WebITSC.Shared.General.DTO.ProvinciaDptoLocal;
using Repositorio.General.Repos_Genericos.Residencia;

namespace WebITSC.Admin.Server.Controllers
{
    [ApiController]
    [Route("api/Departamentos")]
    public class DepartamentosController : ControllerBase
    {
        private readonly IDepartamentoRepositorio eRepositorio;
        private readonly IMapper mapper;

        public DepartamentosController(IDepartamentoRepositorio eRepositorio, IMapper mapper)
        {
            this.eRepositorio = eRepositorio;
            this.mapper = mapper;
        }

        // Obtener todos los departamentos
        [HttpGet]
        public async Task<ActionResult<List<GetDepartamentosDTO>>> GetAll()
        {
            var departamentos = await eRepositorio.Select();
            var departamentosDto = mapper.Map<List<GetDepartamentosDTO>>(departamentos);
            return Ok(departamentosDto);
        }

        // Obtener un departamento por su ID
        [HttpGet("{id:int}")]
        public async Task<ActionResult<GetDepartamentosDTO>> Get(int id)
        {
            Departamento? departamento = await eRepositorio.SelectById(id);

            if (departamento == null)
            {
                return NotFound();
            }

            var departamentoDto = mapper.Map<GetDepartamentosDTO>(departamento);
            return Ok(departamentoDto);
        }

        // Verificar si el departamento existe por ID
        [HttpGet("existe/{id:int}")]
        public async Task<ActionResult<bool>> Existe(int id)
        {
            var existe = await eRepositorio.Existe(id);
            return existe;
        }

        // Crear un nuevo departamento
        [HttpPost]
        public async Task<ActionResult<int>> Post(CrearDepartamentosDTO departamentoDTO)
        {
            try
            {
                // Mapeamos el DTO CrearDepartamentoDTO a la entidad Departamento
                Departamento departamento = mapper.Map<Departamento>(departamentoDTO);

                // Insertamos el nuevo departamento
                int result = await eRepositorio.Insert(departamento);
                return Ok(result);  // Regresar el ID de la nueva provincia insertada
            }
            catch (Exception e)
            {
                // Log del error detallado
                Console.WriteLine($"Error al insertar departamento: {e.Message}");
                Console.WriteLine($"Detalles del error: {e.InnerException?.Message}");
                return BadRequest($"Ocurrió un error: {e.Message}");
            }
        }

        // Actualizar un departamento existente
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] Departamento departamento)
        {
            if (id != departamento.Id)
            {
                return BadRequest("Datos incorrectos");
            }

            var departamentoExistente = await eRepositorio.SelectById(id);

            if (departamentoExistente == null)
            {
                return NotFound("No existe el departamento buscado.");
            }

            departamentoExistente = mapper.Map<Departamento>(departamento);

            try
            {
                await eRepositorio.Update(id, departamentoExistente);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // Eliminar un departamento
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await eRepositorio.Existe(id);
            if (!existe)
            {
                return NotFound($"El departamento con ID {id} no existe.");
            }

            Departamento departamentoABorrar = new Departamento { Id = id };

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
