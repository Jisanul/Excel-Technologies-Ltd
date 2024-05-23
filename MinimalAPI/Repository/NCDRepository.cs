using LibraryManagementSystem.DBContexts;
using LibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Repository
{
    public class NCDRepository : INCDRepository
    {
        private readonly ExcelTechnologiesDBContext _dbContext;

        public NCDRepository(ExcelTechnologiesDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<NCD>> GetNCDs()
        {
            return await _dbContext.NCDs.ToListAsync();
        }

        public async Task<NCD> GetNCDByID(int ncdId)
        {
            return await _dbContext.NCDs.FirstOrDefaultAsync(n => n.NCDID == ncdId);
        }

        public async Task InsertNCD(NCD ncd)
        {
            await _dbContext.NCDs.AddAsync(ncd);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateNCD(NCD ncd)
        {
            _dbContext.Entry(ncd).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteNCD(int ncdId)
        {
            var ncd = await _dbContext.NCDs.FindAsync(ncdId);
            if (ncd != null)
            {
                _dbContext.NCDs.Remove(ncd);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }

}
