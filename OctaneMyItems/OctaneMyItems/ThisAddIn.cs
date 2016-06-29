﻿using OctaneMyItemsSyncService.Services;
using System.Threading.Tasks;

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
      get
      {
        return m_configuration;
      }
    }

    public static async Task<bool> GetConfiguration()
    {
      if (!m_configuration.IsInitialized)
      {
        await Task.Run(() =>
        {
          m_configuration.GetConfiguration();
        });
      }

      return m_configuration.IsInitialized;
    }

    public static void ShowConfiguration()
    {
      m_configuration.ShowConfiguration();
    }
    public static async Task SyncAll()
    {
      if (await GetConfiguration())
      {
        OctaneService octaneService = m_configuration.OctaneService;
        OctaneTask.AddOctaneCategories();

        // sync backlog item
        OctaneTask.DeleteTask(Constants.CategoryOctaneBacklog);
        var myBacklogs = await octaneService.GetMyBacklogs();
        foreach (OctaneMyItemsSyncService.Models.Backlog backlog in myBacklogs.data)
        {
          OctaneTask.CreateTask(backlog);
        }

        // sync run
        OctaneTask.DeleteTask(Constants.CategoryOctaneRun);
        var runs = await octaneService.GetMyRuns();
        foreach (OctaneMyItemsSyncService.Models.Run run in runs.data)
        {
          OctaneTask.CreateTask(run);
        }

        // sync test
        OctaneTask.DeleteTask(Constants.CategoryOctaneTest);
        var tests = await octaneService.GetMyTests();
        foreach (OctaneMyItemsSyncService.Models.Test test in tests.data)
        {
          OctaneTask.CreateTask(test);
        }

      }
    }

    public static async Task SyncBacklogItem()
    {
      if (await GetConfiguration())
      {
        OctaneService octaneService = m_configuration.OctaneService;
        OctaneTask.AddOctaneCategories();

        OctaneTask.DeleteTask(Constants.CategoryOctaneBacklog);
        var myBacklogs = await octaneService.GetMyBacklogs();
        foreach (OctaneMyItemsSyncService.Models.Backlog backlog in myBacklogs.data)
        {
          OctaneTask.CreateTask(backlog);
        }
      }

    }
    public static async Task SyncTest()
    {
      if (await GetConfiguration())
      {
        OctaneService octaneService = m_configuration.OctaneService;
        OctaneTask.AddOctaneCategories();

        OctaneTask.DeleteTask(Constants.CategoryOctaneTest);
        var tests = await octaneService.GetMyTests();
        foreach (OctaneMyItemsSyncService.Models.Test test in tests.data)
        {
          OctaneTask.CreateTask(test);
        }
      }
    }

    public static async Task SyncRun()
    {
      if (await GetConfiguration())
      {
        OctaneService octaneService = m_configuration.OctaneService;
        OctaneTask.AddOctaneCategories();

        OctaneTask.DeleteTask(Constants.CategoryOctaneRun);
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