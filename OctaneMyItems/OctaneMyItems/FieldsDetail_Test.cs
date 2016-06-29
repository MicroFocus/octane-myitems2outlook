using OctaneMyItemsSyncService.Models;
using System.Windows.Forms;
using System.Linq;

namespace OctaneMyItems
{
  public partial class FieldsDetail_Test : UserControl
  {
    public FieldsDetail_Test(Test test)
    {
      InitializeComponent();

      tb_testType.Text = test.test_type?.data?.ToString();
      tb_testingToolType.Text = test.testing_tool_type?.name;
      tb_owner.Text = test.owner?.name;
      tb_estimatedDuration.Text = test.estimated_duration;
      tb_designer.Text = test.designer?.name;
      tb_created.Text = test.created?.ToString();
      tb_lastModified.Text = test.last_modified?.ToString();
      tb_converedContent.Visible = false;
      tb_applicationModules.Visible = false;
    }
  }
}
