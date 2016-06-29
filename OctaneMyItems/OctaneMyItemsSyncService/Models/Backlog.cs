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
        public ListNode defect_root_level { get; set; }
        public int version_stamp { get; set; }
        public ListNode item_type { get; set; }
        public Release release { get; set; }
        public object sprint { get; set; }
        public string description { get; set; }
        public Release detected_in_release { get; set; }
        public long? fixed_in_build { get; set; }
        public string path { get; set; }
        public ListNode item_origin { get; set; }
        public User qa_owner { get; set; }
        public User detected_by { get; set; }
        public string subtype { get; set; }
        public DateTime? closed_on { get; set; }
        public int rank { get; set; }
        public int id { get; set; }
        public DateTime last_modified { get; set; }
        public ListNode severity { get; set; }
        public Phase phase { get; set; }
        public User owner { get; set; }
        public DateTime? fixed_on { get; set; }
        public bool has_attachments { get; set; }
        public User author { get; set; }
        public long? story_points { get; set; }
        public Product_Areas product_areas { get; set; }
        public object team { get; set; }
        public ListNode priority { get; set; }
        public User_Tags user_tags { get; set; }
        public bool has_comments { get; set; }
        public Taxonomies taxonomies { get; set; }
        public string name { get; set; }
        public object original_id { get; set; }
        public long? detected_in_build { get; set; }
    }

    public class Parent
    {
        public string type { get; set; }
        public string subtype { get; set; }
        public string name { get; set; }
        public int id { get; set; }
    }

    public class Phase
    {
        public string type { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int index { get; set; }
    }

    public class Product_Areas
    {
        public int total_count { get; set; }
        public Product_Area[] data { get; set; }
    }

    public class Product_Area
    {
        public string type { get; set; }
        public string name { get; set; }
        public int id { get; set; }
        
    }

    public class User_Tags
    {
        public int total_count { get; set; }
        public User_Tag[] data { get; set; }
    }

    public class User_Tag
    {
        public string type { get; set; }
        public string name { get; set; }
        public int id { get; set; }

    }

    public class Taxonomies
    {
        public int total_count { get; set; }
        public Taxonomy[] data { get; set; }
    }

    public class Taxonomy
    {
        public string type { get; set; }
        public string subtype { get; set; }
        public string name { get; set; }
        public int id { get; set; }
        public TaxonomyCategory category { get; set; }

    }

    public class TaxonomyCategory
    {
        public string type { get; set; }
        public string name { get; set; }
        public int id { get; set; }
    }
    public class ListNode
    {
        public string type { get; set; }
        public string logical_name { get; set; }
        public string name { get; set; }
        public int id { get; set; }
        public int index { get; set; }
    }

}
