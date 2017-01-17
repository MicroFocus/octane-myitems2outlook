/* 
  (c) Copyright 2016 Hewlett Packard Enterprise Development LP

  Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with the License.

  You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0

  Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an "AS IS" BASIS,

  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.

  See the License for the specific language governing permissions and limitations under the License.
*/

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
      tb_started.Text = run.started?.ToLocalTime().ToString();
      tb_release.Text = run.release?.name;
      tb_draftRun.Text = run.draft_run ? "Yes" : "No";
      tb_lastModified.Text = run.last_modified?.ToLocalTime().ToString();
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
