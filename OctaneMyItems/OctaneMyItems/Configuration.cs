using Microsoft.Office.Interop.Outlook;
using OctaneMyItemsSyncService.Services;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace OctaneMyItems
{
  public class Configuration
  {
    #region Private Fileds

    private string m_serverUrl;
    private string m_userName;
    private int m_sharedspaceId;
    private int m_workspaceId;
    private Cookie m_cookie;

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
      ConfigurationForm form = new ConfigurationForm(m_serverUrl, m_userName, m_sharedspaceId, m_workspaceId);
      if(m_cookie != null)
      {
        form.LoginCookie = m_cookie;
      }
      form.ShowDialog();
      if (form.DialogResult == DialogResult.OK)
      {

        if (form.ServerUrl[form.ServerUrl.Length - 1] == '\\' || form.ServerUrl[form.ServerUrl.Length - 1] == '/')
          m_serverUrl = form.ServerUrl.Substring(0, m_serverUrl.Length - 1);
        else
          m_serverUrl = form.ServerUrl;
        m_userName = form.User;
        m_cookie = form.LoginCookie;
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
          if (property != null)
          {
            m_serverUrl = property.Value;
          }
          property = item.UserProperties.Find("User");
          if (property != null)
          {
            m_userName = property.Value;
          }

          
          string cookieName, cookieValue, cookiePath, cookieDomain;
          cookieName = cookieValue = cookiePath = cookieDomain = string.Empty;

          property = item.UserProperties.Find("CookieName");
          if (property != null)
          {
            cookieName = property.Value;
          }
          property = item.UserProperties.Find("CookieValue");
          if (property != null)
          {
            cookieValue = property.Value;
          }
          property = item.UserProperties.Find("CookiePath");
          if (property != null)
          {
            cookiePath = property.Value;
          }
          property = item.UserProperties.Find("CookieDomain");
          if (property != null)
          {
            cookieDomain = property.Value;
          }
          // construct cookie
          if (!string.IsNullOrWhiteSpace(cookieName))
          {
            m_cookie = new Cookie(cookieName, cookieValue, cookiePath, cookieDomain);
          }
          property = item.UserProperties.Find("SharedSpaceId");
          if (property != null)
          {
            m_sharedspaceId = property.Value;
          }
          property = item.UserProperties.Find("WorkSpaceId");
          if (property != null)
          {
            m_workspaceId = property.Value;
          }
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
      SafeAddProperty(item,"ServerUrl", m_serverUrl);
      SafeAddProperty(item, "User", m_userName);
      SafeAddProperty(item, "CookieName", m_cookie.Name);        
      SafeAddProperty(item, "CookieValue", m_cookie.Value);
      SafeAddProperty(item, "CookiePath", m_cookie.Path);
      SafeAddProperty(item, "CookieDomain", m_cookie.Domain);
      SafeAddProperty(item, "SharedSpaceId", m_sharedspaceId.ToString());
      SafeAddProperty(item, "WorkSpaceId", m_workspaceId.ToString());
      // save
      item.Save();
    }

    private void SafeAddProperty(StorageItem item, string name, string value)
    {
      UserProperty property = item.UserProperties.Find(name, OlUserPropertyType.olText);
      if (property == null)
      {
        property = item.UserProperties.Add(name, OlUserPropertyType.olText);
      }
      property.Value = value;      
    }

    /// <summary>
    /// connect to server with stored cookie
    /// </summary>
    /// <returns></returns>
    private async Task<bool> ConnectToServer()
    {
      if(m_cookie == null)
      {
        return false;
      }

      try
      {
        m_octaneService = new OctaneService(m_serverUrl);

        // refresh cookie
        m_cookie = await m_octaneService.Login(m_cookie);

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
