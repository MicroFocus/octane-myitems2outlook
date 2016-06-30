﻿using Newtonsoft.Json;
using OctaneMyItemsSyncService.Models;
using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace OctaneMyItems
{
  partial class OctaneTaskDetail
  {
    #region Form Region Factory 

    [Microsoft.Office.Tools.Outlook.FormRegionMessageClass("IPM.Task.Octane")]
    [Microsoft.Office.Tools.Outlook.FormRegionName("OctaneMyItems.OctaneTaskDetail")]
    public partial class OctaneTaskDetailFactory
    {
      // Occurs before the form region is initialized.
      // To prevent the form region from appearing, set e.Cancel to true.
      // Use e.OutlookItem to get a reference to the current Outlook item.
      private void OctaneTaskDetailFactory_FormRegionInitializing(object sender, Microsoft.Office.Tools.Outlook.FormRegionInitializingEventArgs e)
      {
      }
    }

    #endregion

    // Occurs before the form region is displayed.
    // Use this.OutlookItem to get a reference to the current Outlook item.
    // Use this.OutlookFormRegion to get a reference to the form region.
    private void OctaneTaskDetail_FormRegionShowing(object sender, System.EventArgs e)
    {
      var octaneTask = this.OutlookItem as Outlook.TaskItem;
      var octane = octaneTask.UserProperties["Octane"];
      if (octane == null) return;

      tabControl1.TabPages.Remove(tp_runSteps);
      tabControl1.TabPages.Remove(tp_testSteps);
      try
      {
        if ("\"Defect\"".Equals(octane.ValidationText, StringComparison.OrdinalIgnoreCase))
        {
          Backlog backlog = JsonConvert.DeserializeObject<Backlog>(octane.Value);
          Controls.Add(GetChildControl(new FieldsDetail_Defect(backlog)));
          wb_description.DocumentText = GenerateDescriptHtml(backlog.description);
          wb_comments.DocumentText = GenerateCommentsHtml(backlog.comments);
        }
        else if ("\"Story\"".Equals(octane.ValidationText, StringComparison.OrdinalIgnoreCase))
        {
          Backlog story = JsonConvert.DeserializeObject<Backlog>(octane.Value);
          Controls.Add(GetChildControl(new FieldsDetail_Story(story)));
          wb_description.DocumentText = GenerateDescriptHtml(story.description);
          wb_comments.DocumentText = GenerateCommentsHtml(story.comments);
        }
        else if ("\"Run\"".Equals(octane.ValidationText, StringComparison.OrdinalIgnoreCase))
        {
          Run run = JsonConvert.DeserializeObject<Run>(octane.Value);
          Controls.Add(GetChildControl(new FieldsDetail_Run(run)));
          wb_description.DocumentText = GenerateDescriptHtml(run.description);
          wb_comments.DocumentText = GenerateCommentsHtml(run.comments);
          tabControl1.TabPages.Add(tp_runSteps);
          if (run.steps != null)
          {
            var html = new StringBuilder();
            html.Append("<html><body style=\"overflow: auto\">");
            foreach (var item in run.steps?.data)
            {
              html.Append($"<div>{item.description}</div>");
            }
            html.Append("</body></html>");
            wb_runSteps.DocumentText = html.ToString();
          }
        }
        else if ("\"Test\"".Equals(octane.ValidationText, StringComparison.OrdinalIgnoreCase))
        {
          Test test = JsonConvert.DeserializeObject<Test>(octane.Value);
          Controls.Add(GetChildControl(new FieldsDetail_Test(test)));
          wb_description.DocumentText = GenerateDescriptHtml(test.description);
          wb_comments.DocumentText = GenerateCommentsHtml(test.comments);
          tabControl1.TabPages.Add(tp_testSteps);
          rtb_testSteps.Text = test.script;
        }
        else
        {
          Visible = false;
          Height = 0;
        }
      }
      catch (Exception ex)
      {
        System.Windows.Forms.MessageBox.Show(ex.Message);
        Visible = false;
        Height = 0;
      }
    }

    private Control GetChildControl(Control parentControl)
    {
      var control = parentControl.Controls[0];
      control.Dock = System.Windows.Forms.DockStyle.Top;
      control.Padding = new System.Windows.Forms.Padding(5);
      return control;
    }

    private string GenerateDescriptHtml(string descript)
    {
      if (string.IsNullOrEmpty(descript)) return string.Empty;
      return descript.Replace("<body>", "<body style=\"overflow: auto\">");
    }

    private readonly string commentTemplate =
@"<div style=""margin: 10px;"">		<div style=""background-color: #ededed;height: 30px;"">
      <span style=""font-size:18px;position:relative;top:4px;color:blue;font-weight:bold;""> name </span>			<span style=""font-size:14px;position:relative;top:4px;""> time </span>
    </div>
    <div> comment </div></div>";
    private string GenerateCommentsHtml(Comments comments)
    {
      if (comments == null || comments.data == null || comments.data.Count() == 0)
        return string.Empty;

      var html = new StringBuilder();
      html.Append("<!DOCTYPE html><html><body style=\"overflow: auto\">");
      foreach (Comment item in comments.data)
      {
        html.Append(commentTemplate
          .Replace("name", item.author.name)
          .Replace("time", item.last_modified.ToString())
          .Replace("comment", item.text?
            .Replace("<html>", "").Replace("</html>", "").Replace("<body>", "").Replace("</body>", "")));
      }
      html.Append("</body></html>");

      return html.ToString();
    }

    // Occurs when the form region is closed.
    // Use this.OutlookItem to get a reference to the current Outlook item.
    // Use this.OutlookFormRegion to get a reference to the form region.
    private void OctaneTaskDetail_FormRegionClosed(object sender, System.EventArgs e)
    {
    }
  }
}
