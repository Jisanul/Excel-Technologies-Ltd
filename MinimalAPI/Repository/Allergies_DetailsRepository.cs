using LibraryManagementSystem.DBContexts;
using LibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Repository
{
    public class Allergies_DetailsRepository : IAllergies_DetailsRepository
    {
        private readonly ExcelTechnologiesDBContext _dbContext;

        public Allergies_DetailsRepository(ExcelTechnologiesDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Allergies_Details>> GetAllergies_Details()
        {
            return await _dbContext.Allergies_Details.ToListAsync();
        }

        public async Task<Allergies_Details> GetAllergies_DetailsByID(int allergiesDetailsId)
        {
            return await _dbContext.Allergies_Details.FirstOrDefaultAsync(ad => ad.ID == allergiesDetailsId);
        }

        public async Task InsertAllergies_Details(Allergies_Details allergiesDetails)
        {
            await _dbContext.Allergies_Details.AddAsync(allergiesDetails);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAllergies_Details(Allergies_Details allergiesDetails)
        {
            _dbContext.Entry(allergiesDetails).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAllergies_Details(int allergiesDetailsId)
        {
            var allergiesDetails = await _dbContext.Allergies_Details.FindAsync(allergiesDetailsId);
            if (allergiesDetails != null)
            {
                _dbContext.Allergies_Details.Remove(allergiesDetails);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }

}
