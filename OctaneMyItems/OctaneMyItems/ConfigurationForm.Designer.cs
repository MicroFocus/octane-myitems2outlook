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
      this.m_tbServerUrl = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.m_tbUserName = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.m_tbPassword = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.m_btnOK = new System.Windows.Forms.Button();
      this.m_btnCancel = new System.Windows.Forms.Button();
      this.m_cbWorkspaces = new System.Windows.Forms.ComboBox();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.m_cbSharedspaces = new System.Windows.Forms.ComboBox();
      this.m_btnAuthenticate = new System.Windows.Forms.Button();
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
      // m_tbServerUrl
      // 
      this.m_tbServerUrl.Location = new System.Drawing.Point(102, 24);
      this.m_tbServerUrl.Margin = new System.Windows.Forms.Padding(2);
      this.m_tbServerUrl.Name = "m_tbServerUrl";
      this.m_tbServerUrl.Size = new System.Drawing.Size(257, 20);
      this.m_tbServerUrl.TabIndex = 1;
      this.m_tbServerUrl.TextChanged += new System.EventHandler(this.m_tbServerUrl_TextChanged);
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
      // m_tbUserName
      // 
      this.m_tbUserName.Location = new System.Drawing.Point(102, 58);
      this.m_tbUserName.Margin = new System.Windows.Forms.Padding(2);
      this.m_tbUserName.Name = "m_tbUserName";
      this.m_tbUserName.Size = new System.Drawing.Size(257, 20);
      this.m_tbUserName.TabIndex = 3;
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
      // m_tbPassword
      // 
      this.m_tbPassword.Location = new System.Drawing.Point(102, 91);
      this.m_tbPassword.Margin = new System.Windows.Forms.Padding(2);
      this.m_tbPassword.Name = "m_tbPassword";
      this.m_tbPassword.PasswordChar = '*';
      this.m_tbPassword.Size = new System.Drawing.Size(257, 20);
      this.m_tbPassword.TabIndex = 5;
      this.m_tbPassword.UseSystemPasswordChar = true;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(11, 171);
      this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(78, 13);
      this.label4.TabIndex = 7;
      this.label4.Text = "Sharedspaces:";
      // 
      // m_btnOK
      // 
      this.m_btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.m_btnOK.Enabled = false;
      this.m_btnOK.Location = new System.Drawing.Point(247, 270);
      this.m_btnOK.Margin = new System.Windows.Forms.Padding(2);
      this.m_btnOK.Name = "m_btnOK";
      this.m_btnOK.Size = new System.Drawing.Size(56, 25);
      this.m_btnOK.TabIndex = 10;
      this.m_btnOK.Text = "&OK";
      this.m_btnOK.UseVisualStyleBackColor = true;
      this.m_btnOK.Click += new System.EventHandler(this.m_btnOK_Click);
      // 
      // m_btnCancel
      // 
      this.m_btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.m_btnCancel.Location = new System.Drawing.Point(312, 270);
      this.m_btnCancel.Margin = new System.Windows.Forms.Padding(2);
      this.m_btnCancel.Name = "m_btnCancel";
      this.m_btnCancel.Size = new System.Drawing.Size(56, 25);
      this.m_btnCancel.TabIndex = 11;
      this.m_btnCancel.Text = "&Cancel";
      this.m_btnCancel.UseVisualStyleBackColor = true;
      this.m_btnCancel.Click += new System.EventHandler(this.m_btnCancel_Click);
      // 
      // m_cbWorkspaces
      // 
      this.m_cbWorkspaces.DisplayMember = "name";
      this.m_cbWorkspaces.Enabled = false;
      this.m_cbWorkspaces.FormattingEnabled = true;
      this.m_cbWorkspaces.Location = new System.Drawing.Point(102, 193);
      this.m_cbWorkspaces.Margin = new System.Windows.Forms.Padding(2);
      this.m_cbWorkspaces.Name = "m_cbWorkspaces";
      this.m_cbWorkspaces.Size = new System.Drawing.Size(257, 21);
      this.m_cbWorkspaces.TabIndex = 9;
      this.m_cbWorkspaces.SelectedIndexChanged += new System.EventHandler(this.m_cbWorkspaces_SelectedIndexChanged);
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.m_cbSharedspaces);
      this.groupBox1.Controls.Add(this.m_btnAuthenticate);
      this.groupBox1.Controls.Add(this.label5);
      this.groupBox1.Controls.Add(this.m_cbWorkspaces);
      this.groupBox1.Controls.Add(this.m_tbPassword);
      this.groupBox1.Controls.Add(this.label3);
      this.groupBox1.Controls.Add(this.m_tbUserName);
      this.groupBox1.Controls.Add(this.label4);
      this.groupBox1.Controls.Add(this.label2);
      this.groupBox1.Controls.Add(this.m_tbServerUrl);
      this.groupBox1.Controls.Add(this.label1);
      this.groupBox1.Location = new System.Drawing.Point(9, 23);
      this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
      this.groupBox1.Size = new System.Drawing.Size(370, 231);
      this.groupBox1.TabIndex = 14;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Connect to Octane:";
      // 
      // m_cbSharedspaces
      // 
      this.m_cbSharedspaces.DisplayMember = "name";
      this.m_cbSharedspaces.Enabled = false;
      this.m_cbSharedspaces.FormattingEnabled = true;
      this.m_cbSharedspaces.Location = new System.Drawing.Point(102, 167);
      this.m_cbSharedspaces.Name = "m_cbSharedspaces";
      this.m_cbSharedspaces.Size = new System.Drawing.Size(257, 21);
      this.m_cbSharedspaces.TabIndex = 15;
      this.m_cbSharedspaces.SelectedIndexChanged += new System.EventHandler(this.m_cbSharedpaces_SelectedIndexChanged);
      // 
      // m_btnAuthenticate
      // 
      this.m_btnAuthenticate.Location = new System.Drawing.Point(238, 125);
      this.m_btnAuthenticate.Name = "m_btnAuthenticate";
      this.m_btnAuthenticate.Size = new System.Drawing.Size(121, 24);
      this.m_btnAuthenticate.TabIndex = 14;
      this.m_btnAuthenticate.Text = "&Authenticate";
      this.m_btnAuthenticate.UseVisualStyleBackColor = true;
      this.m_btnAuthenticate.Click += new System.EventHandler(this.m_btnAuthenticate_Click);
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(11, 196);
      this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(70, 13);
      this.label5.TabIndex = 13;
      this.label5.Text = "Workspaces:";
      // 
      // pictureBox1
      // 
      this.pictureBox1.Image = global::OctaneMyItems.Properties.Resources.hpe_logo;
      this.pictureBox1.Location = new System.Drawing.Point(9, 258);
      this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(110, 56);
      this.pictureBox1.TabIndex = 15;
      this.pictureBox1.TabStop = false;
      // 
      // ConfigurationForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.m_btnCancel;
      this.ClientSize = new System.Drawing.Size(384, 311);
      this.Controls.Add(this.pictureBox1);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.m_btnCancel);
      this.Controls.Add(this.m_btnOK);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Margin = new System.Windows.Forms.Padding(2);
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
    private System.Windows.Forms.TextBox m_tbServerUrl;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox m_tbUserName;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox m_tbPassword;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Button m_btnOK;
    private System.Windows.Forms.Button m_btnCancel;
    private System.Windows.Forms.ComboBox m_cbWorkspaces;
    private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.ComboBox m_cbSharedspaces;
    private System.Windows.Forms.Button m_btnAuthenticate;
  }
}