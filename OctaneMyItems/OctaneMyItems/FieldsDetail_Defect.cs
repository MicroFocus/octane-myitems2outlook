using OctaneMyItemsSyncService.Models;
using System.Windows.Forms;

namespace OctaneMyItems
{
  public partial class FieldsDetail_Defect : UserControl
  {
    public FieldsDetail_Defect(Backlog backlog)
    {
      InitializeComponent();

      tb_parent.Text = backlog.parent?.name;
      tb_detectedBy.Text = backlog.detected_by?.name;
      tb_owner.Text = backlog.owner?.name;
      tb_severity.Text = backlog.severity?.name;
      tb_lastModified.Text = backlog.last_modified.ToString();
      tb_detectedInRelease.Text = backlog.detected_in_release?.name;
      tb_creationTime.Text = backlog.creation_time.ToString();
      tb_closeOn.Text = backlog.closed_on?.ToString();
      tb_fixedOn.Text = backlog.fixed_on?.ToString();
      tb_priority.Text = backlog.priority?.name;
      //tb_applicationModules.Visible = false;
      tb_storyPoints.Text = backlog.story_points?.ToString();
      tb_release.Text = backlog.release?.name;
      tb_sprint.Text = backlog.sprint?.name;
      tb_itemType.Text = backlog.item_type?.name;
      tb_team.Text = backlog.team?.name;
      //tb_environment.Visible = false;
    }
  }
}
