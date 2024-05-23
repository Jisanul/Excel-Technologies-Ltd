using LibraryManagementSystem.DBContexts;
using LibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Repository
{
    public class NCD_DetailsRepository : INCD_DetailsRepository
    {
        private readonly ExcelTechnologiesDBContext _dbContext;

        public NCD_DetailsRepository(ExcelTechnologiesDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<NCD_Details>> GetNCD_Details()
        {
            return await _dbContext.NCD_Details.ToListAsync();
        }

        public async Task<NCD_Details> GetNCD_DetailsByID(int ncdDetailsId)
        {
            return await _dbContext.NCD_Details.FirstOrDefaultAsync(nd => nd.ID == ncdDetailsId);
        }

        public async Task InsertNCD_Details(NCD_Details ncdDetails)
        {
            await _dbContext.NCD_Details.AddAsync(ncdDetails);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateNCD_Details(NCD_Details ncdDetails)
        {
            _dbContext.Entry(ncdDetails).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteNCD_Details(int ncdDetailsId)
        {
            var ncdDetails = await _dbContext.NCD_Details.FindAsync(ncdDetailsId);
            if (ncdDetails != null)
            {
                _dbContext.NCD_Details.Remove(ncdDetails);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }

}
