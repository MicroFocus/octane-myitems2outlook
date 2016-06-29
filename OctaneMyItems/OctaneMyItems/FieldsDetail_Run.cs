using OctaneMyItemsSyncService.Models;
using System.Windows.Forms;

namespace OctaneMyItems
{
  public partial class FieldsDetail_Run : UserControl
  {
    public FieldsDetail_Run(Run run)
    {
      InitializeComponent();

      tb_testName.Text = run.test_name;
      tb_nativeStatus.Text = run.native_status?.name;
      tb_runBy.Text = run.run_by?.name;
      tb_started.Text = run.started?.ToString();
      tb_duration.Text = run.duration;
      //tb_content.Visible = false;
      tb_release.Text = run.release?.name;
      tb_draftRun.Text = run.draft_run ? "Yes" : "No";
      tb_lastModified.Text = run.last_modified?.ToString();
      tb_environment.Text = run.environment_hash;
    }
  }
}
