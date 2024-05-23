using LibraryManagementSystem.DBContexts;
using LibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Repository
{
    public class DiseaseInformationRepository : IDiseaseInformationRepository
    {
        private readonly ExcelTechnologiesDBContext _dbContext;

        public DiseaseInformationRepository(ExcelTechnologiesDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<DiseaseInformation>> GetDiseaseInformation()
        {
            return await _dbContext.DiseaseInformation.ToListAsync();
        }

        public async Task<DiseaseInformation> GetDiseaseInformationByID(int diseaseId)
        {
            return await _dbContext.DiseaseInformation.FirstOrDefaultAsync(d => d.DiseaseID == diseaseId);
        }

        public async Task InsertDiseaseInformation(DiseaseInformation diseaseInformation)
        {
            await _dbContext.AddAsync(diseaseInformation);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateDiseaseInformation(DiseaseInformation diseaseInformation)
        {
            _dbContext.Entry(diseaseInformation).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteDiseaseInformation(int diseaseId)
        {
            var diseaseInformation = await _dbContext.DiseaseInformation.FindAsync(diseaseId);
            if (diseaseInformation != null)
            {
                _dbContext.DiseaseInformation.Remove(diseaseInformation);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }

}
