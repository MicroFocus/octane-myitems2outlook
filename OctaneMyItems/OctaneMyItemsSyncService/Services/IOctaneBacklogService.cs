using OctaneMyItemsSyncService.Models;
using System.Threading.Tasks;

namespace OctaneMyItemsSyncService.Services
{
  public interface IOctaneBacklogService
  {
    Task<Backlog> GetBacklog(int id, bool byCurrentOwner);
    Task<Backlogs> GetBacklogs(string parameters = null, bool indetail = false);
    Task<Backlogs> GetMyBacklogs();
    Task<Comments> GetBacklogComments(int id);
  }
}
