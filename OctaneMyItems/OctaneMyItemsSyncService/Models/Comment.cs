using System;

namespace OctaneMyItemsSyncService.Models
{

  public class Comments
    {
        public int total_count { get; set; }
        public Comment[] data { get; set; }
        public bool exceeds_total_count { get; set; }
    }

    public class Comment
    {
        public DateTime creation_time { get; set; }
        public User author { get; set; }
        public string text { get; set; }
        public int id { get; set; }
        public DateTime last_modified { get; set; }
    }
}
