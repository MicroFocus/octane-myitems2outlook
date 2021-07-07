/* 
  (c) Copyright 2016 Hewlett Packard Enterprise Development LP

  Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with the License.

  You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0

  Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an "AS IS" BASIS,

  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.

  See the License for the specific language governing permissions and limitations under the License.
*/

using Newtonsoft.Json;
using OctaneMyItemsSyncService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace OctaneMyItems
{
  public class Utilities
  {
    #region Properties

    private static Outlook.Application m_outlookApp;
    private static Outlook.Application OutlookApp
    {
      get { return m_outlookApp 
          ?? (m_outlookApp = new Outlook.Application()); }
    }

    private static Outlook.Folder tasksList;
    private static Outlook.Folder TasksList
    {
      get
      {
        return tasksList ??
            (tasksList = OutlookApp.Session.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderTasks) as Outlook.Folder);
      }
    }

    #endregion

    #region Public Methods

    public async static Task SyncOne()
    {
      var explorer = OutlookApp.ActiveExplorer();
      if (explorer.Selection.Count > 0)
      {
        var oTask = explorer.Selection[1] as Outlook.TaskItem;
        if (oTask != null)
        {
          var octaneId = oTask.UserProperties[Constants.OctaneId];
          if (octaneId != null)
          {
            string id = octaneId.Value;
            if (await ThisAddIn.GetConfiguration())
            {
              if (id.Contains(Constants.BackLog))
              {
                var item = await ThisAddIn.Configuration.OctaneService.GetMyBacklog(id.Replace(Constants.BackLog, ""));
                UpdateTaskItem(item, oTask);
              }
              else if (id.Contains(Constants.Run))
              {
                var item = await ThisAddIn.Configuration.OctaneService.GetMyRun(id.Replace(Constants.Run, ""));
                UpdateTaskItem(item, oTask);
              }
              else if (id.Contains(Constants.Test))
              {
                var item = await ThisAddIn.Configuration.OctaneService.GetMyTest(id.Replace(Constants.Test, ""));
                UpdateTaskItem(item, oTask);
              }
            }
          }
        }
      }
    }

    public async static Task CreateTask(object octaneItem)
    {
      if (octaneItem == null) return;

      await Task.Run(() =>
      {
        var oTask = GetExistOctaneTaskItem(TasksList, octaneItem);
        var isExist = oTask != null ? true : false;
        if (!isExist)
        {
          oTask = TasksList.Items.Add(Constants.OctaneTask) as Outlook.TaskItem;
          oTask.UserProperties.Add(Constants.OctaneId, Outlook.OlUserPropertyType.olText);
          oTask.UserProperties.Add(Constants.Octane, Outlook.OlUserPropertyType.olText);
        }

        UpdateTaskItem(octaneItem, oTask);
      });
    }

    public async static Task ClearOldTaskItem(object[] newOctaneItems, string category)
    {
      await Task.Run(() =>
      {
        var needClearList = new List<Outlook.TaskItem>();

        foreach (Outlook.TaskItem oldTask in TasksList.Items)
        {
          if (oldTask.Categories != category) continue;
          var oldOctaneId = oldTask.UserProperties[Constants.OctaneId];
          if (oldOctaneId == null) continue;

          bool isExist = false;
          foreach (var newTask in newOctaneItems)
          {
            var id = "";
            if (newTask is Backlog) id = Constants.BackLog + ((Backlog)newTask).id.ToString();
            if (newTask is Run) id = Constants.Run + ((Run)newTask).id.ToString();
            if (newTask is Test) id = Constants.Test + ((Test)newTask).id.ToString();

            if (id == oldOctaneId.Value.ToString())
            {
              isExist = true;
              break;
            }
          }
          if (!isExist) needClearList.Add(oldTask);
        }
        needClearList.ForEach(x => x.Delete());
      });
    }

    public static void AddOctaneCategories()
    {
      var categories = OutlookApp.Session.Categories;

      if (!CategoryExists(categories, Constants.CategoryOctaneBacklog))
      {
        categories.Add(Constants.CategoryOctaneBacklog,
          Outlook.OlCategoryColor.olCategoryColorDarkBlue);
      }

      if (!CategoryExists(categories, Constants.CategoryOctaneTest))
      {
        categories.Add(Constants.CategoryOctaneTest,
          Outlook.OlCategoryColor.olCategoryColorDarkGreen);
      }

      if (!CategoryExists(categories, Constants.CategoryOctaneRun))
      {
        categories.Add(Constants.CategoryOctaneRun,
          Outlook.OlCategoryColor.olCategoryColorYellow);
      }
    } 

    #endregion

    #region Private Fields

    private static void UpdateTaskItem(object octaneItem, Outlook.TaskItem oTask)
    {
      if (octaneItem == null)
      {
        var result = MessageBox.Show(
          Messages.OctaneItemNotAccessable,
          "Info", MessageBoxButtons.OKCancel);
        if (result == DialogResult.OK)
          oTask.Delete();
        return;
      }

      Outlook.UserProperty octaneId = oTask.UserProperties[Constants.OctaneId];
      Outlook.UserProperty octane = oTask.UserProperties[Constants.Octane];
      octane.Value = JsonConvert.SerializeObject(octaneItem);

      if (octaneItem is Backlog)
      {
        var item = octaneItem as Backlog;
        oTask.Categories = Constants.CategoryOctaneBacklog;
        oTask.Subject = "[" + item.subtype.ToUpper() + ":" + item.id + "] " + item.name;

        octaneId.Value = Constants.BackLog + item.id;
        if (Constants.Story.Equals(item.subtype, System.StringComparison.OrdinalIgnoreCase))
          octane.ValidationText = Constants.Story;
        else
          octane.ValidationText = Constants.Defect;
      }
      else if (octaneItem is Run)
      {
        var item = octaneItem as Run;
        oTask.Categories = Constants.CategoryOctaneRun;
        oTask.Subject = "[" + item.id + "] " + item.name;

        octaneId.Value = Constants.Run + item.id;
        octane.ValidationText = Constants.Run;
      }
      else if (octaneItem is Test)
      {
        var item = octaneItem as Test;
        oTask.Categories = Constants.CategoryOctaneTest;
        oTask.Subject = "[" + item.id + "] " + item.name;

        octaneId.Value = Constants.Test + item.id;
        octane.ValidationText = Constants.Test;
      }

      oTask.Save();
      oTask.Close(Outlook.OlInspectorClose.olSave);
    }

    private static Outlook.TaskItem GetExistOctaneTaskItem(Outlook.Folder taskList, object item)
    {
      foreach (Outlook.TaskItem task in taskList.Items)
      {
        var id = task.UserProperties[Constants.OctaneId];
        if (id != null)
        {
          if (item is Backlog && Constants.BackLog + ((Backlog)item).id == id.Value) return task;
          if (item is Run && Constants.Run + ((Run)item).id == id.Value) return task;
          if (item is Test && Constants.Test + ((Test)item).id == id.Value) return task;
        }
      }

      return null;
    }

    private static bool CategoryExists(Outlook.Categories categories, string categoryName)
    {
      try
      {
        return categories[categoryName] != null ? true : false;
      }
      catch
      {
        return false;
      }
    }

    #endregion
  }
}
