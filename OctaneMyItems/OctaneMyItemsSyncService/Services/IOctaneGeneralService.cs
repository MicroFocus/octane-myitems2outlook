using OctaneMyItemsSyncService.Models;
using System.Threading.Tasks;

namespace OctaneMyItemsSyncService.Services
{
  public interface IOctaneGeneralService
  {
    User CurrentUser { get; }

    Task<string> Login(string user, string password);
    Task TryReLogin(string user, string token);
    Task Logout();

    Task<SharedSpaces> GetSharedSpaces();
    Task<Workspaces> GetWorkspaces(int sharespaceId);
    
    Task SetDefaultSpace(SharedSpace sharespace, Workspace workspace);
  }
}