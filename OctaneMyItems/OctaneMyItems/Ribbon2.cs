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
       Bitmap bitmap =(Bitmap) Properties.Resources.ResourceManager.GetObject("OptionsButtonIcon");
      Stream s = this.GetType().Assembly.GetManifestResourceStream("OptionsButtonIcon");
      //this.GetType().Assembly
      string imageName = string.Empty;
      switch (button.Id)
      {
        case "configuration":
          imageName = "Options";
          break;
        case "syncAll":
          imageName = "SyncAll";
          break;
        case "syncBacklogItem":
          imageName = "syncBacklogItem";
          break;
        case "syncTest":
          imageName = "SyncTest";
          break;
        case "syncRun":
          imageName = "SyncRun";
          break;
        default:
          break;
      }

      string imagePath = string.Format(@"C:\Users\xitian\Source\Repos\D22438_My_Items_2_Outlook\OctaneMyItems\OctaneMyItems\Resources\{0}ButtonIcon.png", imageName);
      Bitmap bmp = new Bitmap(imagePath);
      return bmp;
    }

    public void OnSyncAllPressed(Office.IRibbonControl control)
    {
      ThisAddIn.SyncAll();
    }
    public void OnSyncBacklogItemPressed(Office.IRibbonControl control)
    {
      ThisAddIn.SyncBacklogItem();
    }
    public void OnSyncTestPressed(Office.IRibbonControl control)
    {
      ThisAddIn.SyncTest();
    }
    public void OnSyncRunPressed(Office.IRibbonControl control)
    {
      ThisAddIn.SyncRun();
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
