using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Repository
{
    public interface INCD_DetailsRepository
    {
        Task<IEnumerable<NCD_Details>> GetNCD_Details();
        Task<NCD_Details> GetNCD_DetailsByID(int ncdDetailsId);
        Task InsertNCD_Details(NCD_Details ncdDetails);
        Task UpdateNCD_Details(NCD_Details ncdDetails);
        Task DeleteNCD_Details(int ncdDetailsId);
        Task SaveAsync();
    }
}
