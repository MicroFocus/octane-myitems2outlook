namespace OctaneMyItemsSyncService.Models
{

  public class SharedSpaces
  {
    public int total_count { get; set; }
    public SharedSpace[] data { get; set; }
    public bool exceeds_total_count { get; set; }
  }

  public class SharedSpace
  {
    public string type { get; set; }
    public string logical_name { get; set; }
    public string name { get; set; }
    public int? id { get; set; }
  }
}
