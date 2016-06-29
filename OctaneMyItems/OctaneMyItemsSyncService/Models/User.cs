namespace OctaneMyItemsSyncService.Models
{
  public class Users
  {
    public int total_count { get; set; }
    public User[] data { get; set; }
    public bool exceeds_total_count { get; set; }
  }

  public class User
  {
    public string type { get; set; }
    public string uid { get; set; }
    public string full_name { get; set; }
    public string phone2 { get; set; }
    public string name { get; set; }
    public string phone3 { get; set; }
    public string last_name { get; set; }
    public string language { get; set; }
    public int id { get; set; }
    public string first_name { get; set; }
    public string email { get; set; }
    public string phone1 { get; set; }
  }
}
