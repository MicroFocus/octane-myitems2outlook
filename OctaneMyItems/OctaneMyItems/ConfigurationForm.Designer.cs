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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigurationForm));
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
      this.label5 = new System.Windows.Forms.Label();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.groupBox1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(11, 28);
      this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(57, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Server Url:";
      // 
      // m_serverUrl
      // 
      this.m_serverUrl.Location = new System.Drawing.Point(102, 24);
      this.m_serverUrl.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
      this.m_serverUrl.Name = "m_serverUrl";
      this.m_serverUrl.Size = new System.Drawing.Size(257, 20);
      this.m_serverUrl.TabIndex = 1;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(11, 61);
      this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(66, 13);
      this.label2.TabIndex = 2;
      this.label2.Text = "User Name: ";
      // 
      // m_userName
      // 
      this.m_userName.Location = new System.Drawing.Point(102, 58);
      this.m_userName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
      this.m_userName.Name = "m_userName";
      this.m_userName.Size = new System.Drawing.Size(257, 20);
      this.m_userName.TabIndex = 3;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(11, 93);
      this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(56, 13);
      this.label3.TabIndex = 4;
      this.label3.Text = "Password:";
      // 
      // m_password
      // 
      this.m_password.Location = new System.Drawing.Point(102, 91);
      this.m_password.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
      this.m_password.Name = "m_password";
      this.m_password.PasswordChar = '*';
      this.m_password.Size = new System.Drawing.Size(257, 20);
      this.m_password.TabIndex = 5;
      this.m_password.UseSystemPasswordChar = true;
      // 
      // buttonTestConnection
      // 
      this.buttonTestConnection.Location = new System.Drawing.Point(102, 155);
      this.buttonTestConnection.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
      this.buttonTestConnection.Name = "buttonTestConnection";
      this.buttonTestConnection.Size = new System.Drawing.Size(122, 24);
      this.buttonTestConnection.TabIndex = 8;
      this.buttonTestConnection.Text = "Get workspaces ...";
      this.buttonTestConnection.UseVisualStyleBackColor = true;
      this.buttonTestConnection.Click += new System.EventHandler(this.buttonTestConnection_Click);
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(11, 126);
      this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(93, 13);
      this.label4.TabIndex = 7;
      this.label4.Text = "Shared Space Id: ";
      // 
      // m_sharedSpaceId
      // 
      this.m_sharedSpaceId.Location = new System.Drawing.Point(102, 124);
      this.m_sharedSpaceId.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
      this.m_sharedSpaceId.Name = "m_sharedSpaceId";
      this.m_sharedSpaceId.Size = new System.Drawing.Size(257, 20);
      this.m_sharedSpaceId.TabIndex = 6;
      // 
      // buttonOK
      // 
      this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.buttonOK.Location = new System.Drawing.Point(262, 270);
      this.buttonOK.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
      this.buttonOK.Name = "buttonOK";
      this.buttonOK.Size = new System.Drawing.Size(56, 25);
      this.buttonOK.TabIndex = 10;
      this.buttonOK.Text = "&OK";
      this.buttonOK.UseVisualStyleBackColor = true;
      this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
      // 
      // buttonCancel
      // 
      this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.buttonCancel.Location = new System.Drawing.Point(322, 270);
      this.buttonCancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
      this.buttonCancel.Name = "buttonCancel";
      this.buttonCancel.Size = new System.Drawing.Size(56, 25);
      this.buttonCancel.TabIndex = 11;
      this.buttonCancel.Text = "&Cancel";
      this.buttonCancel.UseVisualStyleBackColor = true;
      this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
      // 
      // m_workspacesComboBox
      // 
      this.m_workspacesComboBox.FormattingEnabled = true;
      this.m_workspacesComboBox.Location = new System.Drawing.Point(102, 193);
      this.m_workspacesComboBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
      this.m_workspacesComboBox.Name = "m_workspacesComboBox";
      this.m_workspacesComboBox.Size = new System.Drawing.Size(257, 21);
      this.m_workspacesComboBox.TabIndex = 9;
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.label5);
      this.groupBox1.Controls.Add(this.m_workspacesComboBox);
      this.groupBox1.Controls.Add(this.buttonTestConnection);
      this.groupBox1.Controls.Add(this.m_password);
      this.groupBox1.Controls.Add(this.label3);
      this.groupBox1.Controls.Add(this.m_sharedSpaceId);
      this.groupBox1.Controls.Add(this.m_userName);
      this.groupBox1.Controls.Add(this.label4);
      this.groupBox1.Controls.Add(this.label2);
      this.groupBox1.Controls.Add(this.m_serverUrl);
      this.groupBox1.Controls.Add(this.label1);
      this.groupBox1.Location = new System.Drawing.Point(9, 23);
      this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
      this.groupBox1.Size = new System.Drawing.Size(370, 231);
      this.groupBox1.TabIndex = 14;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Connect to Octane:";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(11, 196);
      this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(67, 13);
      this.label5.TabIndex = 13;
      this.label5.Text = "Workspaces";
      // 
      // pictureBox1
      // 
      this.pictureBox1.Image = global::OctaneMyItems.Properties.Resources.hpe_logo;
      this.pictureBox1.Location = new System.Drawing.Point(9, 258);
      this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(110, 56);
      this.pictureBox1.TabIndex = 15;
      this.pictureBox1.TabStop = false;
      // 
      // ConfigurationForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.buttonCancel;
      this.ClientSize = new System.Drawing.Size(384, 311);
      this.Controls.Add(this.pictureBox1);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.buttonCancel);
      this.Controls.Add(this.buttonOK);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "ConfigurationForm";
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Octane Configuration";
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}