using Microsoft.Office.Interop.Outlook;
using OctaneMyItemsSyncService.Services;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OctaneMyItems
{
  public class Configuration
  {
    #region Private Fileds

    private string m_serverUrl;
    private string m_userName;
    private string m_password;
    private int m_sharedspaceId;
    private int m_workspaceId;

    private OctaneService m_octaneService;
    private Microsoft.Office.Interop.Outlook.Application m_application;
    private bool m_initialized;

    private const string m_storeageName = "OctaneService";

    #endregion

    #region Public Methods

    public Configuration(Microsoft.Office.Interop.Outlook.Application app)
    {
      m_application = app;

      GetConfiguration();
    }

    public async Task GetConfiguration()
    {
      LoadConfiguration();

      if (await ConnectToServer())
        m_initialized = true;
      else
        ShowConfigurationForm();
    }

    public void ShowConfiguration()
    {
      LoadConfiguration();
      ShowConfigurationForm();
    }

    #endregion

    #region Public Properties

    public OctaneService OctaneService
    {
      get { return m_octaneService; }
    }

    public bool IsInitialized
    {
      get { return m_initialized; }
    }

    public string ServerUrl
    {
      get { return m_serverUrl; }
    }

    public int SharedspaceId
    {
      get { return m_sharedspaceId; }
    }

    public int WorkspaceId
    {
      get { return m_workspaceId; }
    }

    #endregion

    #region Private Methods

    private void ShowConfigurationForm()
    {
      ConfigurationForm form = new ConfigurationForm(m_serverUrl, m_userName, m_password, m_sharedspaceId, m_workspaceId);
      form.ShowDialog();
      if (form.DialogResult == DialogResult.OK)
      {
        if (form.ServerUrl[form.ServerUrl.Length - 1] == '\\' || form.ServerUrl[form.ServerUrl.Length - 1] == '/')
          m_serverUrl = form.ServerUrl.Substring(0, m_serverUrl.Length - 1);
        else
          m_serverUrl = form.ServerUrl;
        m_userName = form.User;
        m_password = form.Password;
        m_sharedspaceId = form.SharedpaceId.Value;
        m_workspaceId = form.WorkspaceId.Value;
        m_octaneService = form.OctaneService;

        m_initialized = true;

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
          m_sharedspaceId = property.Value;
          property = item.UserProperties.Find("WorkSpaceId");
          m_workspaceId = property.Value;
        }
        return true;
      }
      catch (System.Exception)
      {
      }
      return false;
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
        property.Value = m_sharedspaceId;
        property = item.UserProperties.Add("WorkSpaceId", OlUserPropertyType.olInteger);
        property.Value = m_workspaceId;
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
        property.Value = m_sharedspaceId;
        property = item.UserProperties.Find("WorkSpaceId");
        property.Value = m_workspaceId;
      }
      // save
      item.Save();
    }

    private async Task<bool> ConnectToServer()
    {
      try
      {
        m_octaneService = new OctaneService(m_serverUrl);
        m_octaneService.Login(m_userName, m_password).Wait();
        var sharedSpaces = await m_octaneService.GetSharedSpaces();
        var sharedspace = sharedSpaces.data.FirstOrDefault(x => x.id == m_sharedspaceId);
        var workspaces = await m_octaneService.GetWorkspaces(sharedspace.id.Value);
        await m_octaneService.SetDefaultSpace(sharedspace, workspaces.data.First(x => x.id == m_workspaceId));
        return true;
      }
      catch (System.Exception)
      {
      }
      return false;
    }

    #endregion
  }
}
