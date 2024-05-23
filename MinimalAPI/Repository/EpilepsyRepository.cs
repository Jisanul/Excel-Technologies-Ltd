using LibraryManagementSystem.DBContexts;
using LibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using PatientManagementSystem.Models;

namespace LibraryManagementSystem.Repository
{
    public class EpilepsyRepository : IEpilepsyRepository
    {
        private readonly List<Epilepsy> _epilepsies = new();

        public Task<IEnumerable<Epilepsy>> GetEpilepsiesAsync()
        {
            return Task.FromResult(_epilepsies.AsEnumerable());
        }

        public Task<Epilepsy?> GetEpilepsyByIdAsync(int id)
        {
            var epilepsy = _epilepsies.ElementAtOrDefault(id);
            return Task.FromResult(epilepsy as Epilepsy?);
        }

        public Task InsertEpilepsyAsync(Epilepsy epilepsy)
        {
            _epilepsies.Add(epilepsy);
            return Task.CompletedTask;
        }

        public Task UpdateEpilepsyAsync(int id, Epilepsy epilepsy)
        {
            if (id >= 0 && id < _epilepsies.Count)
            {
                _epilepsies[id] = epilepsy;
            }
            return Task.CompletedTask;
        }

        public Task DeleteEpilepsyAsync(int id)
        {
            if (id >= 0 && id < _epilepsies.Count)
            {
                _epilepsies.RemoveAt(id);
            }
            return Task.CompletedTask;
        }
    }

}
