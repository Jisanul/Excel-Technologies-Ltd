using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Repository
{
    public interface INCDRepository
    {
        Task<IEnumerable<NCD>> GetNCDs();
        Task<NCD> GetNCDByID(int ncdId);
        Task InsertNCD(NCD ncd);
        Task UpdateNCD(NCD ncd);
        Task DeleteNCD(int ncdId);
        Task SaveAsync();
    }
}
