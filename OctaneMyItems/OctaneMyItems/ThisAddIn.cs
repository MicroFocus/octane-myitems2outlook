using OctaneMyItemsSyncService.Services;

namespace OctaneMyItems
{
  public partial class ThisAddIn
    {
        private static Configuration m_configuration;
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
 
        m_configuration = new Configuration(this.Application);
 
    }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
            // Note: Outlook no longer raises this event. If you have code that 
            //    must run when Outlook shuts down, see http://go.microsoft.com/fwlink/?LinkId=506785
        }
        public static Configuration Configuration
        {
          get {                
                return m_configuration; 
            }
        }

        public static void GetConfiguration()
        {
     
          m_configuration.GetConfiguration();
       }

    public static void ShowConfiguration()
    {

      m_configuration.ShowConfiguration();
    }
    public static async void SyncAll()
    {
      if (!m_configuration.IsInitialized)
      {
        m_configuration.GetConfiguration();
      }
      if (m_configuration.IsInitialized)
      {
        OctaneService octaneService = m_configuration.OctaneService;

        // sync backlog item
        OctaneTask.DeleteTask("[Octane]Backlog");
        var myBacklogs = await octaneService.GetMyBacklogs();
        foreach (OctaneMyItemsSyncService.Models.Backlog backlog in myBacklogs.data)
        {
          OctaneTask.CreateTask(backlog);
        }

        // sync run
        OctaneTask.DeleteTask("[Octane]Run");
        var runs = await octaneService.GetMyRuns();
        foreach (OctaneMyItemsSyncService.Models.Run run in runs.data)
        {
          OctaneTask.CreateTask(run);
        }

        // sync test
        OctaneTask.DeleteTask("[Octane]Test");
        var tests = await octaneService.GetMyTests();
        foreach (OctaneMyItemsSyncService.Models.Test test in tests.data)
        {
          OctaneTask.CreateTask(test);
        }

      }
    }

    public static async void SyncBacklogItem()
    {
      if (!m_configuration.IsInitialized)
      {
        m_configuration.GetConfiguration();
      }
      if (m_configuration.IsInitialized)
      {
        OctaneService octaneService = m_configuration.OctaneService;
        OctaneTask.DeleteTask("[Octane]Backlog");
        var myBacklogs = await octaneService.GetMyBacklogs();
        foreach(OctaneMyItemsSyncService.Models.Backlog backlog in myBacklogs.data)
        {
          OctaneTask.CreateTask(backlog);
        }
      }
    
    }
    public static async void SyncTest()
    {
      if (!m_configuration.IsInitialized)
      {
        m_configuration.GetConfiguration();
      }
      if (m_configuration.IsInitialized)
      {
        OctaneService octaneService = m_configuration.OctaneService;
        OctaneTask.DeleteTask("[Octane]Test");
        var tests = await octaneService.GetMyTests();
        foreach (OctaneMyItemsSyncService.Models.Test test in tests.data)
        {
          OctaneTask.CreateTask(test);
        }
      }
    }

    public static async void SyncRun()
    {
      if (!m_configuration.IsInitialized)
      {
        m_configuration.GetConfiguration();
      }
      if (m_configuration.IsInitialized)
      {
        OctaneService octaneService = m_configuration.OctaneService;
        OctaneTask.DeleteTask("[Octane]Run");
        var runs = await octaneService.GetMyRuns();
        foreach (OctaneMyItemsSyncService.Models.Run run in runs.data)
        {
          OctaneTask.CreateTask(run);
        }
      }
    }


    protected override Microsoft.Office.Core.IRibbonExtensibility CreateRibbonExtensibilityObject()
    {
      return new Ribbon2();
    }
    #region VSTO generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
  
}
