namespace OctaneMyItems
{
  [System.ComponentModel.ToolboxItemAttribute(false)]
  partial class OctaneTaskDetail : Microsoft.Office.Tools.Outlook.FormRegionBase
  {
    public OctaneTaskDetail(Microsoft.Office.Interop.Outlook.FormRegion formRegion)
        : base(Globals.Factory, formRegion)
    {
      this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
      this.InitializeComponent();
    }

    /// <summary> 
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.tabControl1 = new System.Windows.Forms.TabControl();
      this.tabPage1 = new System.Windows.Forms.TabPage();
      this.wb_description = new System.Windows.Forms.WebBrowser();
      this.tabPage2 = new System.Windows.Forms.TabPage();
      this.wb_comments = new System.Windows.Forms.WebBrowser();
      this.tp_testSteps = new System.Windows.Forms.TabPage();
      this.rtb_testSteps = new System.Windows.Forms.RichTextBox();
      this.tp_runSteps = new System.Windows.Forms.TabPage();
      this.wb_runSteps = new System.Windows.Forms.WebBrowser();
      this.tabControl1.SuspendLayout();
      this.tabPage1.SuspendLayout();
      this.tabPage2.SuspendLayout();
      this.tp_testSteps.SuspendLayout();
      this.tp_runSteps.SuspendLayout();
      this.SuspendLayout();
      // 
      // tabControl1
      // 
      this.tabControl1.Controls.Add(this.tabPage1);
      this.tabControl1.Controls.Add(this.tabPage2);
      this.tabControl1.Controls.Add(this.tp_testSteps);
      this.tabControl1.Controls.Add(this.tp_runSteps);
      this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
      this.tabControl1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.tabControl1.Location = new System.Drawing.Point(0, 0);
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.Padding = new System.Drawing.Point(6, 6);
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new System.Drawing.Size(1005, 150);
      this.tabControl1.TabIndex = 3;
      this.tabControl1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControl1_DrawItem);
      // 
      // tabPage1
      // 
      this.tabPage1.Controls.Add(this.wb_description);
      this.tabPage1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
      this.tabPage1.Location = new System.Drawing.Point(4, 31);
      this.tabPage1.Name = "tabPage1";
      this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage1.Size = new System.Drawing.Size(997, 115);
      this.tabPage1.TabIndex = 0;
      this.tabPage1.Text = "Description";
      this.tabPage1.UseVisualStyleBackColor = true;
      // 
      // wb_description
      // 
      this.wb_description.Dock = System.Windows.Forms.DockStyle.Fill;
      this.wb_description.Location = new System.Drawing.Point(3, 3);
      this.wb_description.MinimumSize = new System.Drawing.Size(20, 20);
      this.wb_description.Name = "wb_description";
      this.wb_description.ScrollBarsEnabled = false;
      this.wb_description.Size = new System.Drawing.Size(991, 109);
      this.wb_description.TabIndex = 0;
      // 
      // tabPage2
      // 
      this.tabPage2.Controls.Add(this.wb_comments);
      this.tabPage2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
      this.tabPage2.Location = new System.Drawing.Point(4, 31);
      this.tabPage2.Name = "tabPage2";
      this.tabPage2.Size = new System.Drawing.Size(997, 115);
      this.tabPage2.TabIndex = 3;
      this.tabPage2.Text = "Comments";
      this.tabPage2.UseVisualStyleBackColor = true;
      // 
      // wb_comments
      // 
      this.wb_comments.Dock = System.Windows.Forms.DockStyle.Fill;
      this.wb_comments.Location = new System.Drawing.Point(0, 0);
      this.wb_comments.MinimumSize = new System.Drawing.Size(20, 20);
      this.wb_comments.Name = "wb_comments";
      this.wb_comments.ScrollBarsEnabled = false;
      this.wb_comments.Size = new System.Drawing.Size(997, 115);
      this.wb_comments.TabIndex = 0;
      // 
      // tp_testSteps
      // 
      this.tp_testSteps.Controls.Add(this.rtb_testSteps);
      this.tp_testSteps.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
      this.tp_testSteps.Location = new System.Drawing.Point(4, 31);
      this.tp_testSteps.Name = "tp_testSteps";
      this.tp_testSteps.Padding = new System.Windows.Forms.Padding(3);
      this.tp_testSteps.Size = new System.Drawing.Size(997, 115);
      this.tp_testSteps.TabIndex = 1;
      this.tp_testSteps.Text = "Steps";
      this.tp_testSteps.UseVisualStyleBackColor = true;
      // 
      // rtb_testSteps
      // 
      this.rtb_testSteps.BackColor = System.Drawing.Color.White;
      this.rtb_testSteps.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.rtb_testSteps.Dock = System.Windows.Forms.DockStyle.Fill;
      this.rtb_testSteps.Location = new System.Drawing.Point(3, 3);
      this.rtb_testSteps.Name = "rtb_testSteps";
      this.rtb_testSteps.ReadOnly = true;
      this.rtb_testSteps.Size = new System.Drawing.Size(991, 109);
      this.rtb_testSteps.TabIndex = 0;
      this.rtb_testSteps.Text = "";
      // 
      // tp_runSteps
      // 
      this.tp_runSteps.Controls.Add(this.wb_runSteps);
      this.tp_runSteps.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
      this.tp_runSteps.Location = new System.Drawing.Point(4, 31);
      this.tp_runSteps.Name = "tp_runSteps";
      this.tp_runSteps.Size = new System.Drawing.Size(997, 115);
      this.tp_runSteps.TabIndex = 2;
      this.tp_runSteps.Text = "Steps";
      this.tp_runSteps.UseVisualStyleBackColor = true;
      // 
      // wb_runSteps
      // 
      this.wb_runSteps.Dock = System.Windows.Forms.DockStyle.Fill;
      this.wb_runSteps.Location = new System.Drawing.Point(0, 0);
      this.wb_runSteps.MinimumSize = new System.Drawing.Size(20, 20);
      this.wb_runSteps.Name = "wb_runSteps";
      this.wb_runSteps.ScrollBarsEnabled = false;
      this.wb_runSteps.Size = new System.Drawing.Size(997, 115);
      this.wb_runSteps.TabIndex = 0;
      // 
      // OctaneTaskDetail
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.White;
      this.Controls.Add(this.tabControl1);
      this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Name = "OctaneTaskDetail";
      this.Size = new System.Drawing.Size(1005, 400);
      this.FormRegionShowing += new System.EventHandler(this.OctaneTaskDetail_FormRegionShowing);
      this.FormRegionClosed += new System.EventHandler(this.OctaneTaskDetail_FormRegionClosed);
      this.tabControl1.ResumeLayout(false);
      this.tabPage1.ResumeLayout(false);
      this.tabPage2.ResumeLayout(false);
      this.tp_testSteps.ResumeLayout(false);
      this.tp_runSteps.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    #region Form Region Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private static void InitializeManifest(Microsoft.Office.Tools.Outlook.FormRegionManifest manifest, Microsoft.Office.Tools.Outlook.Factory factory)
    {
      manifest.FormRegionName = "Octane";
      manifest.FormRegionType = Microsoft.Office.Tools.Outlook.FormRegionType.Adjoining;
      manifest.Title = "Octane";

    }

    #endregion

    private System.Windows.Forms.TabControl tabControl1;
    private System.Windows.Forms.TabPage tabPage1;
    private System.Windows.Forms.WebBrowser wb_description;
    private System.Windows.Forms.TabPage tp_testSteps;
    private System.Windows.Forms.TabPage tp_runSteps;
    private System.Windows.Forms.RichTextBox rtb_testSteps;
    private System.Windows.Forms.WebBrowser wb_runSteps;
    private System.Windows.Forms.TabPage tabPage2;
    private System.Windows.Forms.WebBrowser wb_comments;

    public partial class OctaneTaskDetailFactory : Microsoft.Office.Tools.Outlook.IFormRegionFactory
    {
      public event Microsoft.Office.Tools.Outlook.FormRegionInitializingEventHandler FormRegionInitializing;

      private Microsoft.Office.Tools.Outlook.FormRegionManifest _Manifest;

      [System.Diagnostics.DebuggerNonUserCodeAttribute()]
      public OctaneTaskDetailFactory()
      {
        this._Manifest = Globals.Factory.CreateFormRegionManifest();
        OctaneTaskDetail.InitializeManifest(this._Manifest, Globals.Factory);
        this.FormRegionInitializing += new Microsoft.Office.Tools.Outlook.FormRegionInitializingEventHandler(this.OctaneTaskDetailFactory_FormRegionInitializing);
      }

      [System.Diagnostics.DebuggerNonUserCodeAttribute()]
      public Microsoft.Office.Tools.Outlook.FormRegionManifest Manifest
      {
        get
        {
          return this._Manifest;
        }
      }

      [System.Diagnostics.DebuggerNonUserCodeAttribute()]
      Microsoft.Office.Tools.Outlook.IFormRegion Microsoft.Office.Tools.Outlook.IFormRegionFactory.CreateFormRegion(Microsoft.Office.Interop.Outlook.FormRegion formRegion)
      {
        OctaneTaskDetail form = new OctaneTaskDetail(formRegion);
        form.Factory = this;
        return form;
      }

      [System.Diagnostics.DebuggerNonUserCodeAttribute()]
      byte[] Microsoft.Office.Tools.Outlook.IFormRegionFactory.GetFormRegionStorage(object outlookItem, Microsoft.Office.Interop.Outlook.OlFormRegionMode formRegionMode, Microsoft.Office.Interop.Outlook.OlFormRegionSize formRegionSize)
      {
        throw new System.NotSupportedException();
      }

      [System.Diagnostics.DebuggerNonUserCodeAttribute()]
      bool Microsoft.Office.Tools.Outlook.IFormRegionFactory.IsDisplayedForItem(object outlookItem, Microsoft.Office.Interop.Outlook.OlFormRegionMode formRegionMode, Microsoft.Office.Interop.Outlook.OlFormRegionSize formRegionSize)
      {
        if (this.FormRegionInitializing != null)
        {
          Microsoft.Office.Tools.Outlook.FormRegionInitializingEventArgs cancelArgs = Globals.Factory.CreateFormRegionInitializingEventArgs(outlookItem, formRegionMode, formRegionSize, false);
          this.FormRegionInitializing(this, cancelArgs);
          return !cancelArgs.Cancel;
        }
        else
        {
          return true;
        }
      }

      [System.Diagnostics.DebuggerNonUserCodeAttribute()]
      Microsoft.Office.Tools.Outlook.FormRegionKindConstants Microsoft.Office.Tools.Outlook.IFormRegionFactory.Kind
      {
        get
        {
          return Microsoft.Office.Tools.Outlook.FormRegionKindConstants.WindowsForms;
        }
      }
    }
  }

  partial class WindowFormRegionCollection
  {
    internal OctaneTaskDetail OctaneTaskDetail
    {
      get
      {
        foreach (var item in this)
        {
          if (item.GetType() == typeof(OctaneTaskDetail))
            return (OctaneTaskDetail)item;
        }
        return null;
      }
    }
  }
}
