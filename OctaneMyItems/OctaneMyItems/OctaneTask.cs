using System;
using Outlook = Microsoft.Office.Interop.Outlook;
using OctaneMyItemsSyncService.Models;
namespace OctaneMyItems
{
  public class OctaneTask
  {
    public static Outlook.Application m_outlookApp;
    public static void CreateTask(Backlog backlog)
    {
      m_outlookApp = Globals.ThisAddIn.Application.Application;
      if(m_outlookApp == null)
      {
        m_outlookApp = new Outlook.Application();
      }

      Outlook.TaskItem oTask = m_outlookApp.CreateItem(Outlook.OlItemType.olTaskItem);
      oTask.Categories = "Octane Task";
      oTask.Subject = "This is my task subject";
      oTask.DueDate = Convert.ToDateTime("06/28/2016");
      oTask.StartDate = Convert.ToDateTime("06/30/2016");
      oTask.ReminderSet = true;
      oTask.ReminderTime = Convert.ToDateTime("06/28/2016 02:40:00 PM");
      oTask.Body = "This is the task body";
      oTask.SchedulePlusPriority = "High";
      oTask.Status = Microsoft.Office.Interop.Outlook.OlTaskStatus.olTaskInProgress;
      oTask.Body = "<html><body>this is sample</body></html>";
      Outlook.UserProperty prop = oTask.UserProperties.Add("my prop", Outlook.OlUserPropertyType.olText);
      prop.Value = "hello";
      
      oTask.Save();
      

      Outlook.Recipients oReceipients = oTask.Recipients;
      Outlook.Recipient oReceipient;
      oReceipient = oReceipients.Add("xintian@hotmail.com");
      oReceipient.Type = 1;
      oReceipients.ResolveAll();
      oTask.Assign();
      ((Outlook._TaskItem)oTask).Send();
    }
  }
}
