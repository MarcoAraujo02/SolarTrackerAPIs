using Microsoft.AspNetCore.Mvc;
using SolarTrackerAPIs.Models;
using SolarTrackerAPIs.Repository.Interface;

namespace SolarTrackerAPIs.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RegistroEnergiaController : ControllerBase
    {
        private readonly IRegistroEnergiaRepository registroRepository;
        private readonly IPlacaSolarRepository placaSolarRepository;

        public RegistroEnergiaController(IRegistroEnergiaRepository registro, IPlacaSolarRepository placa )
        {
            registroRepository = registro;
            placaSolarRepository = placa;
        }

        /// <summary>
        /// Obter todos os Registros
        /// </summary>
        /// <returns></returns>
        /// <response code="200"> Retorna a lista de registros</response>
        /// <response code="500"> Erro ao obter registros</response>
        /// <response code="404"> registros nao encontrado</response>
        /// 
        [HttpGet]
        public async Task<ActionResult<RegistroEnergia>> GetRegistros()
        {
            try
            {

                return Ok(await registroRepository.GetRegistros());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao pegar Registros");
            }

        }


        /// <summary>
        /// Obter Registro pelo id selecionado
        /// </summary>
        /// <returns></returns>
        /// <response code="200"> Retorna Registro</response>
        /// <response code="500"> Erro ao obter Registro</response>
        /// <response code="404"> Registro nao encontrado</response>
        /// 
        [HttpGet("{id:int}")]
        public async Task<ActionResult<RegistroEnergia>> GetRegistro(int id)
        {
            try
            {
                var result = await registroRepository.GetRegistro(id);
                if (result == null) return NotFound();

                return result;

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter Estabelecimento");
            }



        }


        /// <summary>
        /// Endpoint para cadastrar novos Registros
        /// </summary>
        /// <returns>Retorna o registro solar cadastrado</returns>
        /// <response code="201"> Salva o Registro</response>
        /// <response code="500"> Erro ao salvar o registro</response>
        /// <response code="400"> Verifique as informações</response>
        [HttpPost]
        public async Task<ActionResult<RegistroEnergia>> AddRegistro([FromBody] RegistroEnergia registro)
        {
            try
            {
                if (registro == null) return BadRequest();

                var PlacaExistente = await placaSolarRepository.GetPlaca(registro.IdPlacaSolar);
                if (PlacaExistente == null) return NotFound("Id da placa não foi encontrada verifique se a placa realmente existe");

                var createReg = await registroRepository.AddRegistro(registro);


                return CreatedAtAction(nameof(GetRegistros),
                    new { id = createReg.IdPlacaSolar }, createReg);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao criar Usuario");
            }
        }


        /// <summary>
        /// Atualizar dados dos registros
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpPut("{id:int}")]
        public async Task<ActionResult<RegistroEnergia>> UpdateRegistro([FromBody] RegistroEnergia registro)
        {
            try
            {
                var regUpdate = await registroRepository.GetRegistro(registro.idRegistroEnergia);

                if (regUpdate == null) return NotFound($"Registro com id {registro.idRegistroEnergia} não encontrado");

                return await registroRepository.UpdateRegistro(registro);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao atualizar estabelecimento");
            }
        }
    }
}
