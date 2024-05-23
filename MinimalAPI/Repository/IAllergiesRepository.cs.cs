using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Repository
{
    public interface IAllergiesRepository
    {
        Task<IEnumerable<Allergies>> GetAllergies();

        Task<Allergies> GetAllergiesByID(int allergiesID);

        Task InsertAllergies(Allergies allergies);

        Task UpdateAllergies(Allergies allergies);

        void Save();
        Task SaveAsync();
        Task DeleteAllergies(int allergies);
    }
}
