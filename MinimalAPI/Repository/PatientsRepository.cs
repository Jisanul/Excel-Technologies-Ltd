using LibraryManagementSystem.DBContexts;
using LibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Repository
{
    public class PatientsRepository : IPatientsRepository
    {
        private readonly ExcelTechnologiesDBContext _dbContext;

        public PatientsRepository(ExcelTechnologiesDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Patient>> GetPatients()
        {
            return await _dbContext.Patients.Include(a => a.Allergies_Details).Include(n => n.NCD_Details).ToListAsync();
        }

        public async Task<Patient> GetPatientByID(int patientId)
        {
            return await _dbContext.Patients.FirstOrDefaultAsync(p => p.PatientID == patientId);
        }

        public async Task InsertPatient(Patient patient)
        {
            await _dbContext.AddAsync(patient);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdatePatient(Patient patient)
        {
            _dbContext.Entry(patient).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeletePatient(int patientId)
        {
            var patient = await _dbContext.Patients.FindAsync(patientId);
            if (patient != null)
            {
                _dbContext.Patients.Remove(patient);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }

}
