using OctaneMyItemsSyncService.Models;
using System.Windows.Forms;

namespace OctaneMyItems
{
  public partial class FieldsDetail_Backlog : UserControl
  {
    public FieldsDetail_Backlog(Backlog backlog)
    {
      InitializeComponent();

      tb_parent.Text = backlog.parent.name;
      tb_detectedBy.Text = backlog.detected_by.name;
      tb_owner.Text = backlog.owner.name;
      tb_severity.Text = backlog.severity.name;
      tb_lastModified.Text = backlog.last_modified.ToString();
      tb_detectedInRelease.Text = backlog.detected_in_release.name;
    }
  }
}
