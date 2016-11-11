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
  public partial class FieldsDetail_Defect : UserControl
  {
    public FieldsDetail_Defect(Backlog backlog)
    {
      InitializeComponent();

      tb_parent.Text = backlog.parent?.name;
      tb_detectedBy.Text = backlog.detected_by?.name;
      tb_owner.Text = backlog.owner?.name;
      tb_severity.Text = backlog.severity?.name;
      tb_lastModified.Text = backlog.last_modified.ToLocalTime().ToString();
      tb_detectedInRelease.Text = backlog.detected_in_release?.name;
      tb_creationTime.Text = backlog.creation_time.ToLocalTime().ToString();
      tb_closeOn.Text = backlog.closed_on?.ToLocalTime().ToString();
      tb_priority.Text = backlog.priority?.name;
      if (backlog.product_areas?.data.Count() > 0)
      {
        tb_applicationModules.Text = "";
        foreach (var item in backlog.product_areas.data)
        {
          if (tb_applicationModules.Text == "")
            tb_applicationModules.Text += item.name;
          else
            tb_applicationModules.Text += "; " + item.name;
        }
      }
      tb_storyPoints.Text = backlog.story_points?.ToString();
      tb_release.Text = backlog.release?.name;
      tb_sprint.Text = backlog.sprint?.name;
      tb_itemType.Text = backlog.defect_type?.name;
      tb_team.Text = backlog.team?.name;
      if (backlog.taxonomies?.data.Count() > 0)
      {
        tb_environment.Text = "";
        foreach (var item in backlog.taxonomies.data)
        {
          if (tb_environment.Text == "")
            tb_environment.Text += item.name;
          else
            tb_environment.Text += "; " + item.name;
        }
      }
    }
  }
}
