using System;

namespace OctaneMyItemsSyncService.Models
{
  public class Workspaces
  {
    public int total_count { get; set; }
    public Workspace[] data { get; set; }
    public bool exceeds_total_count { get; set; }
  }

  public class Workspace
  {
    public string type { get; set; }
    public DateTime? creation_time { get; set; }
    public string logical_name { get; set; }
    public int? version_stamp { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public int? id { get; set; }
    public DateTime? last_modified { get; set; }
  }
}
