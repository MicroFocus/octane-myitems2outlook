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
      this.tabPage2 = new System.Windows.Forms.TabPage();
      this.tabPage1 = new System.Windows.Forms.TabPage();
      this.wb_description = new System.Windows.Forms.WebBrowser();
      this.p_fields = new System.Windows.Forms.Panel();
      this.splitter1 = new System.Windows.Forms.Splitter();
      this.tabControl1.SuspendLayout();
      this.tabPage1.SuspendLayout();
      this.p_fields.SuspendLayout();
      this.SuspendLayout();
      // 
      // tabControl1
      // 
      this.tabControl1.Controls.Add(this.tabPage1);
      this.tabControl1.Controls.Add(this.tabPage2);
      this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tabControl1.Location = new System.Drawing.Point(0, 100);
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new System.Drawing.Size(1005, 685);
      this.tabControl1.TabIndex = 3;
      // 
      // tabPage2
      // 
      this.tabPage2.Location = new System.Drawing.Point(4, 22);
      this.tabPage2.Name = "tabPage2";
      this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage2.Size = new System.Drawing.Size(815, 492);
      this.tabPage2.TabIndex = 1;
      this.tabPage2.Text = "Comments";
      this.tabPage2.UseVisualStyleBackColor = true;
      // 
      // tabPage1
      // 
      this.tabPage1.Controls.Add(this.wb_description);
      this.tabPage1.Location = new System.Drawing.Point(4, 22);
      this.tabPage1.Name = "tabPage1";
      this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage1.Size = new System.Drawing.Size(997, 659);
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
      this.wb_description.Size = new System.Drawing.Size(991, 653);
      this.wb_description.TabIndex = 0;
      // 
      // p_fields
      // 
      this.p_fields.AutoScroll = true;
      this.p_fields.Controls.Add(this.splitter1);
      this.p_fields.Dock = System.Windows.Forms.DockStyle.Top;
      this.p_fields.Location = new System.Drawing.Point(0, 0);
      this.p_fields.Name = "p_fields";
      this.p_fields.Size = new System.Drawing.Size(1005, 100);
      this.p_fields.TabIndex = 2;
      // 
      // splitter1
      // 
      this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.splitter1.Location = new System.Drawing.Point(0, 97);
      this.splitter1.Name = "splitter1";
      this.splitter1.Size = new System.Drawing.Size(1005, 3);
      this.splitter1.TabIndex = 0;
      this.splitter1.TabStop = false;
      // 
      // OctaneTaskDetail
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.tabControl1);
      this.Controls.Add(this.p_fields);
      this.Name = "OctaneTaskDetail";
      this.Size = new System.Drawing.Size(1005, 785);
      this.FormRegionShowing += new System.EventHandler(this.OctaneTaskDetail_FormRegionShowing);
      this.FormRegionClosed += new System.EventHandler(this.OctaneTaskDetail_FormRegionClosed);
      this.tabControl1.ResumeLayout(false);
      this.tabPage1.ResumeLayout(false);
      this.p_fields.ResumeLayout(false);
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
      manifest.FormRegionName = "OctaneTaskDetail";
      manifest.FormRegionType = Microsoft.Office.Tools.Outlook.FormRegionType.Adjoining;

    }

    #endregion

    private System.Windows.Forms.TabControl tabControl1;
    private System.Windows.Forms.TabPage tabPage1;
    private System.Windows.Forms.WebBrowser wb_description;
    private System.Windows.Forms.TabPage tabPage2;
    private System.Windows.Forms.Panel p_fields;
    private System.Windows.Forms.Splitter splitter1;

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
