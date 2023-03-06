using OutdoorsGroup.Models;

namespace OutdoorsGroup.Interfaces
{
    public interface IDashboardRepository
    {
        Task<List<Race>> GetAllUserRaces();
        Task<List<Club>> GetAllUserClubs();
      
    }
}
