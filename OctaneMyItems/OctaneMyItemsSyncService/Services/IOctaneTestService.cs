using OctaneMyItemsSyncService.Models;
using System.Threading.Tasks;

namespace OctaneMyItemsSyncService.Services
{
  public interface IOctaneTestService
  {
    Task<Test> GetTest(int id, bool byCurrentOwner);
    Task<Tests> GetTests(string parameters = null, bool indetail = false);
    Task<Tests> GetMyTests();
    Task<Test> GetMyTest(int id);
    Task<Comments> GetTestComments(int id);
    Task<TestScript> GetTestScript(int test_id);
  }
}