using System.Threading.Tasks;
using OctaneMyItemsSyncService.Models;

namespace OctaneMyItemsSyncService.Services
{
  public interface IOctaneGeneralService
  {
    User CurrentUser { get; }

    Task Login(string user, string password);
    Task Logout();

    Task<SharedSpaces> GetSharedSpaces();
    Task<Workspaces> GetWorkspaces(int sharespaceId);
    
    Task SetDefaultSpace(SharedSpace sharespace, Workspace workspace);
  }
}