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
    private string m_token;
    private int m_sharedspaceId;
    private int m_workspaceId;

    private IOctaneService m_octaneService;
    private Microsoft.Office.Interop.Outlook.Application m_application;
    private bool m_initialized;

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

    public IOctaneService OctaneService
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
      ConfigurationForm form = new ConfigurationForm(m_serverUrl, m_userName, m_sharedspaceId, m_workspaceId);
      form.ShowDialog();
      if (form.DialogResult == DialogResult.OK)
      {
        m_serverUrl = form.ServerUrl;
        m_userName = form.User;
        m_token = form.Token;
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
        StorageItem item = folder.GetStorage(Constants.OctaneStoreageName, OlStorageIdentifierType.olIdentifyBySubject);
        if (item.Size > 0)
        {
          m_serverUrl = item.UserProperties.Find(Constants.ServerUrl)?.Value;
          m_userName = item.UserProperties.Find(Constants.User)?.Value;
          m_token = item.UserProperties.Find(Constants.Token)?.Value;

          m_sharedspaceId = item.UserProperties.Find(Constants.SharedSpaceId)?.Value;
          m_workspaceId = item.UserProperties.Find(Constants.WorkSpaceId)?.Value;
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

      StorageItem item = folder.GetStorage(Constants.OctaneStoreageName, OlStorageIdentifierType.olIdentifyBySubject);
      // new item
      SafeAddProperty(item, Constants.ServerUrl, m_serverUrl);
      SafeAddProperty(item, Constants.User, m_userName);
      SafeAddProperty(item, Constants.Token, m_token);
      SafeAddProperty(item, Constants.SharedSpaceId, m_sharedspaceId.ToString());
      SafeAddProperty(item, Constants.WorkSpaceId, m_workspaceId.ToString());
      // save
      item.Save();
    }

    private void SafeAddProperty(StorageItem item, string name, string value)
    {
      var property = item.UserProperties.Find(name, OlUserPropertyType.olText);
      if (property == null)
        property = item.UserProperties.Add(name, OlUserPropertyType.olText);
      property.Value = value;      
    }

    /// <summary>
    /// connect to server with stored cookie
    /// </summary>
    /// <returns></returns>
    private async Task<bool> ConnectToServer()
    {
      if (string.IsNullOrEmpty(m_token))
        return false;

      try
      {
        m_octaneService = new OctaneService(m_serverUrl);
        
        await m_octaneService.TryReLogin(m_userName, m_token);

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
