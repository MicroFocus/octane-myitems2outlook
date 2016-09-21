using OctaneMyItemsSyncService.Models;
using OctaneMyItemsSyncService.Services;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Net;
namespace OctaneMyItems
{
  public partial class ConfigurationForm : Form
  {
    #region private fields
    private Cookie m_cookie;
    #endregion
    #region Public Properties

    public string ServerUrl { get { return m_tbServerUrl.Text; } }
    public string User { get { return m_tbUserName.Text; } }
    private string Password { get { return m_tbPassword.Text; } }
    public int? SharedpaceId { get; private set; }
    public int? WorkspaceId { get; private set; }

    public Cookie LoginCookie
    {
      get { return m_cookie; }
      set { m_cookie = value; }
    }

    public OctaneService OctaneService { get; private set; }

    #endregion

    #region Constructor

    public ConfigurationForm(string defaultServerUrl, string defaultUser,  int defaultSharedspaceId, int defaultWorkspaceId)
    {
      InitializeComponent();

      m_tbServerUrl.Text = defaultServerUrl;
      m_tbUserName.Text = defaultUser;
      SharedpaceId = defaultSharedspaceId;
      WorkspaceId = defaultWorkspaceId;
    }

    #endregion

    #region Private Methods

    private void m_tbServerUrl_TextChanged(object sender, EventArgs e)
    {
      if (!string.IsNullOrEmpty(m_tbServerUrl.Text))
        m_btnAuthenticate.Enabled = true;
      else
        m_btnAuthenticate.Enabled = false;
    }

    private async void m_btnAuthenticate_Click(object sender, EventArgs e)
    {
      m_btnAuthenticate.Enabled = false;
      m_cbSharedspaces.Enabled = false;
      m_cbWorkspaces.Enabled = false;
      m_btnOK.Enabled = false;
      
      m_cbSharedspaces.Items.Clear();
      m_cbWorkspaces.Items.Clear();

      try
      {
        OctaneService = new OctaneService(ServerUrl);
        bool loginWithCookie = false;
        if(m_cookie != null)
        {
          loginWithCookie = true;
          try
          {
            await OctaneService.Login(m_cookie);
          }
          catch(Exception ex)
          {
            m_cookie = null;
            loginWithCookie = false;
            MessageBox.Show(ex.Message);
          }
        }

        if (!loginWithCookie)
        {
          m_cookie = await OctaneService.Login(User, Password);
        }
        
        var sharedSpaces = await OctaneService.GetSharedSpaces();
        if (sharedSpaces.total_count <= 0)
        {
          MessageBox.Show("There is no Sharedspaces");
          return;
        }

        m_cbSharedspaces.Items.AddRange(sharedSpaces.data);

        //Set default Sharedspace
        var defaultSharedspace = sharedSpaces.data[0];
        if (SharedpaceId.HasValue)
        {
          var temp = sharedSpaces.data.FirstOrDefault(x => x.id == SharedpaceId);
          if (temp != null)
            defaultSharedspace = temp;
        }
        m_cbSharedspaces.SelectedItem = defaultSharedspace;

        m_cbSharedspaces.Enabled = true;
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }
      finally
      {
        m_btnAuthenticate.Enabled = true;
      }
    }

    private async void m_cbSharedpaces_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (m_cbSharedspaces.SelectedIndex == -1) return;

      try
      {
        var sharedSpace = m_cbSharedspaces.SelectedItem as SharedSpace;
        SharedpaceId = sharedSpace.id;

        var workspaces = await OctaneService.GetWorkspaces(SharedpaceId.Value);
        if (workspaces.total_count <= 0)
        {
          MessageBox.Show("There is no Workspaces");
          return;
        }

        m_cbWorkspaces.Items.Clear();
        m_cbWorkspaces.Items.AddRange(workspaces.data);

        //Set feault Worksapce
        var defaultWorkspace = workspaces.data[0];
        if (WorkspaceId.HasValue)
        {
          var temp = workspaces.data.FirstOrDefault(x => x.id == WorkspaceId);
          if (temp != null)
            defaultWorkspace = temp;
        }
        m_cbWorkspaces.SelectedItem = defaultWorkspace;

        m_cbWorkspaces.Enabled = true;
        m_btnOK.Enabled = true;
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }
    }

    private async void m_cbWorkspaces_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (m_cbWorkspaces.SelectedIndex == -1) return;

      try
      {
        var workspace = m_cbWorkspaces.SelectedItem as Workspace;
        await OctaneService.SetDefaultSpace(m_cbSharedspaces.SelectedItem as SharedSpace, workspace);
        WorkspaceId = workspace.id;
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }
    }

    private void m_btnOK_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.OK;
      Close();
    }

    private void m_btnCancel_Click(object sender, EventArgs e)
    {
      Close();
    }

    #endregion
  }
}
