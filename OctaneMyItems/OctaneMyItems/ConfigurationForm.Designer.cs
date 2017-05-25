/* 
  (c) Copyright 2016 Hewlett Packard Enterprise Development LP

  Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with the License.

  You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0

  Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an "AS IS" BASIS,

  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.

  See the License for the specific language governing permissions and limitations under the License.
*/

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
      this.m_tbUserName = new System.Windows.Forms.TextBox();
      this.m_tbPassword = new System.Windows.Forms.TextBox();
      this.m_btnOK = new System.Windows.Forms.Button();
      this.m_btnCancel = new System.Windows.Forms.Button();
      this.m_cbWorkspaces = new System.Windows.Forms.ComboBox();
      this.m_cbSharedspaces = new System.Windows.Forms.ComboBox();
      this.m_btnAuthenticate = new System.Windows.Forms.Button();
      this.label6 = new System.Windows.Forms.Label();
      this.label7 = new System.Windows.Forms.Label();
      this.label8 = new System.Windows.Forms.Label();
      this.button1 = new System.Windows.Forms.Button();
      this.button2 = new System.Windows.Forms.Button();
      this.label9 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.button3 = new System.Windows.Forms.Button();
      this.label3 = new System.Windows.Forms.Label();
      this.button4 = new System.Windows.Forms.Button();
      this.label10 = new System.Windows.Forms.Label();
      this.button5 = new System.Windows.Forms.Button();
      this.label4 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.label13 = new System.Windows.Forms.Label();
      this.label14 = new System.Windows.Forms.Label();
      this.label15 = new System.Windows.Forms.Label();
      this.m_mainPanel = new System.Windows.Forms.Panel();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.m_mainPanel.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(119)))), ((int)(((byte)(119)))));
      this.label1.Location = new System.Drawing.Point(28, 87);
      this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(72, 19);
      this.label1.TabIndex = 0;
      this.label1.Text = "Server Url:";
      // 
      // m_tbServerUrl
      // 
      this.m_tbServerUrl.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.m_tbServerUrl.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.m_tbServerUrl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
      this.m_tbServerUrl.Location = new System.Drawing.Point(158, 87);
      this.m_tbServerUrl.Margin = new System.Windows.Forms.Padding(2);
      this.m_tbServerUrl.Name = "m_tbServerUrl";
      this.m_tbServerUrl.Size = new System.Drawing.Size(210, 18);
      this.m_tbServerUrl.TabIndex = 1;
      this.m_tbServerUrl.TextChanged += new System.EventHandler(this.m_tbServerUrl_TextChanged);
      // 
      // m_tbUserName
      // 
      this.m_tbUserName.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.m_tbUserName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.m_tbUserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
      this.m_tbUserName.Location = new System.Drawing.Point(158, 127);
      this.m_tbUserName.Margin = new System.Windows.Forms.Padding(2);
      this.m_tbUserName.Name = "m_tbUserName";
      this.m_tbUserName.Size = new System.Drawing.Size(210, 18);
      this.m_tbUserName.TabIndex = 3;
      // 
      // m_tbPassword
      // 
      this.m_tbPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.m_tbPassword.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.m_tbPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
      this.m_tbPassword.Location = new System.Drawing.Point(158, 167);
      this.m_tbPassword.Margin = new System.Windows.Forms.Padding(2);
      this.m_tbPassword.Name = "m_tbPassword";
      this.m_tbPassword.PasswordChar = '*';
      this.m_tbPassword.Size = new System.Drawing.Size(210, 18);
      this.m_tbPassword.TabIndex = 5;
      this.m_tbPassword.UseSystemPasswordChar = true;
      // 
      // m_btnOK
      // 
      this.m_btnOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(169)))), ((int)(((byte)(130)))));
      this.m_btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.m_btnOK.Enabled = false;
      this.m_btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.m_btnOK.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.m_btnOK.ForeColor = System.Drawing.Color.White;
      this.m_btnOK.Location = new System.Drawing.Point(320, 519);
      this.m_btnOK.Margin = new System.Windows.Forms.Padding(2);
      this.m_btnOK.Name = "m_btnOK";
      this.m_btnOK.Size = new System.Drawing.Size(80, 30);
      this.m_btnOK.TabIndex = 10;
      this.m_btnOK.Text = "&OK";
      this.m_btnOK.UseVisualStyleBackColor = false;
      this.m_btnOK.Click += new System.EventHandler(this.m_btnOK_Click);
      // 
      // m_btnCancel
      // 
      this.m_btnCancel.BackColor = System.Drawing.Color.White;
      this.m_btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.m_btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
      this.m_btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.m_btnCancel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.m_btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
      this.m_btnCancel.Location = new System.Drawing.Point(410, 519);
      this.m_btnCancel.Margin = new System.Windows.Forms.Padding(2);
      this.m_btnCancel.Name = "m_btnCancel";
      this.m_btnCancel.Size = new System.Drawing.Size(80, 30);
      this.m_btnCancel.TabIndex = 11;
      this.m_btnCancel.Text = "&Cancel";
      this.m_btnCancel.UseVisualStyleBackColor = false;
      this.m_btnCancel.Click += new System.EventHandler(this.m_btnCancel_Click);
      // 
      // m_cbWorkspaces
      // 
      this.m_cbWorkspaces.BackColor = System.Drawing.Color.White;
      this.m_cbWorkspaces.Cursor = System.Windows.Forms.Cursors.IBeam;
      this.m_cbWorkspaces.DisplayMember = "name";
      this.m_cbWorkspaces.Enabled = false;
      this.m_cbWorkspaces.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.m_cbWorkspaces.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
      this.m_cbWorkspaces.FormattingEnabled = true;
      this.m_cbWorkspaces.Location = new System.Drawing.Point(148, 401);
      this.m_cbWorkspaces.Margin = new System.Windows.Forms.Padding(2);
      this.m_cbWorkspaces.Name = "m_cbWorkspaces";
      this.m_cbWorkspaces.Size = new System.Drawing.Size(230, 25);
      this.m_cbWorkspaces.TabIndex = 9;
      this.m_cbWorkspaces.SelectedIndexChanged += new System.EventHandler(this.m_cbWorkspaces_SelectedIndexChanged);
      // 
      // m_cbSharedspaces
      // 
      this.m_cbSharedspaces.BackColor = System.Drawing.Color.White;
      this.m_cbSharedspaces.Cursor = System.Windows.Forms.Cursors.IBeam;
      this.m_cbSharedspaces.DisplayMember = "name";
      this.m_cbSharedspaces.Enabled = false;
      this.m_cbSharedspaces.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.m_cbSharedspaces.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
      this.m_cbSharedspaces.FormattingEnabled = true;
      this.m_cbSharedspaces.Location = new System.Drawing.Point(148, 357);
      this.m_cbSharedspaces.Name = "m_cbSharedspaces";
      this.m_cbSharedspaces.Size = new System.Drawing.Size(230, 25);
      this.m_cbSharedspaces.TabIndex = 15;
      this.m_cbSharedspaces.SelectedIndexChanged += new System.EventHandler(this.m_cbSharedpaces_SelectedIndexChanged);
      // 
      // m_btnAuthenticate
      // 
      this.m_btnAuthenticate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(169)))), ((int)(((byte)(130)))));
      this.m_btnAuthenticate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.m_btnAuthenticate.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.m_btnAuthenticate.ForeColor = System.Drawing.Color.White;
      this.m_btnAuthenticate.Location = new System.Drawing.Point(75, 229);
      this.m_btnAuthenticate.Name = "m_btnAuthenticate";
      this.m_btnAuthenticate.Size = new System.Drawing.Size(330, 40);
      this.m_btnAuthenticate.TabIndex = 14;
      this.m_btnAuthenticate.Text = "&Authenticate";
      this.m_btnAuthenticate.UseVisualStyleBackColor = false;
      this.m_btnAuthenticate.Click += new System.EventHandler(this.m_btnAuthenticate_Click);
      // 
      // label6
      // 
      this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
      this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
      this.label6.Location = new System.Drawing.Point(20, 37);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(480, 1);
      this.label6.TabIndex = 16;
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
      this.label7.Location = new System.Drawing.Point(16, 6);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(194, 25);
      this.label7.TabIndex = 17;
      this.label7.Text = "Octane Configuration";
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
      this.label8.Location = new System.Drawing.Point(17, 47);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(148, 21);
      this.label8.TabIndex = 18;
      this.label8.Text = "Connect to Octane -";
      // 
      // button1
      // 
      this.button1.BackColor = System.Drawing.Color.Red;
      this.button1.FlatAppearance.BorderSize = 0;
      this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.button1.Location = new System.Drawing.Point(22, 91);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(5, 5);
      this.button1.TabIndex = 19;
      this.button1.UseVisualStyleBackColor = false;
      // 
      // button2
      // 
      this.button2.BackColor = System.Drawing.Color.Red;
      this.button2.FlatAppearance.BorderSize = 0;
      this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.button2.Location = new System.Drawing.Point(22, 131);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(5, 5);
      this.button2.TabIndex = 20;
      this.button2.UseVisualStyleBackColor = false;
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(119)))), ((int)(((byte)(119)))));
      this.label9.Location = new System.Drawing.Point(28, 127);
      this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(80, 19);
      this.label9.TabIndex = 21;
      this.label9.Text = "User Name:";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(119)))), ((int)(((byte)(119)))));
      this.label2.Location = new System.Drawing.Point(28, 167);
      this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(70, 19);
      this.label2.TabIndex = 22;
      this.label2.Text = "Password:";
      // 
      // button3
      // 
      this.button3.BackColor = System.Drawing.Color.Red;
      this.button3.FlatAppearance.BorderSize = 0;
      this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.button3.Location = new System.Drawing.Point(22, 171);
      this.button3.Name = "button3";
      this.button3.Size = new System.Drawing.Size(5, 5);
      this.button3.TabIndex = 23;
      this.button3.UseVisualStyleBackColor = false;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
      this.label3.Location = new System.Drawing.Point(17, 320);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(137, 21);
      this.label3.TabIndex = 24;
      this.label3.Text = "Connect Settings -";
      // 
      // button4
      // 
      this.button4.BackColor = System.Drawing.Color.Red;
      this.button4.FlatAppearance.BorderSize = 0;
      this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.button4.Location = new System.Drawing.Point(22, 364);
      this.button4.Name = "button4";
      this.button4.Size = new System.Drawing.Size(5, 5);
      this.button4.TabIndex = 26;
      this.button4.UseVisualStyleBackColor = false;
      // 
      // label10
      // 
      this.label10.AutoSize = true;
      this.label10.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(119)))), ((int)(((byte)(119)))));
      this.label10.Location = new System.Drawing.Point(28, 360);
      this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(94, 19);
      this.label10.TabIndex = 25;
      this.label10.Text = "Sharedspaces:";
      // 
      // button5
      // 
      this.button5.BackColor = System.Drawing.Color.Red;
      this.button5.FlatAppearance.BorderSize = 0;
      this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.button5.Location = new System.Drawing.Point(22, 404);
      this.button5.Name = "button5";
      this.button5.Size = new System.Drawing.Size(5, 5);
      this.button5.TabIndex = 28;
      this.button5.UseVisualStyleBackColor = false;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(119)))), ((int)(((byte)(119)))));
      this.label4.Location = new System.Drawing.Point(28, 400);
      this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(84, 19);
      this.label4.TabIndex = 27;
      this.label4.Text = "Workspaces:";
      // 
      // label5
      // 
      this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.label5.Location = new System.Drawing.Point(20, 559);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(480, 2);
      this.label5.TabIndex = 29;
      // 
      // label13
      // 
      this.label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.label13.Location = new System.Drawing.Point(148, 186);
      this.label13.Name = "label13";
      this.label13.Size = new System.Drawing.Size(231, 2);
      this.label13.TabIndex = 32;
      // 
      // label14
      // 
      this.label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.label14.Location = new System.Drawing.Point(148, 146);
      this.label14.Name = "label14";
      this.label14.Size = new System.Drawing.Size(231, 2);
      this.label14.TabIndex = 33;
      // 
      // label15
      // 
      this.label15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.label15.Location = new System.Drawing.Point(148, 106);
      this.label15.Name = "label15";
      this.label15.Size = new System.Drawing.Size(231, 2);
      this.label15.TabIndex = 34;
      // 
      // m_mainPanel
      // 
      this.m_mainPanel.BackColor = System.Drawing.Color.White;
      this.m_mainPanel.Controls.Add(this.pictureBox1);
      this.m_mainPanel.Controls.Add(this.label6);
      this.m_mainPanel.Controls.Add(this.label7);
      this.m_mainPanel.Controls.Add(this.label15);
      this.m_mainPanel.Controls.Add(this.m_tbServerUrl);
      this.m_mainPanel.Controls.Add(this.label14);
      this.m_mainPanel.Controls.Add(this.m_tbUserName);
      this.m_mainPanel.Controls.Add(this.label13);
      this.m_mainPanel.Controls.Add(this.label1);
      this.m_mainPanel.Controls.Add(this.label5);
      this.m_mainPanel.Controls.Add(this.m_tbPassword);
      this.m_mainPanel.Controls.Add(this.button5);
      this.m_mainPanel.Controls.Add(this.m_btnOK);
      this.m_mainPanel.Controls.Add(this.label4);
      this.m_mainPanel.Controls.Add(this.m_cbWorkspaces);
      this.m_mainPanel.Controls.Add(this.button4);
      this.m_mainPanel.Controls.Add(this.m_btnCancel);
      this.m_mainPanel.Controls.Add(this.label10);
      this.m_mainPanel.Controls.Add(this.m_btnAuthenticate);
      this.m_mainPanel.Controls.Add(this.label3);
      this.m_mainPanel.Controls.Add(this.button3);
      this.m_mainPanel.Controls.Add(this.m_cbSharedspaces);
      this.m_mainPanel.Controls.Add(this.label2);
      this.m_mainPanel.Controls.Add(this.label9);
      this.m_mainPanel.Controls.Add(this.label8);
      this.m_mainPanel.Controls.Add(this.button2);
      this.m_mainPanel.Controls.Add(this.button1);
      this.m_mainPanel.Location = new System.Drawing.Point(1, 1);
      this.m_mainPanel.Name = "m_mainPanel";
      this.m_mainPanel.Size = new System.Drawing.Size(500, 660);
      this.m_mainPanel.TabIndex = 35;
      this.m_mainPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.m_mainPanel_MouseDown);
      this.m_mainPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.m_mainPanel_MouseMove);
      this.m_mainPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.m_mainPanel_MouseUp);
      // 
      // pictureBox1
      // 
      this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
      this.pictureBox1.Location = new System.Drawing.Point(20, 577);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(156, 57);
      this.pictureBox1.TabIndex = 35;
      this.pictureBox1.TabStop = false;
      // 
      // ConfigurationForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
      this.CancelButton = this.m_btnCancel;
      this.ClientSize = new System.Drawing.Size(502, 662);
      this.Controls.Add(this.m_mainPanel);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Margin = new System.Windows.Forms.Padding(2);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "ConfigurationForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Octane Configuration";
      this.TopMost = true;
      this.m_mainPanel.ResumeLayout(false);
      this.m_mainPanel.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox m_tbServerUrl;
    private System.Windows.Forms.TextBox m_tbUserName;
    private System.Windows.Forms.TextBox m_tbPassword;
    private System.Windows.Forms.Button m_btnOK;
    private System.Windows.Forms.Button m_btnCancel;
    private System.Windows.Forms.ComboBox m_cbWorkspaces;
    private System.Windows.Forms.ComboBox m_cbSharedspaces;
    private System.Windows.Forms.Button m_btnAuthenticate;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button button3;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Button button4;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.Button button5;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label13;
    private System.Windows.Forms.Label label14;
    private System.Windows.Forms.Label label15;
    private System.Windows.Forms.Panel m_mainPanel;
    private System.Windows.Forms.PictureBox pictureBox1;
  }
}