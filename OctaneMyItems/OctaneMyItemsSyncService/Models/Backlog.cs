using System;

namespace OctaneMyItemsSyncService.Models
{
    public class Backlogs
    {
        public int total_count { get; set; }
        public Backlog[] data { get; set; }
        public bool exceeds_total_count { get; set; }
    }

    public class Backlog
    {
        public string type { get; set; }
        public DateTime creation_time { get; set; }
        public Parent parent { get; set; }
        public string logical_name { get; set; }
        public object initial_estimate { get; set; }
        public object defect_root_level { get; set; }
        public int version_stamp { get; set; }
        public object item_type { get; set; }
        public object release { get; set; }
        public object sprint { get; set; }
        public object description { get; set; }
        public object detected_in_release { get; set; }
        public object fixed_in_build { get; set; }
        public string path { get; set; }
        public object item_origin { get; set; }
        public object qa_owner { get; set; }
        public Detected_By detected_by { get; set; }
        public string subtype { get; set; }
        public object closed_on { get; set; }
        public int rank { get; set; }
        public int id { get; set; }
        public DateTime last_modified { get; set; }
        public Severity severity { get; set; }
        public Phase phase { get; set; }
        public Owner owner { get; set; }
        public object fixed_on { get; set; }
        public bool has_attachments { get; set; }
        public Author author { get; set; }
        public object story_points { get; set; }
        public Product_Areas product_areas { get; set; }
        public object team { get; set; }
        public object priority { get; set; }
        public User_Tags user_tags { get; set; }
        public bool has_comments { get; set; }
        public Taxonomies taxonomies { get; set; }
        public string name { get; set; }
        public object original_id { get; set; }
        public object detected_in_build { get; set; }
    }

    public class Parent
    {
        public string type { get; set; }
        public int id { get; set; }
    }

    public class Detected_By
    {
        public string type { get; set; }
        public int id { get; set; }
    }

    public class Severity
    {
        public string type { get; set; }
        public int id { get; set; }
    }

    public class Phase
    {
        public string type { get; set; }
        public int id { get; set; }
    }

    public class Owner
    {
        public string type { get; set; }
        public int id { get; set; }
    }

    public class Author
    {
        public string type { get; set; }
        public int id { get; set; }
    }

    public class Product_Areas
    {
        public int total_count { get; set; }
        public object[] data { get; set; }
    }

    public class User_Tags
    {
        public int total_count { get; set; }
        public object[] data { get; set; }
    }

    public class Taxonomies
    {
        public int total_count { get; set; }
        public object[] data { get; set; }
    }
}
