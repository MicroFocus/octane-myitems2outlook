using Newtonsoft.Json;
using OctaneMyItemsSyncService.Models;
using System.Collections.Generic;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace OctaneMyItems
{
  public class Constants
  {
    //category constants
    public const string CategoryOctaneBacklog = "[Octane]Backlog";
    public const string CategoryOctaneTest = "[Octane]Test";
    public const string CategoryOctaneRun = "[Octane]Run";

  }
  public class OctaneTask
  {

    public static Outlook.Application m_outlookApp;
public static void SyncOne()
{
 
    }

    public static void CreateTask(object octaneItem)
    {
      m_outlookApp = Globals.ThisAddIn.Application.Application;
      if (m_outlookApp == null)
      {
        m_outlookApp = new Outlook.Application();
      }

      var taskList = m_outlookApp.Session.GetDefaultFolder(
        Outlook.OlDefaultFolders.olFolderTasks) as Outlook.Folder;
      var oTask = taskList.Items.Add("IPM.Task.Octane") as Outlook.TaskItem;


      Outlook.UserProperty octane = oTask.UserProperties.Add("Octane", Outlook.OlUserPropertyType.olText);
      octane.Value = JsonConvert.SerializeObject(octaneItem);

      if (octaneItem is Backlog)
      {
        oTask.Categories = Constants.CategoryOctaneBacklog;
        var backlog = octaneItem as Backlog;
        oTask.Subject = "[" + backlog.subtype.ToUpper() + ":" + backlog.id + "] " + backlog.name;
        if ("Story".Equals(backlog.subtype, System.StringComparison.OrdinalIgnoreCase))
          octane.ValidationText = "Story";
        else
          octane.ValidationText = "Defect";
      }
      else if (octaneItem is Run)
      {
        oTask.Categories = Constants.CategoryOctaneRun;
        var run = octaneItem as Run;
        oTask.Subject = "[" + run.id + "] " + run.name;
        octane.ValidationText = "Run";
      }
      else if (octaneItem is Test)
      {
        oTask.Categories = Constants.CategoryOctaneTest;
        var test = octaneItem as Test;
        oTask.Subject = "[" + test.id + "] " + test.name;
        octane.ValidationText = "Test";
      }
      oTask.Save();
    }

    public static void DeleteTask(string category)
    {
      m_outlookApp = Globals.ThisAddIn.Application.Application;
      if (m_outlookApp == null)
      {
        m_outlookApp = new Outlook.Application();
      }

      var taskList = m_outlookApp.Session.GetDefaultFolder(
        Outlook.OlDefaultFolders.olFolderTasks) as Outlook.Folder;
      var oTasks = taskList.Items;
      var deleteList = new List<Outlook.TaskItem>();
      foreach (Outlook.TaskItem task in oTasks)
      {
        if (task.Categories == category)
          deleteList.Add(task);
      }
      deleteList.ForEach(x => x.Delete());
    }

    public static void AddOctaneCategories()
    {
      m_outlookApp = Globals.ThisAddIn.Application.Application;
      if (m_outlookApp == null)
      {
        m_outlookApp = new Outlook.Application();
      }

      Outlook.Categories categories =
          m_outlookApp.Session.Categories;

      string categoryName = Constants.CategoryOctaneBacklog;
      if (!CategoryExists(categories, categoryName))
      {
        Outlook.Category category = categories.Add(categoryName,
            Outlook.OlCategoryColor.olCategoryColorDarkBlue);
      }
      categoryName = Constants.CategoryOctaneTest;
      if (!CategoryExists(categories, categoryName))
      {
        Outlook.Category category = categories.Add(categoryName,
            Outlook.OlCategoryColor.olCategoryColorDarkGreen);
      }
      categoryName = Constants.CategoryOctaneRun;
      if (!CategoryExists(categories, categoryName))
      {
        Outlook.Category category = categories.Add(categoryName,
            Outlook.OlCategoryColor.olCategoryColorYellow);
      }
    }

    private static bool CategoryExists(Outlook.Categories categories, string categoryName)
    {
      try
      {
        Outlook.Category category =
            categories[categoryName];
        if (category != null)
        {
          return true;
        }
        else
        {
          return false;
        }
      }
      catch { return false; }
    }
  }
}
