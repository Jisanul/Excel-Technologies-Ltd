using LibraryManagementSystem.DBContexts;
using LibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Repository
{
    public class AllergiesRepository : IAllergiesRepository
    {
        private readonly ExcelTechnologiesDBContext _dbContext;

        public AllergiesRepository(ExcelTechnologiesDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Allergies>> GetAllergies()
        {
            return await _dbContext.Allergies.ToListAsync();
        }

        public async Task<Allergies> GetAllergiesByID(int allergiesId)
        {
            return await _dbContext.Allergies.FirstOrDefaultAsync(a => a.AllergiesID == allergiesId);
        }

        public async Task InsertAllergies(Allergies allergies)
        {
            await _dbContext.AddAsync(allergies);
            await _dbContext.SaveChangesAsync();
        }


        public async Task UpdateAllergies(Allergies allergies)
        {
            _dbContext.Entry(allergies).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteAllergies(int allergiesId)
        {
            var allergies = await _dbContext.Allergies.FindAsync(allergiesId);
            if (allergies != null)
            {
                _dbContext.Allergies.Remove(allergies);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
