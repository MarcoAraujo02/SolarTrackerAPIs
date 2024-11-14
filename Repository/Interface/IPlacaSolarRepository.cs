using SolarTrackerAPIs.Models;

namespace SolarTrackerAPIs.Repository.Interface
{
    public interface IPlacaSolarRepository
    {

        Task<IEnumerable<PlacaSolar>> GetPlacas();
        Task<PlacaSolar> GetPlaca(int id);
        Task<PlacaSolar> AddPlaca(PlacaSolar placa);
    }
}
