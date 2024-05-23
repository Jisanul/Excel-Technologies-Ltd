using LibraryManagementSystem.Models;
using PatientManagementSystem.Models;

namespace LibraryManagementSystem.Repository
{
    public interface IEpilepsyRepository
    {
        Task<IEnumerable<Epilepsy>> GetEpilepsiesAsync();
        Task<Epilepsy?> GetEpilepsyByIdAsync(int id);
        Task InsertEpilepsyAsync(Epilepsy epilepsy);
        Task UpdateEpilepsyAsync(int id, Epilepsy epilepsy);
        Task DeleteEpilepsyAsync(int id);
    }
}
