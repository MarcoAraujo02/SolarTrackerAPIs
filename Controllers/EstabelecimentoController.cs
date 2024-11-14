using Microsoft.AspNetCore.Mvc;
using SolarTrackerAPIs.Models;
using SolarTrackerAPIs.Repository.Interface;
using System.Numerics;

namespace SolarTrackerAPIs.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EstabelecimentoController : ControllerBase
    {
        private readonly IEstabelecimentoRepository estabelecimentoRepository;
        private readonly IUsuarioRepository usuarioRepository;

        public EstabelecimentoController(IEstabelecimentoRepository estabelecimento, IUsuarioRepository usuario)
        {
            estabelecimentoRepository = estabelecimento;
            usuarioRepository = usuario;
        }


        /// <summary>
        /// Obter todos os estabelecimentos
        /// </summary>
        /// <returns></returns>
        /// <response code="200"> Retorna a lista de estabelecimentos</response>
        /// <response code="500"> Erro ao obter estabelecimento</response>
        /// <response code="404"> estabelecimento nao encontrado</response>
        /// 
        [HttpGet]
        public async Task<ActionResult<Estabelecimento>> GetEstabelecimentos()
        {
            try
            {

                return Ok(await estabelecimentoRepository.GetEstabelecimento());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao pegar funcionarios");
            }

        }


        /// <summary>
        /// Obter Estabelecimento pelo id selecionado
        /// </summary>
        /// <returns></returns>
        /// <response code="200"> Retorna Estabelecimento</response>
        /// <response code="500"> Erro ao obter Estabelecimento</response>
        /// <response code="404"> Estabelecimento nao encontrado</response>
        /// 
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Estabelecimento>> GetEstabelecimento(int id)
        {
            try
            {
                var result = await estabelecimentoRepository.GetEstabelecimento(id);
                if (result == null) return NotFound();

                return result;

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter Estabelecimento");
            }



        }


        /// <summary>
        /// Endpoint para cadastrar novos Estabelecimentos
        /// </summary>
        /// <returns>Retorna o  Estabelecimento</returns>
        ///
        /// <response code="201"> Salva o Estabelecimento</response>
        /// <response code="500"> Erro ao salva o Estabelecimento</response>
        /// <response code="400"> Verifique as informações</response>
        /// 
        [HttpPost]
        public async Task<ActionResult<Estabelecimento>> AddEstabelecimento([FromBody] Estabelecimento estabelecimento)
        {
            try
            {
                if (estabelecimento == null) return BadRequest();

                var UsuarioExistente = await usuarioRepository.GetUsuario(estabelecimento.IdUsuario);
                if (UsuarioExistente == null)
                    return NotFound("Id Usuario não encontrado.");

                var createEstab = await estabelecimentoRepository.AddEstabelecimento(estabelecimento);


                return CreatedAtAction(nameof(GetEstabelecimentos),
                    new { id = createEstab.IdEstabelecimento }, createEstab);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter Estabelecimento");
            }
        }


        /// <summary>
        /// Deletar Estabelecimento
        /// </summary>
        /// <returns></returns>
        /// <response code="200"> Estabelecimento deletado</response>
        /// <response code="500"> Erro ao deletar estabelecimento</response>
        /// <response code="404"> Id do estabelecimento nao encontrado </response>
        /// 
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteEstabelecimento(int id)
        {
            try
            {
                var EstabToDelete = await estabelecimentoRepository.GetEstabelecimento(id);

                if (EstabToDelete == null)
                    return NotFound($"Funcionario com id {id} não encontrado");

                await estabelecimentoRepository.DeleteEstabelecimento(id);

                return Ok($"Funcionario com id {id} deletado");
            }
            catch (Exception ex)
            {
                // Log the exception message
                // Logger.LogError(ex, "Erro ao deletar Funcionario");

                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao deletar Funcionario");
            }
        }


        /// <summary>
        /// Atualizar dados estabelecimento
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Estabelecimento>> UpdateEstabelecimento([FromBody] Estabelecimento estabelecimento)
        {
            try
            {
                var estabUpdate = await estabelecimentoRepository.GetEstabelecimento(estabelecimento.IdEstabelecimento);

                if (estabUpdate == null) return NotFound($"Estabelecimento com id {estabelecimento.IdEstabelecimento} não encontrado");

                return await estabelecimentoRepository.UpdateEstabelecimento(estabelecimento);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao atualizar estabelecimento");
            }
        }
    }
}
