using System.Windows.Forms;
using System.Linq;
using System.Threading.Tasks;
using OctaneMyItemsSyncService.Models;
using OctaneMyItemsSyncService.Services;
using Microsoft.Office.Interop.Outlook;
using System.Runtime.InteropServices;
namespace OctaneMyItems
{
  public class Configuration
  {
    private string m_serverUrl;
    private string m_userName;
    private string m_password;
    private int m_sharedSpaceId;
    private string m_workSpaceName;
    private int m_workSpaceId;
    private OctaneMyItemsSyncService.Services.OctaneService m_octaneService;
    private Microsoft.Office.Interop.Outlook.Application m_application;
    private bool m_initialized = false;

    private const string m_storeageName = "OctaneService";
    public Configuration(Microsoft.Office.Interop.Outlook.Application app)
    {
      m_application = app;
    }
    public void Getconfiguration()
    {
      if(!LoadConfiguration())
      { 
      ConfigurationForm form = new ConfigurationForm();
      
      form.ShowDialog();
        if (form.DialogResult == DialogResult.OK)
        {
          m_serverUrl = form.ServerUrl;
          m_userName = form.User;
          m_password = form.Password;
          m_sharedSpaceId = form.SharedSpaceId;
          m_workSpaceName = form.WorkSpace;
          m_workSpaceId = form.WorkspaceId;
          m_octaneService = form.OctaneService;
          m_initialized = true;
        }
        SaveConfiguration();
      }
    }
    private bool LoadConfiguration()
    {
      MAPIFolder folder = m_application.Session.GetDefaultFolder(OlDefaultFolders.olFolderInbox);
      try
      {
        StorageItem item = folder.GetStorage(m_storeageName, OlStorageIdentifierType.olIdentifyBySubject);
        if (item.Size > 0)
        {
          UserProperty property;
          property = item.UserProperties.Find("ServerUrl");
          m_serverUrl = property.Value;
          property = item.UserProperties.Find("User");
          m_userName = property.Value;

          property = item.UserProperties.Find("Password");
          m_password = property.Value;
          property = item.UserProperties.Find("SharedSpaceId");
          m_sharedSpaceId = property.Value;
          property = item.UserProperties.Find("WorkSpaceId");
          m_workSpaceId = property.Value;

          ConnectToServer();
          m_initialized = true;
          return true;
        }
      }
      catch (COMException ex)
      {
      }
      
      return false;

    }
    private void ConnectToServer()
    {

      m_octaneService = new OctaneService(m_serverUrl);
      m_octaneService.Login(m_userName, m_password).Wait();
      m_octaneService.SetDefaultSharespace(m_sharedSpaceId);
      var workspaces =  m_octaneService.GetWorkspace().Result;
      m_octaneService.SetDefaultWorkspace(workspaces.data.First(x => x.id == m_workSpaceId)).Wait();

    }
    private void SaveConfiguration()
    {
      MAPIFolder folder = m_application.Session.GetDefaultFolder(OlDefaultFolders.olFolderInbox);
      
      StorageItem item = folder.GetStorage(m_storeageName, OlStorageIdentifierType.olIdentifyBySubject);
      // new item
      UserProperty property;
      if (item.Size == 0)
      {
        property = item.UserProperties.Add("ServerUrl", OlUserPropertyType.olText);
        property.Value = m_serverUrl;
        property = item.UserProperties.Add("User", OlUserPropertyType.olText);
        property.Value = m_userName;

        property = item.UserProperties.Add("Password", OlUserPropertyType.olText);
        property.Value = m_password;
        property = item.UserProperties.Add("SharedSpaceId", OlUserPropertyType.olInteger);
        property.Value = m_sharedSpaceId;
        property = item.UserProperties.Add("WorkSpaceId", OlUserPropertyType.olInteger);
        property.Value = m_workSpaceId;
      }
      else
      {
        property = item.UserProperties.Find("ServerUrl");
        property.Value = m_serverUrl;
        property = item.UserProperties.Find("User");
        property.Value = m_userName;

        property = item.UserProperties.Find("Password");
        property.Value = m_password;
        property = item.UserProperties.Find("SharedSpaceId");
        property.Value = m_sharedSpaceId;
        property = item.UserProperties.Find("WorkSpaceId");
        property.Value = m_workSpaceId;
      }
      // save
      item.Save();
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
      get { return m_workSpaceName; }
    }

    public OctaneService OctaneService
    {
get { return m_octaneService; }
    }

  }
}
