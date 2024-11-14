using SolarTrackerAPIs.Models;

namespace SolarTrackerAPIs.Repository.Interface
{
    public interface IRegistroEnergiaRepository
    {
        Task<IEnumerable<RegistroEnergia>> GetRegistros();
        Task<RegistroEnergia> GetRegistro(int id);
        Task<RegistroEnergia> AddRegistro(RegistroEnergia registro);
        Task<RegistroEnergia> UpdateRegistro(RegistroEnergia registro);

    }
}
