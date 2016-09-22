using OctaneMyItems.Properties;
using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using Office = Microsoft.Office.Core;

namespace OctaneMyItems
{
  [ComVisible(true)]
  public class OctaneSyncRibbon : Office.IRibbonExtensibility
  {
    #region Private Fields

    private Office.IRibbonUI ribbon;

    private const string SyncAllId = "syncAll";
    private const string SyncBacklogId = "syncBacklogItem";
    private const string SyncTestId = "syncTest";
    private const string SyncRunId = "syncRun";
    private const string ConfigureId = "configuration";
    private const string SyncOneOctaneItemContextMenuId = "syncOneOctaneItemContextMenu";

    private bool _isSyncAllEnable = true;
    private bool _isSyncBacklogEnable = true;
    private bool _isSyncTestEnable = true;
    private bool _isSyncRunEnable = true;
    private bool _isConfigurationEnable = true; 

    #endregion

    #region IRibbonExtensibility Members

    public string GetCustomUI(string ribbonID)
    {
      return GetResourceText("OctaneMyItems.OctaneSyncRibbon.xml");
    }

    #endregion

    #region Ribbon Callbacks
    //Create callback methods here. For more information about adding callback methods, visit http://go.microsoft.com/fwlink/?LinkID=271226

    public void Ribbon_Load(Office.IRibbonUI ribbonUI)
    {
      ribbon = ribbonUI;
    }

    public Bitmap GetButtonIcon(Office.IRibbonControl button)
    {
      switch (button.Id)
      {
        case ConfigureId: return Resources.configuration;
        case SyncAllId: return Resources.sync_all;
        case SyncBacklogId: return Resources.sync_backlog;
        case SyncTestId: return Resources.sync_test;
        case SyncRunId: return Resources.sync_run;
        case SyncOneOctaneItemContextMenuId: return Resources.sync_all;
        default: break;
      }
      return null;
    }

    public bool GetEnable(Office.IRibbonControl control)
    {
      switch (control.Id)
      {
        case SyncAllId: return _isSyncAllEnable;
        case SyncBacklogId: return _isSyncBacklogEnable;
        case SyncTestId: return _isSyncTestEnable;
        case SyncRunId: return _isSyncRunEnable;
        case ConfigureId: return _isConfigurationEnable;
        default: return true;
      }
    }

    public async void OnSyncAllPressed(Office.IRibbonControl control)
    {
      DisableButtons();
      await ThisAddIn.SyncAll();
      EnableButtons();
    }
    public async void OnSyncBacklogItemPressed(Office.IRibbonControl control)
    {
      DisableButtons();
      await ThisAddIn.SyncBacklog();
      EnableButtons();
    }
    public async void OnSyncTestPressed(Office.IRibbonControl control)
    {
      DisableButtons();
      await ThisAddIn.SyncTest();
      EnableButtons();
    }
    public async void OnSyncRunPressed(Office.IRibbonControl control)
    {
      DisableButtons();
      await ThisAddIn.SyncRun();
      EnableButtons();
    }

    public void OnConfigurationPressed(Office.IRibbonControl control)
    {
      ThisAddIn.ShowConfiguration();
    }

    public async void OnSyncOneOctaneItemClicked(Office.IRibbonControl control)
    {
      await ThisAddIn.SyncOne();
    }
    
    #endregion

    #region Private methods

    private void DisableButtons()
    {
      _isSyncAllEnable = false;
      _isSyncBacklogEnable = false;
      _isSyncTestEnable = false;
      _isSyncRunEnable = false;
      _isConfigurationEnable = false;

      ribbon.Invalidate();
    }

    private void EnableButtons()
    {
      _isSyncAllEnable = true;
      _isSyncBacklogEnable = true;
      _isSyncTestEnable = true;
      _isSyncRunEnable = true;
      _isConfigurationEnable = true;

      ribbon.Invalidate();
    }

    private static string GetResourceText(string resourceName)
    {
      Assembly asm = Assembly.GetExecutingAssembly();
      string[] resourceNames = asm.GetManifestResourceNames();
      for (int i = 0; i < resourceNames.Length; ++i)
      {
        if (string.Compare(resourceName, resourceNames[i], StringComparison.OrdinalIgnoreCase) == 0)
        {
          using (StreamReader resourceReader = new StreamReader(asm.GetManifestResourceStream(resourceNames[i])))
          {
            if (resourceReader != null)
            {
              return resourceReader.ReadToEnd();
            }
          }
        }
      }
      return null;
    }

    #endregion
  }
}
