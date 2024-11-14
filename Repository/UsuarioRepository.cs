using Microsoft.EntityFrameworkCore;
using SolarTrackerAPIs.Data;
using SolarTrackerAPIs.Models;
using SolarTrackerAPIs.Repository.Interface;

namespace SolarTrackerAPIs.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly dbContext dbContext;

        public UsuarioRepository(dbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Usuario> AddUsuario(Usuario usuario)
        {
            var result = await dbContext.Usuarios.AddAsync(usuario);
            await dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Usuario> DeleteUsuario(int id)
        {
            var result = await dbContext.Usuarios.FirstOrDefaultAsync(x => x.IdUsuario == id);
            if (result != null)
            {
                dbContext.Usuarios.Remove(result);
                await dbContext.SaveChangesAsync();
            }

            return result;
        }

        public async Task<IEnumerable<Usuario>> GetUsuarios()
        {
            return await dbContext.Usuarios.ToListAsync();
        }

        public async Task<Usuario> UpdateUsuario(Usuario usuario)
        {
            var result = await dbContext.Usuarios.FirstOrDefaultAsync(x => x.IdUsuario == usuario.IdUsuario);

            if (result != null)
            {
                result.IdUsuario = usuario.IdUsuario;
                result.Nome = usuario.Nome;
                result.Senha = usuario.Senha;
                result.Email = usuario.Email;

                await dbContext.SaveChangesAsync();

                return result;
            }

            return null;
        }

        public async Task<Usuario> GetUsuario(int userid)
        {
            return await dbContext.Usuarios.FirstOrDefaultAsync(x => x.IdUsuario == userid);
        }
    }
}
