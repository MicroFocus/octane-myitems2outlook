namespace OctaneMyItems
{
  partial class Ribbon1 : Microsoft.Office.Tools.Ribbon.RibbonBase
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public Ribbon1()
        : base(Globals.Factory.GetRibbonFactory())
    {
      InitializeComponent();
    }

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

    #region Component Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.MyItems = this.Factory.CreateRibbonTab();
      this.Octane = this.Factory.CreateRibbonGroup();
      this.SyncAll = this.Factory.CreateRibbonButton();
      this.MyItems.SuspendLayout();
      this.Octane.SuspendLayout();
      this.SuspendLayout();
      // 
      // MyItems
      // 
      this.MyItems.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
      this.MyItems.Groups.Add(this.Octane);
      this.MyItems.Label = "TabAddIns";
      this.MyItems.Name = "MyItems";
      // 
      // Octane
      // 
      this.Octane.Items.Add(this.SyncAll);
      this.Octane.Label = "My Items";
      this.Octane.Name = "Octane";
      // 
      // SyncAll
      // 
      this.SyncAll.Label = "Sync &All";
      this.SyncAll.Name = "SyncAll";
      this.SyncAll.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.SyncAll_Click);
      // 
      // Ribbon1
      // 
      this.Name = "Ribbon1";
      this.RibbonType = "Microsoft.Outlook.Mail.Read";
      this.Tabs.Add(this.MyItems);
      this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.Ribbon1_Load);
      this.MyItems.ResumeLayout(false);
      this.MyItems.PerformLayout();
      this.Octane.ResumeLayout(false);
      this.Octane.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    internal Microsoft.Office.Tools.Ribbon.RibbonTab MyItems;
    internal Microsoft.Office.Tools.Ribbon.RibbonGroup Octane;
    internal Microsoft.Office.Tools.Ribbon.RibbonButton SyncAll;
  }

  partial class ThisRibbonCollection
  {
    internal Ribbon1 Ribbon1
    {
      get { return this.GetRibbon<Ribbon1>(); }
    }
  }
}
