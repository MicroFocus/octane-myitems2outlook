using System.Windows.Forms;
using System.Threading.Tasks;
using OctaneMyItemsSyncService.Services;

namespace OctaneMyItems
{
  public class Configuration
  {
    private string m_serverUrl;
    private string m_userName;
    private string m_password;
    private int m_sharedSpaceId;
    private string m_workSpace;
    private OctaneMyItemsSyncService.Services.OctaneService m_service;

    private bool m_initialized = false;

    public Configuration()
    {

    }
    public void Getconfiguration()
    {
      ConfigurationForm form = new ConfigurationForm();
      
      form.ShowDialog();
      if (form.DialogResult == DialogResult.OK)
      {
        m_serverUrl = form.ServerUrl;
        m_userName = form.User;
        m_password = form.Password;
        m_sharedSpaceId = form.SharedSpaceId;
        m_workSpace = form.WorkSpace;
        m_service = form.OctaneService;
        m_initialized = true;
      }
    }
    public bool IsInitialized
    {
      get { return m_initialized; }
    }
    public int SharedSpaceId
    {
      get
      {
        return m_sharedSpaceId;
      }
    }
    public string WorkSpaceName
    {
      get { return m_workSpace; }
    }

    public OctaneService OctaneService
    {
get { return m_service; }
    }

  }
}
