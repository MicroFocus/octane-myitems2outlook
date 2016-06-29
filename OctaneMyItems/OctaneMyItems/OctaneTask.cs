using Newtonsoft.Json;
using OctaneMyItemsSyncService.Models;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace OctaneMyItems
{
  public class OctaneTask
  {
    public static Outlook.Application m_outlookApp;
    public static void CreateTask(object octaneItem)
    {
      m_outlookApp = Globals.ThisAddIn.Application.Application;
      if(m_outlookApp == null)
      {
        m_outlookApp = new Outlook.Application();
      }

      var taskList = m_outlookApp.Session.GetDefaultFolder(
        Outlook.OlDefaultFolders.olFolderTasks) as Outlook.Folder;
      var oTask = taskList.Items.Add("IPM.Task.Octane") as Outlook.TaskItem;

      oTask.Categories = "Octane Task";
      Outlook.UserProperty octane = oTask.UserProperties.Add("Octane", Outlook.OlUserPropertyType.olText);
      octane.Value = JsonConvert.SerializeObject(octaneItem);

      if (octaneItem is Backlog)
      {
        var backlog = octaneItem as Backlog;
        oTask.Subject = backlog.name;
        if("Story".Equals(backlog.subtype, System.StringComparison.OrdinalIgnoreCase))
          octane.ValidationText = "Story";
        else
          octane.ValidationText = "Defect";
      }
      else if(octaneItem is Run)
      {
        var run = octaneItem as Run;
        oTask.Subject = run.name;
        octane.ValidationText = "Run";
      }
      else if(octaneItem is Test)
      {
        var test = octaneItem as Test;
        oTask.Subject = test.name;
        octane.ValidationText = "Test";
      }      
      oTask.Save();
      

      //Outlook.Recipients oReceipients = oTask.Recipients;
      //Outlook.Recipient oReceipient;
      //oReceipient = oReceipients.Add("xintian@hotmail.com");
      //oReceipient.Type = 1;
      //oReceipients.ResolveAll();
      //oTask.Assign();
      //((Outlook._TaskItem)oTask).Send();
    }
  }
}
