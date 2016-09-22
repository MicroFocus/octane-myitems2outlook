﻿using OctaneMyItemsSyncService.Models;
using OctaneMyItemsSyncService.Services;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace OctaneMyItems
{
  public partial class ConfigurationForm : Form
  {
    #region Private Fileds
    
    private Point? m_startLocation;

    private readonly Color EnabledBackColor = Color.FromArgb(1, 169, 130);
    private readonly Color EnabledForeColor = Color.White;
    private readonly Color DisabledBackColor = Color.FromArgb(228, 228, 228);
    private readonly Color DisabledForeColor = Color.FromArgb(191, 191, 191); 

    #endregion

    #region Public Properties

    public string ServerUrl { get { return m_tbServerUrl.Text; } }
    public string User { get { return m_tbUserName.Text; } }
    public string Token { get; private set; }
    public int? SharedpaceId { get; private set; }
    public int? WorkspaceId { get; private set; }
    
    public IOctaneService OctaneService { get; private set; }

    #endregion

    #region Constructor

    public ConfigurationForm(string defaultServerUrl, string defaultUser,  int defaultSharedspaceId, int defaultWorkspaceId)
    {
      InitializeComponent();

      m_tbServerUrl.Text = defaultServerUrl;
      m_tbUserName.Text = defaultUser;
      SharedpaceId = defaultSharedspaceId;
      WorkspaceId = defaultWorkspaceId;

      SetButtonState(m_btnOK, false);

      KeyPreview = true;
    }

    #endregion

    #region Event Handlers

    private void m_tbServerUrl_TextChanged(object sender, EventArgs e)
    {
      if (!string.IsNullOrEmpty(m_tbServerUrl.Text))
        SetButtonState(m_btnAuthenticate, true);
      else
        SetButtonState(m_btnAuthenticate, false);
    }

    private async void m_btnAuthenticate_Click(object sender, EventArgs e)
    {
      SetButtonState(m_btnAuthenticate, false);
      SetButtonState(m_btnOK, false);
      m_cbSharedspaces.Enabled = false;
      m_cbWorkspaces.Enabled = false;

      m_cbSharedspaces.Items.Clear();
      m_cbWorkspaces.Items.Clear();

      try
      {
        OctaneService = new OctaneService(m_tbServerUrl.Text);
        Token = await OctaneService.Login(m_tbUserName.Text, m_tbPassword.Text);

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
        SetButtonState(m_btnAuthenticate, true);
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
        SetButtonState(m_btnOK, true);
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
    
    private void m_mainPanel_MouseDown(object sender, MouseEventArgs e)
    {
      m_startLocation = e.Location;
    }

    private void m_mainPanel_MouseMove(object sender, MouseEventArgs e)
    {
      if (m_startLocation.HasValue)
      {
        var currentLocation = e.Location;
        Location = new Point(
          Location.X + currentLocation.X - m_startLocation.Value.X,
          Location.Y + currentLocation.Y - m_startLocation.Value.Y);
      }
    }

    private void m_mainPanel_MouseUp(object sender, MouseEventArgs e)
    {
      m_startLocation = null;
    }

    #endregion

    #region Private Methods

    private void SetButtonState(Button button, bool isEnabled)
    {
      if (isEnabled)
      {
        button.BackColor = EnabledBackColor;
        button.ForeColor = EnabledForeColor;
        button.Enabled = true;
      }
      else
      {
        button.BackColor = DisabledBackColor;
        button.ForeColor = DisabledForeColor;
        button.Enabled = false;
      }
    } 

    #endregion

    #region Overrides

    protected override CreateParams CreateParams
    {
      get
      {
        var cp = base.CreateParams;
        cp.ClassStyle |= 0x00020000;
        return cp;
      }
    }

    protected override void OnKeyDown(KeyEventArgs e)
    {
      base.OnKeyDown(e);
      if (e.KeyCode == Keys.Enter)
      {
        if (m_btnOK.Enabled) m_btnOK_Click(null, null);
        else if (m_btnAuthenticate.Enabled) m_btnAuthenticate_Click(null, null);
      }
    } 

    #endregion
  }
}
