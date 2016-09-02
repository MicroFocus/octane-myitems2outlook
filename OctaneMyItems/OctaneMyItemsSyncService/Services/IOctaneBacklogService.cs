using OctaneMyItemsSyncService.Models;
using System.Threading.Tasks;

namespace OctaneMyItemsSyncService.Services
{
  public interface IOctaneBacklogService
  {
    Task<Backlog> GetBacklog(int id, bool byCurrentOwner);
    Task<Backlogs> GetBacklogs(string parameters = null, bool indetail = false);
    Task<Backlogs> GetMyBacklogs();
    Task<Backlog> GetMyBacklog(int id);
    Task<Comments> GetBacklogComments(int id);
  }
}