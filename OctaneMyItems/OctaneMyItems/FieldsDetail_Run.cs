using OctaneMyItemsSyncService.Models;
using System.Windows.Forms;
using System.Linq;

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
      tb_release.Text = run.release?.name;
      tb_draftRun.Text = run.draft_run ? "Yes" : "No";
      tb_lastModified.Text = run.last_modified?.ToString();
      if(run.taxonomies?.data.Count() > 0)
      {
        tb_environment.Text = "";
        foreach (var item in run.taxonomies.data)
        {
          var temp = (item.category != null ? item.category.name + ": " : "") + item.name;
          if (tb_environment.Text == "")
            tb_environment.Text = temp;
          else
            tb_environment.Text += "; " + temp;
        }
      }
    }
  }
}
