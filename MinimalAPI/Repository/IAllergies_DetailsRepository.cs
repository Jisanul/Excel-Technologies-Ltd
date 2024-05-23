using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Repository
{
    public interface IAllergies_DetailsRepository
    {
        Task<IEnumerable<Allergies_Details>> GetAllergies_Details();
        Task<Allergies_Details> GetAllergies_DetailsByID(int allergiesDetailsId);
        Task InsertAllergies_Details(Allergies_Details allergiesDetails);
        Task UpdateAllergies_Details(Allergies_Details allergiesDetails);
        Task DeleteAllergies_Details(int allergiesDetailsId);
        Task SaveAsync();
    }
}
