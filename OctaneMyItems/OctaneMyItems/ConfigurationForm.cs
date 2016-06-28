using System;
using System.Windows.Forms;

namespace OctaneMyItems
{
  public partial class ConfigurationForm : Form
  {
    public string ServerUrl
    {
      get{return m_serverUrl.Text;}
    }
    public string User
    {
      get { return m_userName.Text; }
    }
    public string Password
    {
      get { return m_password.Text; } 
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
    }

    public string WorkSpace
    {
      get { return m_workSpaces.Text; }
    }
    public ConfigurationForm()
    {
      InitializeComponent();
    }

    private void buttonTestConnection_Click(object sender, EventArgs e)
    {

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
