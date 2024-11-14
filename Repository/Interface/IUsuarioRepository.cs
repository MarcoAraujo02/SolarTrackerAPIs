using SolarTrackerAPIs.Models;

namespace SolarTrackerAPIs.Repository.Interface
{
    public interface IUsuarioRepository
    {

        Task<IEnumerable<Usuario>> GetUsuarios();
        Task<Usuario> GetUsuario(int id);
        Task<Usuario> AddUsuario(Usuario usuario);
        Task<Usuario> UpdateUsuario(Usuario usuario);
        Task<Usuario> DeleteUsuario(int id);
    }
}
