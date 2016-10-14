﻿using OctaneMyItemsSyncService.Models;
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
