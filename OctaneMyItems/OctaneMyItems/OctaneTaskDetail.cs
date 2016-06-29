using Newtonsoft.Json;
using OctaneMyItemsSyncService.Models;
using System;
using System.Linq;
using System.Text;
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
          p_fields.Controls.Add(new FieldsDetail_Defect(backlog) { Dock = System.Windows.Forms.DockStyle.Fill });
          wb_description.DocumentText = backlog.description;
        }
        else if ("\"Story\"".Equals(octane.ValidationText, StringComparison.OrdinalIgnoreCase))
        {
          Backlog story = JsonConvert.DeserializeObject<Backlog>(octane.Value);
          p_fields.Controls.Add(new FieldsDetail_Story(story) { Dock = System.Windows.Forms.DockStyle.Fill });
          wb_description.DocumentText = story.description;
        }
        else if ("\"Run\"".Equals(octane.ValidationText, StringComparison.OrdinalIgnoreCase))
        {
          Run run = JsonConvert.DeserializeObject<Run>(octane.Value);
          p_fields.Controls.Add(new FieldsDetail_Run(run) { Dock = System.Windows.Forms.DockStyle.Fill });
          wb_description.DocumentText = run.description;
          tabControl1.TabPages.Add(tp_runSteps);
          
          if (run.steps != null)
          {
            var html = new StringBuilder();
            html.Append("<html><body>");
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
          p_fields.Controls.Add(new FieldsDetail_Test(test) { Dock = System.Windows.Forms.DockStyle.Fill });
          wb_description.DocumentText = test.description;
          rtb_testSteps.Text = test.script;
          tabControl1.TabPages.Remove(tp_testSteps);
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

    // Occurs when the form region is closed.
    // Use this.OutlookItem to get a reference to the current Outlook item.
    // Use this.OutlookFormRegion to get a reference to the form region.
    private void OctaneTaskDetail_FormRegionClosed(object sender, System.EventArgs e)
    {
    }
  }
}
