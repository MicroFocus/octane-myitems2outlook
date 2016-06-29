using System;
using System.Windows.Forms;
using System.Linq;
using OctaneMyItemsSyncService.Services;

namespace OctaneMyItems
{
  public partial class ConfigurationForm : Form
  {

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
    public ConfigurationForm()
    {
      InitializeComponent();
      ServerUrl = "https://hackathon.almoctane.com";
      User = "jing-chun.xia@hpe.com";
      Password = "Mission-Possible";
    }

    private async void buttonTestConnection_Click(object sender, EventArgs e)
    {
      OctaneService octaneService = new OctaneService(ServerUrl);
      await octaneService.Login(User,Password );
      octaneService.SetDefaultSharespace(SharedSpaceId);
      var workspaces = await octaneService.GetWorkspace();
 /*     foreach(var workspace in workspaces)
{
        m_workSpaces.Items.Add(workspace);
      }*/
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
