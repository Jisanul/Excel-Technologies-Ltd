using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Repository
{
    public interface IPatientsRepository
    {
        Task<IEnumerable<Patient>> GetPatients();
        Task<Patient> GetPatientByID(int patientId);
        Task InsertPatient(Patient patient);
        Task UpdatePatient(Patient patient);
        Task DeletePatient(int patientId);
        Task SaveAsync();
    }
}
