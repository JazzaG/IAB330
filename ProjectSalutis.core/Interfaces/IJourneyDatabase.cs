using ProjectSalutis.core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectSalutis.core.Interfaces
{
    public interface IJourneyDatabase
    {
        Task<IEnumerable<JourneyEntry>> GetEntries();

        Task<int> DeleteEntry(object id);

        Task<int> InsertEntry(JourneyEntry entry);
        Task<int> InsertEntry(string category, int rating);
    }
}
