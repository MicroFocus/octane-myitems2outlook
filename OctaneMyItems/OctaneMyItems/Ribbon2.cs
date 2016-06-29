using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using Office = Microsoft.Office.Core;
using System.Drawing;

// TODO:  Follow these steps to enable the Ribbon (XML) item:

// 1: Copy the following code block into the ThisAddin, ThisWorkbook, or ThisDocument class.



// 2. Create callback methods in the "Ribbon Callbacks" region of this class to handle user
//    actions, such as clicking a button. Note: if you have exported this Ribbon from the Ribbon designer,
//    move your code from the event handlers to the callback methods and modify the code to work with the
//    Ribbon extensibility (RibbonX) programming model.

// 3. Assign attributes to the control tags in the Ribbon XML file to identify the appropriate callback methods in your code.  

// For more information, see the Ribbon XML documentation in the Visual Studio Tools for Office Help.


namespace OctaneMyItems
{
  [ComVisible(true)]
  public class Ribbon2 : Office.IRibbonExtensibility
  {
    private Office.IRibbonUI ribbon;
    private const string SyncAllId = "syncAll";
    private const string SyncBacklogId = "syncBacklogItem";
    private const string SyncTestId = "syncTest";
    private const string SyncRunId = "syncRun";
    private const string ConfigureId = "configuration";

    public Ribbon2()
    {
    }

    #region IRibbonExtensibility Members

    public string GetCustomUI(string ribbonID)
    {
      return GetResourceText("OctaneMyItems.Ribbon2.xml");
    }

    #endregion

    #region Ribbon Callbacks
    //Create callback methods here. For more information about adding callback methods, visit http://go.microsoft.com/fwlink/?LinkID=271226

    public void Ribbon_Load(Office.IRibbonUI ribbonUI)
    {
      this.ribbon = ribbonUI;

    }
    public Bitmap GetButtonIcon(Office.IRibbonControl button)
    {
      // return  (Bitmap)Images.ResourceManager.GetObject(string.Format("{0}Icon", button.Id)));
      Bitmap bitmap = (Bitmap)Properties.Resources.ResourceManager.GetObject("OptionsButtonIcon");
      Stream s = this.GetType().Assembly.GetManifestResourceStream("OptionsButtonIcon");
      //this.GetType().Assembly
      Bitmap bmp = null;
      switch (button.Id)
      {
        case ConfigureId:
          bmp = Images.Resource.OptionsButtonIcon;
          break;
        case SyncAllId:
          bmp = Images.Resource.SyncAllButtonIcon;
          break;
        case SyncBacklogId:
          bmp = Images.Resource.SyncBacklogItemButtonIcon;
          break;
        case SyncTestId:
          bmp = Images.Resource.SyncTestButtonIcon;
          break;
        case SyncRunId:
          bmp = Images.Resource.SyncRunButtonIcon;
          break;
        default:
          break;
      }

      return bmp;
    }

    private bool _isSyncAllEnable = true;
    private bool _isSyncBacklogEnable = true;
    private bool _isSyncTestEnable = true;
    private bool _isSyncRunEnable = true;
    public bool GetEnable(Office.IRibbonControl control)
    {
      switch (control.Id)
      {
        case SyncAllId: return _isSyncAllEnable;
        case SyncBacklogId: return _isSyncBacklogEnable;
        case SyncTestId: return _isSyncTestEnable;
        case SyncRunId: return _isSyncRunEnable;
        default: return true;
      }
    }

    public async void OnSyncAllPressed(Office.IRibbonControl control)
    {
      _isSyncAllEnable = false;
      _isSyncBacklogEnable = false;
      _isSyncTestEnable = false;
      _isSyncRunEnable = false;
      ribbon.Invalidate();
      await ThisAddIn.SyncAll();
      _isSyncAllEnable = true;
      _isSyncBacklogEnable = true;
      _isSyncTestEnable = true;
      _isSyncRunEnable = true;
      ribbon.Invalidate();
    }
    public async void OnSyncBacklogItemPressed(Office.IRibbonControl control)
    {
      _isSyncBacklogEnable = false;
      ribbon.InvalidateControl(SyncBacklogId);
      await ThisAddIn.SyncBacklogItem();
      _isSyncBacklogEnable = true;
      ribbon.InvalidateControl(SyncBacklogId);
    }
    public async void OnSyncTestPressed(Office.IRibbonControl control)
    {
      _isSyncTestEnable = false;
      ribbon.InvalidateControl(SyncTestId);
      await ThisAddIn.SyncTest();
      _isSyncTestEnable = true;
      ribbon.InvalidateControl(SyncTestId);
    }
    public async void OnSyncRunPressed(Office.IRibbonControl control)
    {
      _isSyncRunEnable = false;
      ribbon.InvalidateControl(SyncRunId);
      await ThisAddIn.SyncRun();
      _isSyncRunEnable = true;
      ribbon.InvalidateControl(SyncRunId);
    }

    public void OnConfigurationPressed(Office.IRibbonControl control)
    {
      ThisAddIn.ShowConfiguration();
    }
    #endregion

    #region Helpers

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
