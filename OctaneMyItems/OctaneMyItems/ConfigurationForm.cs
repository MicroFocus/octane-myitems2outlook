using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading.Tasks;
using OctaneMyItemsSyncService.Services;
using OctaneMyItemsSyncService.Models;

namespace OctaneMyItems
{
  public partial class ConfigurationForm : Form
  {
    private OctaneMyItemsSyncService.Services.OctaneService m_octaneService;
    private Dictionary<int,Workspace> m_workspaces;
    private bool m_isDirty = false;

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

    public string WorkSpaceName
    {
      get { return m_workspacesComboBox.Text; }
      set { m_workspacesComboBox.Items.Add(value);
        m_workspacesComboBox.SelectedIndex = 0 ;
}
    }
    public int WorkspaceId
    {
      get
      {
        int id = 0;
        Workspace workspace;
        if (m_workspaces.TryGetValue(m_workspacesComboBox.SelectedIndex, out workspace))
        {
          id = (int)workspace.id;
        }
        return id;
      }
      
    }
    public OctaneService OctaneService
{
    get { return m_octaneService; }
    }
    public ConfigurationForm()
    {
      InitializeComponent();
      m_workspaces = new Dictionary<int,Workspace>();
      //ServerUrl = "https://hackathon.almoctane.com";
      //User = "jing-chun.xia@hpe.com";
      //Password = "Mission-Possible";
      //SharedSpaceId = 1001;
      m_octaneService = null;
    }

    private async void buttonTestConnection_Click(object sender, EventArgs e)
    {
      //    Task < OctaneMyItemsSyncService.Models.Workspace[] > workspacesTask = TestConnection();
      m_workspacesComboBox.Items.Clear();
            m_octaneService = new OctaneService(ServerUrl);
      await m_octaneService.Login(User, Password);
      m_octaneService.SetDefaultSharespace(SharedSpaceId);
      var workspaces = await m_octaneService.GetWorkspace();

    //  OctaneMyItemsSyncService.Models.Workspace[] workspaces = workspacesTask.Result;
      foreach (OctaneMyItemsSyncService.Models.Workspace workspace in workspaces.data)
      {
        int i = m_workspacesComboBox.Items.Add(workspace.name);
        m_workspaces.Add(i, workspace);
      }
      m_workspacesComboBox.Focus();
      m_workspacesComboBox.SelectedIndex = 0;
      m_isDirty = true;
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

    private async void buttonOK_Click(object sender, EventArgs e)
    {
      if (m_isDirty)
      {
        Workspace workspace;
        if (m_workspaces.TryGetValue(m_workspacesComboBox.SelectedIndex, out workspace))
        {
          await m_octaneService.SetDefaultWorkspace(workspace);
        }
        else
        {
          MessageBox.Show("no default workspace is selected");
        }
        this.DialogResult = DialogResult.OK;
      }
      else
      {
        this.DialogResult = DialogResult.Cancel;
      }
      this.Close();
    }

    private void buttonCancel_Click(object sender, EventArgs e)
    {
      
      this.Close();
    }
  }
}
