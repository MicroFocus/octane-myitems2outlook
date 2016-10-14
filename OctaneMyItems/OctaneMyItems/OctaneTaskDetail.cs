using Newtonsoft.Json;
using OctaneMyItemsSyncService.Models;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace OctaneMyItems
{
  partial class OctaneTaskDetail
  {
    #region Form Region Factory 

    [Microsoft.Office.Tools.Outlook.FormRegionMessageClass(Constants.OctaneTask)]
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

    private readonly Color ThemeColor = Color.FromArgb(0, 179, 136);

    // Occurs before the form region is displayed.
    // Use this.OutlookItem to get a reference to the current Outlook item.
    // Use this.OutlookFormRegion to get a reference to the form region.
    private void OctaneTaskDetail_FormRegionShowing(object sender, System.EventArgs e)
    {
      var octaneTask = this.OutlookItem as Outlook.TaskItem;
      var octane = octaneTask.UserProperties["Octane"];
      if (octane == null) return;

      tabControl1.BackColor = Color.White;
      tabControl1.TabPages.Remove(tp_runSteps);
      tabControl1.TabPages.Remove(tp_testSteps);
      try
      {
        var url = $"{ThisAddIn.Configuration.ServerUrl}/ui/entity-navigation?p={ThisAddIn.Configuration.SharedspaceId}/{ThisAddIn.Configuration.WorkspaceId}";
        if ("\"Defect\"".Equals(octane.ValidationText, StringComparison.OrdinalIgnoreCase))
        {
          Backlog backlog = JsonConvert.DeserializeObject<Backlog>(octane.Value);
          InsertDetailControl(new FieldsDetail_Defect(backlog));
          InsertLinkLabelWithStatus(backlog.id.ToString(), url + "&entityType=work_item&id=" + backlog.id, backlog.phase?.name);

          wb_description.DocumentText = GenerateDescriptHtml(backlog.description);
          wb_comments.DocumentText = GenerateCommentsHtml(backlog.comments);
        }
        else if ("\"Story\"".Equals(octane.ValidationText, StringComparison.OrdinalIgnoreCase))
        {
          Backlog story = JsonConvert.DeserializeObject<Backlog>(octane.Value);
          InsertDetailControl(new FieldsDetail_Story(story));
          InsertLinkLabelWithStatus(story.id.ToString(), url + "&entityType=work_item&id=" + story.id, story.phase?.name);

          wb_description.DocumentText = GenerateDescriptHtml(story.description);
          wb_comments.DocumentText = GenerateCommentsHtml(story.comments);
        }
        else if ("\"Run\"".Equals(octane.ValidationText, StringComparison.OrdinalIgnoreCase))
        {
          Run run = JsonConvert.DeserializeObject<Run>(octane.Value);
          InsertDetailControl(new FieldsDetail_Run(run));
          InsertLinkLabelWithStatus(run.id.ToString(), url + "&entityType=run&id=" + run.id, run.status?.name);

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
          InsertDetailControl(new FieldsDetail_Test(test));
          InsertLinkLabelWithStatus(test.id.ToString(), url + "&entityType=test&id=" + test.id, test.phase?.name);

          wb_description.DocumentText = GenerateDescriptHtml(test.description);
          wb_comments.DocumentText = GenerateCommentsHtml(test.comments);
          tabControl1.TabPages.Add(tp_testSteps);
          rtb_testSteps.Text = test.script;
        }
        else
        {
          Visible = false;
          Height = 0;
          return;
        }
      }
      catch (Exception ex)
      {
        System.Windows.Forms.MessageBox.Show(ex.Message);
        Visible = false;
        Height = 0;
        return;
      }
      
      int actualHeight = 0;
      foreach (Control item in Controls)
      {
        actualHeight += item.Height;
      }
      Height = actualHeight;
    }

    private void InsertLinkLabelWithStatus(string urlReplace, string url, string status)
    {
      var linkLabel = new Label()
      {
        UseMnemonic = false,
        Text = $"ID: {urlReplace}",
        Cursor = Cursors.Hand,
        ForeColor = Color.FromArgb(14, 111, 154),
        Font = new Font("Arial", 14, FontStyle.Underline, GraphicsUnit.Pixel),
        Dock = DockStyle.Left,
        AutoSize = true,
        TextAlign = ContentAlignment.MiddleLeft,
        ContextMenu = new ContextMenu(new MenuItem[] {
          new MenuItem("Copy", (s, e) => Clipboard.SetText(url)) }),
      };
      linkLabel.MouseClick += (s, e) =>
      {
        if (e.Button == MouseButtons.Left)
          Process.Start(url);
      };

      var panel = new Panel()
      {
        Padding = new Padding(15, 5, 5, 0),
        Dock = DockStyle.Top,
        AutoSize = true
      };
      if (!string.IsNullOrEmpty(status))
      {
        var statusLabel = new Label()
        {
          Text = $"Status: {status}",
          Font = new Font("Arial", 14, GraphicsUnit.Pixel),
          ForeColor = Color.FromArgb(85, 85, 85),
          Dock = DockStyle.Fill,
          TextAlign = ContentAlignment.MiddleLeft,
          AutoSize = true,
        };

        var spliter = new Label()
        {
          Text = "  /  ",
          Font = new Font("Arial", 14, GraphicsUnit.Pixel),
          ForeColor = Color.FromArgb(85, 85, 85),
          Dock = DockStyle.Left,
          TextAlign = ContentAlignment.MiddleLeft,
          AutoSize = true,
        };

        panel.Controls.Add(statusLabel);
        panel.Controls.Add(spliter);
      }
      else
        linkLabel.Dock = DockStyle.Fill;
      panel.Controls.Add(linkLabel);

      Controls.Add(panel);
    }

    private void InsertDetailControl(Control parentControl)
    {
      var control = parentControl.Controls[0];
      control.Dock = DockStyle.Top;
      control.Padding = new Padding(0, 0, 5, 5);
      Controls.Add(control);
    }

    private string GenerateDescriptHtml(string descript)
    {
      if (string.IsNullOrEmpty(descript)) return string.Empty;
      return descript.Replace("<body>", "<body style=\"overflow: auto; font-family:Arial; font-size=12px; color:#555555;\">");
    }

    private readonly string commentTemplate =
@"<div style=""margin: 2px; font-family:Arial; font-size=12px; color:#555555;"">		<div style=""background-color: #ededed;height: 20px;"">
      <span style=""font-family:Arial;font-size:12px;position:relative;color:#01a982;""> name </span>			<span style=""font-family:Arial;font-size:10px;position:relative;color:#777777;""> time </span>
    </div>
    <div> comment </div></div>";
    private string GenerateCommentsHtml(Comments comments)
    {
      if (comments == null || comments.data == null || comments.data.Count() == 0)
        return string.Empty;

      var html = new StringBuilder();
      html.Append("<!DOCTYPE html><html><body style=\"overflow: auto; font-family:Arial; font-size=12px; color:#555555;\">");
      foreach (Comment item in comments.data)
      {
        html.Append(commentTemplate
          .Replace("name", item.author.name)
          .Replace("time", item.last_modified.ToString())
          .Replace("comment", item.text?
            .Replace("<html><body>\n", "").Replace("\n</body></html>", "")));
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

    private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
    {
      //this eventhandler is called only if:
      //DrawMode = OwnerDrawFixed
      Rectangle tab_rect = tabControl1.GetTabRect(e.Index);
      tab_rect.X -= 2;
      tab_rect.Y -= 2;
      tab_rect.Width += 4;
      tab_rect.Height += 4;

      e.Graphics.FillRectangle(Brushes.White, e.Bounds);

      if (e.Index == tabControl1.SelectedIndex)
      {
        var indicator = new Rectangle(e.Bounds.X, e.Bounds.Y + 24, e.Bounds.Width, 4);
        e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(1, 169, 130)), indicator);
      }
      
      //also draw the text
      var fntTab = new Font("Arial", 14, GraphicsUnit.Pixel);
      var bshFore = new SolidBrush(Color.FromArgb(34, 34, 34));
      string tabName = this.tabControl1.TabPages[e.Index].Text;
      var sftTab = new StringFormat() { Alignment = StringAlignment.Center };
      var recTab = new Rectangle(e.Bounds.X + 5, e.Bounds.Y + 4, e.Bounds.Width - 10, e.Bounds.Height - 4);
      e.Graphics.DrawString(tabName, fntTab, bshFore, recTab, sftTab);
    }
  }
}
