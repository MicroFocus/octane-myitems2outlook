﻿namespace OctaneMyItems
{
  partial class ConfigurationForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.label1 = new System.Windows.Forms.Label();
      this.m_serverUrl = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.m_userName = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.m_password = new System.Windows.Forms.TextBox();
      this.buttonTestConnection = new System.Windows.Forms.Button();
      this.label4 = new System.Windows.Forms.Label();
      this.m_sharedSpaceId = new System.Windows.Forms.TextBox();
      this.buttonOK = new System.Windows.Forms.Button();
      this.buttonCancel = new System.Windows.Forms.Button();
      this.buttonSharedSpace = new System.Windows.Forms.Button();
      this.m_workSpaces = new System.Windows.Forms.ComboBox();
      this.label5 = new System.Windows.Forms.Label();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(18, 35);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(76, 17);
      this.label1.TabIndex = 0;
      this.label1.Text = "Server Url:";
      // 
      // m_serverUrl
      // 
      this.m_serverUrl.Location = new System.Drawing.Point(136, 30);
      this.m_serverUrl.Name = "m_serverUrl";
      this.m_serverUrl.Size = new System.Drawing.Size(341, 22);
      this.m_serverUrl.TabIndex = 1;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(18, 73);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(87, 17);
      this.label2.TabIndex = 2;
      this.label2.Text = "User Name: ";
      // 
      // m_userName
      // 
      this.m_userName.Location = new System.Drawing.Point(136, 73);
      this.m_userName.Name = "m_userName";
      this.m_userName.Size = new System.Drawing.Size(181, 22);
      this.m_userName.TabIndex = 3;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(18, 116);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(73, 17);
      this.label3.TabIndex = 4;
      this.label3.Text = "Password:";
      // 
      // m_password
      // 
      this.m_password.Location = new System.Drawing.Point(136, 116);
      this.m_password.Name = "m_password";
      this.m_password.PasswordChar = '*';
      this.m_password.Size = new System.Drawing.Size(181, 22);
      this.m_password.TabIndex = 5;
      this.m_password.UseSystemPasswordChar = true;
      // 
      // buttonTestConnection
      // 
      this.buttonTestConnection.Location = new System.Drawing.Point(308, 157);
      this.buttonTestConnection.Name = "buttonTestConnection";
      this.buttonTestConnection.Size = new System.Drawing.Size(145, 30);
      this.buttonTestConnection.TabIndex = 6;
      this.buttonTestConnection.Text = "Test Connection";
      this.buttonTestConnection.UseVisualStyleBackColor = true;
      this.buttonTestConnection.Click += new System.EventHandler(this.buttonTestConnection_Click);
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(14, 32);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(121, 17);
      this.label4.TabIndex = 7;
      this.label4.Text = "Shared Space Id: ";
      // 
      // m_sharedSpaceId
      // 
      this.m_sharedSpaceId.Location = new System.Drawing.Point(132, 32);
      this.m_sharedSpaceId.Name = "m_sharedSpaceId";
      this.m_sharedSpaceId.Size = new System.Drawing.Size(125, 22);
      this.m_sharedSpaceId.TabIndex = 8;
      // 
      // buttonOK
      // 
      this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.buttonOK.Location = new System.Drawing.Point(277, 412);
      this.buttonOK.Name = "buttonOK";
      this.buttonOK.Size = new System.Drawing.Size(75, 23);
      this.buttonOK.TabIndex = 9;
      this.buttonOK.Text = "OK";
      this.buttonOK.UseVisualStyleBackColor = true;
      this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
      // 
      // buttonCancel
      // 
      this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.buttonCancel.Location = new System.Drawing.Point(390, 412);
      this.buttonCancel.Name = "buttonCancel";
      this.buttonCancel.Size = new System.Drawing.Size(75, 23);
      this.buttonCancel.TabIndex = 10;
      this.buttonCancel.Text = "Cancel";
      this.buttonCancel.UseVisualStyleBackColor = true;
      this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
      // 
      // buttonSharedSpace
      // 
      this.buttonSharedSpace.Location = new System.Drawing.Point(304, 32);
      this.buttonSharedSpace.Name = "buttonSharedSpace";
      this.buttonSharedSpace.Size = new System.Drawing.Size(127, 29);
      this.buttonSharedSpace.TabIndex = 11;
      this.buttonSharedSpace.Text = "Shared Space";
      this.buttonSharedSpace.UseVisualStyleBackColor = true;
      this.buttonSharedSpace.Click += new System.EventHandler(this.buttonSharedSpace_Click);
      // 
      // m_workSpaces
      // 
      this.m_workSpaces.FormattingEnabled = true;
      this.m_workSpaces.Location = new System.Drawing.Point(132, 61);
      this.m_workSpaces.Name = "m_workSpaces";
      this.m_workSpaces.Size = new System.Drawing.Size(121, 24);
      this.m_workSpaces.TabIndex = 12;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(14, 68);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(93, 17);
      this.label5.TabIndex = 13;
      this.label5.Text = "Work Space: ";
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.buttonTestConnection);
      this.groupBox1.Controls.Add(this.m_password);
      this.groupBox1.Controls.Add(this.label3);
      this.groupBox1.Controls.Add(this.m_userName);
      this.groupBox1.Controls.Add(this.label2);
      this.groupBox1.Controls.Add(this.m_serverUrl);
      this.groupBox1.Controls.Add(this.label1);
      this.groupBox1.Location = new System.Drawing.Point(12, 28);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(493, 206);
      this.groupBox1.TabIndex = 14;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Connect to server: ";
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.label5);
      this.groupBox2.Controls.Add(this.m_workSpaces);
      this.groupBox2.Controls.Add(this.buttonSharedSpace);
      this.groupBox2.Controls.Add(this.m_sharedSpaceId);
      this.groupBox2.Controls.Add(this.label4);
      this.groupBox2.Location = new System.Drawing.Point(16, 251);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(488, 109);
      this.groupBox2.TabIndex = 15;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Work Space:";
      // 
      // ConfigurationForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(529, 465);
      this.Controls.Add(this.groupBox2);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.buttonCancel);
      this.Controls.Add(this.buttonOK);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "ConfigurationForm";
      this.Text = "ConfigurationForm";
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox m_serverUrl;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox m_userName;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox m_password;
    private System.Windows.Forms.Button buttonTestConnection;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox m_sharedSpaceId;
    private System.Windows.Forms.Button buttonOK;
    private System.Windows.Forms.Button buttonCancel;
    private System.Windows.Forms.Button buttonSharedSpace;
    private System.Windows.Forms.ComboBox m_workSpaces;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.GroupBox groupBox2;
  }
}