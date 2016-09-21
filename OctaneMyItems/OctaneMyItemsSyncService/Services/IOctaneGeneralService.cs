using System.Net;
using System.Threading.Tasks;
using OctaneMyItemsSyncService.Models;

namespace OctaneMyItemsSyncService.Services
{
  public interface IOctaneGeneralService
  {
    User CurrentUser { get; }

    Task<Cookie> Login(string user, string password);
    Task<Cookie> Login(Cookie cookie);
    Task Logout();

    Task<SharedSpaces> GetSharedSpaces();
    Task<Workspaces> GetWorkspaces(int sharespaceId);
    
    Task SetDefaultSpace(SharedSpace sharespace, Workspace workspace);
  }
}