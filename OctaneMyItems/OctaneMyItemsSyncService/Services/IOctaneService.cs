namespace OctaneMyItemsSyncService.Services
{
  public interface IOctaneService:
    IOctaneGeneralService, IOctaneBacklogService, IOctaneTestService, IOctaneRunService
  {
  }
}