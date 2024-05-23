using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Repository
{
    public interface IDiseaseInformationRepository
    {
        Task<IEnumerable<DiseaseInformation>> GetDiseaseInformation();
        Task<DiseaseInformation> GetDiseaseInformationByID(int diseaseId);
        Task InsertDiseaseInformation(DiseaseInformation diseaseInformation);
        Task UpdateDiseaseInformation(DiseaseInformation diseaseInformation);
        Task DeleteDiseaseInformation(int diseaseId);
        Task SaveAsync();
    }
}
