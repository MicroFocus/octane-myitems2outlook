namespace OctaneMyItems
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
      this.m_workspacesComboBox = new System.Windows.Forms.ComboBox();
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
      this.buttonTestConnection.Location = new System.Drawing.Point(172, 202);
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
      this.label4.Location = new System.Drawing.Point(18, 157);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(121, 17);
      this.label4.TabIndex = 7;
      this.label4.Text = "Shared Space Id: ";
      // 
      // m_sharedSpaceId
      // 
      this.m_sharedSpaceId.Location = new System.Drawing.Point(136, 154);
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
      // m_workSpaces
      // 
      this.m_workspacesComboBox.FormattingEnabled = true;
      this.m_workspacesComboBox.Location = new System.Drawing.Point(86, 31);
      this.m_workspacesComboBox.Name = "m_workSpaces";
      this.m_workspacesComboBox.Size = new System.Drawing.Size(317, 24);
      this.m_workspacesComboBox.TabIndex = 12;
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.buttonTestConnection);
      this.groupBox1.Controls.Add(this.m_password);
      this.groupBox1.Controls.Add(this.label3);
      this.groupBox1.Controls.Add(this.m_sharedSpaceId);
      this.groupBox1.Controls.Add(this.m_userName);
      this.groupBox1.Controls.Add(this.label4);
      this.groupBox1.Controls.Add(this.label2);
      this.groupBox1.Controls.Add(this.m_serverUrl);
      this.groupBox1.Controls.Add(this.label1);
      this.groupBox1.Location = new System.Drawing.Point(12, 28);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(493, 238);
      this.groupBox1.TabIndex = 14;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Connect to server: ";
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.m_workspacesComboBox);
      this.groupBox2.Location = new System.Drawing.Point(16, 311);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(488, 73);
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
    private System.Windows.Forms.ComboBox m_workspacesComboBox;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.GroupBox groupBox2;
  }
}