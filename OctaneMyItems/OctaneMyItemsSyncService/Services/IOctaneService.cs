using System.Threading.Tasks;
using OctaneMyItemsSyncService.Models;

namespace OctaneMyItemsSyncService.Services
{
  public interface IOctaneService
  {
    Task Login(string user, string password);
    Task Logout();

    Task<SharedSpaces> GetSharedSpaces();
    Task<Workspaces> GetWorkspaces(int sharespaceId);
    
    Task SetDefaultSpace(SharedSpace sharespace, Workspace workspace);

    Task<Backlog> GetBacklog(int id);
    Task<Backlogs> GetBacklogs(string parameters = null, bool indetail = false);
    Task<Backlogs> GetMyBacklogs();
    Task<Comments> GetBacklogComments(int id);

    Task<Run> GetRun(int id);
    Task<Runs> GetRuns(string parameters = null, bool indetail = false);
    Task<Runs> GetMyRuns();
    Task<Comments> GetRunComments(int id);
    Task<Run_Steps> GetRunSteps(int run_id);

    Task<Test> GetTest(int id);
    Task<Tests> GetTests(string parameters = null, bool indetail = false);
    Task<Tests> GetMyTests();
    Task<Comments> GetTestComments(int id);
    Task<TestScript> GetTestScript(int test_id);
  }
}