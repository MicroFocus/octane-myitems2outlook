using System;
using System.Windows.Forms;
using System.Threading.Tasks;
using OctaneMyItemsSyncService.Services;

namespace OctaneMyItems
{
  public partial class ConfigurationForm : Form
  {
    private OctaneMyItemsSyncService.Services.OctaneService m_octaneService;
    public string ServerUrl
    {
      get{return m_serverUrl.Text;}
      set { m_serverUrl.Text = value; }
    }
    public string User
    {
      get { return m_userName.Text; }
      set { m_userName.Text = value; }
    }
    public string Password
    {
      get { return m_password.Text; } 
      set { m_password.Text = value; }
    }
    public int SharedSpaceId
    {
      get
      {
        int id;
        if (int.TryParse(m_sharedSpaceId.Text, out id))
        {
          return id;
        }
        return 0;
      }
set { m_sharedSpaceId.Text = value.ToString(); }
    }

    public string WorkSpace
    {
      get { return m_workSpaces.Text; }
    }
    public OctaneService OctaneService
{
    get { return m_octaneService; }
    }
    public ConfigurationForm()
    {
      InitializeComponent();
      ServerUrl = "https://hackathon.almoctane.com";
      User = "jing-chun.xia@hpe.com";
      Password = "Mission-Possible";
      SharedSpaceId = 1001;
      m_octaneService = null;
    }

    private async void buttonTestConnection_Click(object sender, EventArgs e)
    {
      //    Task < OctaneMyItemsSyncService.Models.Workspace[] > workspacesTask = TestConnection();

      m_octaneService = new OctaneService(ServerUrl);
      await m_octaneService.Login(User, Password);
      m_octaneService.SetDefaultSharespace(SharedSpaceId);
      var workspaces = await m_octaneService.GetWorkspace();

    //  OctaneMyItemsSyncService.Models.Workspace[] workspaces = workspacesTask.Result;
      foreach (OctaneMyItemsSyncService.Models.Workspace workspace in workspaces.data)
{
        m_workSpaces.Items.Add(workspace.name);
      }
      m_workSpaces.Focus();
      m_workSpaces.SelectedIndex = 0;
      
    }

    private async Task<OctaneMyItemsSyncService.Models.Workspace[]> TestConnection()
{
      m_octaneService = new OctaneService(ServerUrl);
      await m_octaneService.Login(User, Password);
      m_octaneService.SetDefaultSharespace(SharedSpaceId);
      var workspaces = await m_octaneService.GetWorkspace();
       return workspaces.data;
    }

    private void buttonSharedSpace_Click(object sender, EventArgs e)
    {

    }

    private void buttonOK_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void buttonCancel_Click(object sender, EventArgs e)
    {
      this.Close();
    }
  }
}
