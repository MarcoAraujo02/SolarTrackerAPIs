using Microsoft.EntityFrameworkCore;
using SolarTrackerAPIs.Data;
using SolarTrackerAPIs.Models;
using SolarTrackerAPIs.Repository.Interface;

namespace SolarTrackerAPIs.Repository
{
    public class PlacaSolarRepository : IPlacaSolarRepository
    {

        private readonly dbContext dbContext;

        public PlacaSolarRepository(dbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<PlacaSolar> AddPlaca(PlacaSolar placa)
        {
            var result = await dbContext.PlacaSolares.AddAsync(placa);
            await dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<PlacaSolar> GetPlaca(int id)
        {
            return await dbContext.PlacaSolares.FirstOrDefaultAsync(x => x.idPlacaSolar == id);
        }

        public async Task<IEnumerable<PlacaSolar>> GetPlacas()
        {
            return await dbContext.PlacaSolares.ToListAsync();
        }
    }
}
