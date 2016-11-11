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

namespace OctaneMyItems
{
  public partial class FieldsDetail_Story : UserControl
  {
    public FieldsDetail_Story(Backlog backlog)
    {
      InitializeComponent();

      tb_id.Text = backlog.id.ToString();
      tb_owner.Text = backlog.owner?.name;
      tb_creationTime.Text = backlog.creation_time.ToLocalTime().ToString();
      tb_lastModified.Text = backlog.last_modified.ToLocalTime().ToString();
      tb_storyPoints.Text = backlog.story_points?.ToString();
      tb_author.Text = backlog.author?.name;
      tb_itemOrigin.Text = backlog.item_origin?.name;
      tb_parent.Text = backlog.parent?.name;
      tb_release.Text = backlog.release?.name;
      tb_sprint.Text = backlog.sprint?.name;
      tb_team.Text = backlog.team?.name;
    }
  }
}
