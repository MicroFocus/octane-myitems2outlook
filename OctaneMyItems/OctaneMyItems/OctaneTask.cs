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
    public async static void SyncOne()
    {
      m_outlookApp = Globals.ThisAddIn.Application.Application;
      if (m_outlookApp == null)
        m_outlookApp = new Outlook.Application();
      
      var explorer = m_outlookApp.ActiveExplorer();
      if (explorer.Selection.Count > 0)
      {
        var oTask = explorer.Selection[1] as Outlook.TaskItem;
        if (oTask != null)
        {
          var octaneId = oTask.UserProperties["OctaneId"];
          if (octaneId != null)
          {
            string id = octaneId.Value;
            object item = null;
            if (await ThisAddIn.GetConfiguration())
            {
              if (id.Contains("Backlog"))
                item = await ThisAddIn.Configuration.OctaneService.GetBacklog(int.Parse(id.Replace("Backlog", "")));
              if (id.Contains("Run"))
                item = await ThisAddIn.Configuration.OctaneService.GetRun(int.Parse(id.Replace("Run", "")));
              if (id.Contains("Test"))
                item = await ThisAddIn.Configuration.OctaneService.GetTest(int.Parse(id.Replace("Test", "")));

              if (item != null)
              {
                Outlook.UserProperty octane = oTask.UserProperties["Octane"];
                octane.Value = JsonConvert.SerializeObject(item);
                oTask.Save();
              }
            }
          }
        }
      }
    }

    public static void CreateTask(object octaneItem)
    {
      if (octaneItem == null) return;

      m_outlookApp = Globals.ThisAddIn.Application.Application;
      if (m_outlookApp == null)
        m_outlookApp = new Outlook.Application();

      var taskList = m_outlookApp.Session.GetDefaultFolder(
        Outlook.OlDefaultFolders.olFolderTasks) as Outlook.Folder;

      var oTask = GetExistOctaneTaskItem(taskList, octaneItem);
      var isExist = oTask != null ? true : false;
      if(!isExist)
      {
        oTask = taskList.Items.Add("IPM.Task.Octane") as Outlook.TaskItem;
        oTask.UserProperties.Add("OctaneId", Outlook.OlUserPropertyType.olText);
        oTask.UserProperties.Add("Octane", Outlook.OlUserPropertyType.olText);
      }

      Outlook.UserProperty octaneId = oTask.UserProperties["OctaneId"];
      Outlook.UserProperty octane = oTask.UserProperties["Octane"];
      octane.Value = JsonConvert.SerializeObject(octaneItem);

      if (isExist) return;

      if (octaneItem is Backlog)
      {
        var item = octaneItem as Backlog;
        oTask.Categories = Constants.CategoryOctaneBacklog;
        oTask.Subject = "[" + item.subtype.ToUpper() + ":" + item.id + "] " + item.name;

        octaneId.Value = "Backlog" + item.id;
        if ("Story".Equals(item.subtype, System.StringComparison.OrdinalIgnoreCase))
          octane.ValidationText = "Story";
        else
          octane.ValidationText = "Defect";
      }
      else if (octaneItem is Run)
      {
        var item = octaneItem as Run;
        oTask.Categories = Constants.CategoryOctaneRun;
        oTask.Subject = "[" + item.id + "] " + item.name;

        octaneId.Value = "Run" + item.id;
        octane.ValidationText = "Run";
      }
      else if (octaneItem is Test)
      {
        var item = octaneItem as Test;
        oTask.Categories = Constants.CategoryOctaneTest;
        oTask.Subject = "[" + item.id + "] " + item.name;

        octaneId.Value = "Test" + item.id;
        octane.ValidationText = "Test";
      }
      oTask.Save();
    }

    private static Outlook.TaskItem GetExistOctaneTaskItem(Outlook.Folder taskList, object item)
    {
      foreach (Outlook.TaskItem task in taskList.Items)
      {
        var id = task.UserProperties["OctaneId"];
        if (id != null)
        {
          if (item is Backlog && "Backlog" + ((Backlog)item).id == id.Value) return task;
          if (item is Run && "Run" + ((Run)item).id == id.Value) return task;
          if (item is Test && "Test" + ((Test)item).id == id.Value) return task;
        }
      }

      return null;
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
