using OctaneMyItemsSyncService.Models;
using System.Threading.Tasks;

namespace OctaneMyItemsSyncService.Services
{
  public interface IOctaneRunService
  {
    Task<Run> GetRun(int id, bool byCurrentOwner);
    Task<Runs> GetRuns(string parameters = null, bool indetail = false);
    Task<Runs> GetMyRuns();
    Task<Comments> GetRunComments(int id);
    Task<Run_Steps> GetRunSteps(int run_id);
  }
}
