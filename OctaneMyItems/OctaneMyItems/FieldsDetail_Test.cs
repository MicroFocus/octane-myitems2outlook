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
  public partial class FieldsDetail_Test : UserControl
  {
    public FieldsDetail_Test(Test test)
    {
      InitializeComponent();

      if(test.test_type?.data.Count() > 0)
      {
        tb_testType.Text = "";
        foreach (var item in test.test_type.data)
        {
          if (tb_testType.Text == "")
            tb_testType.Text = item.name;
          else
            tb_testType.Text += "; " + item.name;
        }
      }
      tb_testingToolType.Text = test.testing_tool_type?.name;
      tb_owner.Text = test.owner?.name;
      tb_estimatedDuration.Text = test.estimated_duration;
      tb_designer.Text = test.designer?.name;
      tb_created.Text = test.created?.ToLocalTime().ToString();
      tb_lastModified.Text = test.last_modified?.ToLocalTime().ToString();
      if(test.covered_content?.data.Count() > 0)
      {
        tb_converedContent.Text = "";
        foreach (var item in test.covered_content.data)
        {
          if (tb_converedContent.Text == "")
            tb_converedContent.Text = item.name;
          else
            tb_converedContent.Text += "; " + item.name;
        }
      }
      if (test.product_areas?.data.Count() > 0)
      {
        tb_applicationModules.Text = "";
        foreach (var item in test.product_areas.data)
        {
          if (tb_applicationModules.Text == "")
            tb_applicationModules.Text += item.name;
          else
            tb_applicationModules.Text += "; " + item.name;
        }
      }
    }
  }
}
