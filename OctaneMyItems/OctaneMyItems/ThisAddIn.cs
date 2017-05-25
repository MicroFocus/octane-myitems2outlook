/* 
  (c) Copyright 2016 Hewlett Packard Enterprise Development LP

  Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with the License.

  You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0

  Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an "AS IS" BASIS,

  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.

  See the License for the specific language governing permissions and limitations under the License.
*/

using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace OctaneMyItems
{
  public partial class ThisAddIn
  {
    private static readonly log4net.ILog m_log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    private static Configuration m_configuration;
    private void ThisAddIn_Startup(object sender, System.EventArgs e)
    {
      m_log.Info("startup...");
      m_configuration = new Configuration(this.Application);
    }

    private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
    {
      // Note: Outlook no longer raises this event. If you have code that 
      //    must run when Outlook shuts down, see http://go.microsoft.com/fwlink/?LinkId=506785
      m_log.Info("shutdown.");
    }

    #region Public Members

    public static Configuration Configuration
    {
      get
      {
        return m_configuration;
      }
    }

    public async static Task<bool> GetConfiguration()
    {
      if (!m_configuration.IsInitialized)
        await m_configuration.GetConfiguration();

      return m_configuration.IsInitialized;
    }

    public static void ShowConfiguration()
    {
      m_configuration.ShowConfiguration();
    }

    public static async Task SyncOne()
    {
      m_log.Info($"{nameof(SyncOne)}");
      try
      {
        await Utilities.SyncOne();
      }
      catch (HttpRequestException ex)
      {
        m_log.Error(ex);
        if(ex.Message.Contains("401"))
        {
          MessageBox.Show(Messages.NeedEnterCredential);
          ShowConfiguration();
        }
      }
      catch (Exception ex)
      {
        m_log.Error(ex);
        MessageBox.Show(ex.ToString());
      }
    }
    public static async Task SyncAll()
    {
      m_log.Info($"{nameof(SyncAll)}");
      try
      {
        if (await GetConfiguration())
        {
          var octaneService = m_configuration.OctaneService;
          Utilities.AddOctaneCategories();

          var task1 = Task.Factory.StartNew(() =>
          {
            m_log.Info("sync backlog item");
            var myBacklogs = octaneService.GetMyBacklogs().Result;
            Utilities.ClearOldTaskItem(myBacklogs.data, Constants.CategoryOctaneBacklog).Wait();
            foreach (OctaneMyItemsSyncService.Models.Backlog backlog in myBacklogs.data)
              Utilities.CreateTask(backlog).Wait();
          });

          var task2 = Task.Factory.StartNew(() =>
          {
            m_log.Info("sync run");
            var runs = octaneService.GetMyRuns().Result;
            Utilities.ClearOldTaskItem(runs.data, Constants.CategoryOctaneRun).Wait();
            foreach (OctaneMyItemsSyncService.Models.Run run in runs.data)
              Utilities.CreateTask(run).Wait();
          });

          var task3 = Task.Factory.StartNew(() =>
          {
            m_log.Info("sync test");
            var tests = octaneService.GetMyTests().Result;
            Utilities.ClearOldTaskItem(tests.data, Constants.CategoryOctaneTest).Wait();
            foreach (OctaneMyItemsSyncService.Models.Test test in tests.data)
              Utilities.CreateTask(test).Wait();
          });

          await Task.WhenAll(new Task[] { task1, task2, task3 });

          UpdateCurrentSelection();
        }
      }
      catch (HttpRequestException ex)
      {
        m_log.Error(ex);
        if (ex.Message.Contains("401"))
        {
          MessageBox.Show(Messages.NeedEnterCredential);
          ShowConfiguration();
        }
      }
      catch (Exception ex)
      {
        m_log.Error(ex);
        MessageBox.Show(ex.ToString());
      }
    }

    public static async Task SyncBacklog()
    {
      m_log.Info($"{nameof(SyncBacklog)}");
      try
      {
        if (await GetConfiguration())
        {
          Utilities.AddOctaneCategories();

          var myBacklogs = await m_configuration.OctaneService.GetMyBacklogs();
          await Utilities.ClearOldTaskItem(myBacklogs.data, Constants.CategoryOctaneBacklog);
          foreach (OctaneMyItemsSyncService.Models.Backlog backlog in myBacklogs.data)
            await Utilities.CreateTask(backlog).ConfigureAwait(false);
          UpdateCurrentSelection();
        }
      }
      catch (HttpRequestException ex)
      {
        m_log.Error(ex);
        if (ex.Message.Contains("401"))
        {
          MessageBox.Show(Messages.NeedEnterCredential);
          ShowConfiguration();
        }
      }
      catch (Exception ex)
      {
        m_log.Error(ex);
        MessageBox.Show(ex.ToString());
      }
    }
    public static async Task SyncTest()
    {
      m_log.Info($"{nameof(SyncTest)}");
      try
      {
        if (await GetConfiguration())
        {
          Utilities.AddOctaneCategories();

          var tests = await m_configuration.OctaneService.GetMyTests();
          await Utilities.ClearOldTaskItem(tests.data, Constants.CategoryOctaneTest);
          foreach (OctaneMyItemsSyncService.Models.Test test in tests.data)
            await Utilities.CreateTask(test).ConfigureAwait(false);
          UpdateCurrentSelection();
        }
      }
      catch (HttpRequestException ex)
      {
        m_log.Error(ex);
        if (ex.Message.Contains("401"))
        {
          MessageBox.Show(Messages.NeedEnterCredential);
          ShowConfiguration();
        }
      }
      catch (Exception ex)
      {
        m_log.Error(ex);
        MessageBox.Show(ex.ToString());
      }
    }
    public static async Task SyncRun()
    {
      m_log.Info($"{nameof(SyncRun)}");
      try
      {
        if (await GetConfiguration())
        {
          Utilities.AddOctaneCategories();

          var runs = await m_configuration.OctaneService.GetMyRuns();
          await Utilities.ClearOldTaskItem(runs.data, Constants.CategoryOctaneRun);
          foreach (OctaneMyItemsSyncService.Models.Run run in runs.data)
            await Utilities.CreateTask(run).ConfigureAwait(false);
          UpdateCurrentSelection();
        }
      }
      catch (HttpRequestException ex)
      {
        m_log.Error(ex);
        if (ex.Message.Contains("401"))
        {
          MessageBox.Show(Messages.NeedEnterCredential);
          ShowConfiguration();
        }
      }
      catch (Exception ex)
      {
        m_log.Error(ex);
        MessageBox.Show(ex.ToString());
      }
    } 

    #endregion

    private static void UpdateCurrentSelection()
    {
      var explorer = Globals.ThisAddIn.Application.Application.ActiveExplorer();
      try
      {
        if (explorer.Selection[1] is Outlook.TaskItem)
          ((Outlook.TaskItem)explorer.Selection[1]).Close(Outlook.OlInspectorClose.olSave);
      }
      catch (System.Exception)
      {
      }
    }

    protected override Microsoft.Office.Core.IRibbonExtensibility CreateRibbonExtensibilityObject()
    {
      return new OctaneSyncRibbon();
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