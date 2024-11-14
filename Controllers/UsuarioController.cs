using Microsoft.AspNetCore.Mvc;
using SolarTrackerAPIs.Models;
using SolarTrackerAPIs.Repository.Interface;

namespace SolarTrackerAPIs.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private readonly IUsuarioRepository usuarioRepository;

        public UsuarioController(IUsuarioRepository usuario)
        {
            usuarioRepository = usuario;

        }

        /// <summary>
        /// Obter todos os Usuarios
        /// </summary>
        /// <returns></returns>
        /// <response code="200"> Retorna a lista de usuario</response>
        /// <response code="500"> Erro ao obter usuarios</response>
        /// <response code="404"> usuario nao encontrado</response>
        /// 
        [HttpGet]
        public async Task<ActionResult<Usuario>> GetUsuarios()
        {
            try
            {

                return Ok(await usuarioRepository.GetUsuarios());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao pegar Usuarios");
            }

        }


        /// <summary>
        /// Obter o Usuario pelo ID
        /// </summary>
        /// <returns></returns>
        /// <response code="200"> Retorna a lista de Usuarios</response>
        /// <response code="500"> Erro ao obter usuario</response>
        /// <response code="404"> Usuario nao encontrado</response>
        /// 
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            try
            {
                var result = await usuarioRepository.GetUsuario(id);
                if (result == null) return NotFound();

                return result;

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter Usuario");
            }



        }


        /// <summary>
        /// Endpoint para cadastrar novos Usuarios
        /// </summary>
        /// <returns>Retorna o Usuario</returns>
        ///
        /// <response code="201"> Salva o Usuario</response>
        /// <response code="500"> Erro ao salva o Usuario</response>
        /// <response code="400"> Verifique as informações</response>
        /// 
        [HttpPost]
        public async Task<ActionResult<Usuario>> AddUsuario([FromBody] Usuario usuario)
        {
            try
            {
                if (usuario == null) return BadRequest();

                var createUser = await usuarioRepository.AddUsuario(usuario);


                return CreatedAtAction(nameof(GetUsuarios),
                    new { id = createUser.IdUsuario }, createUser);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao criar Usuario");
            }
        }


        /// <summary>
        /// Deletar usuario pelo Id selecionado
        /// </summary>
        /// <returns></returns>
        /// <response code="200"> Retorna a lista de usuarios</response>
        /// <response code="500"> Erro ao obter usuarios</response>
        /// <response code="404"> Usuarios nao encontrado</response>
        /// 
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteUsuario(int id)
        {
            try
            {
                var UserToDelete = await usuarioRepository.GetUsuario(id);

                if (UserToDelete == null)
                    return NotFound($"Usuario com id {id} não encontrado");

                await usuarioRepository.DeleteUsuario(id);

                return Ok($"Usuario com id {id} deletado");
            }
            catch (Exception ex)
            {


                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao deletar Usuario");
            }
        }


        /// <summary>
        /// Atualizar usuario
        /// </summary>
        /// <returns></returns>
        /// <response code="200"> Retorna o Usuario editado</response>
        /// <response code="500"> Erro ao obter usuario</response>
        /// <response code="404"> Usuario nao encontrado</response>
        /// 
        [HttpPut]
        public async Task<ActionResult<Usuario>> UpdateUsuario([FromBody] Usuario usuario)
        {
            try
            {
                var userUpdate = await usuarioRepository.GetUsuario(usuario.IdUsuario);

                if (userUpdate == null) return NotFound($"Usuario com id {usuario.IdUsuario} não encontrado");

                return await usuarioRepository.UpdateUsuario(usuario);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao atualizar Usuario");
            }
        }
    }
}
