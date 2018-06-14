/* 
  (c) Copyright 2016 Hewlett Packard Enterprise Development LP

  Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with the License.

  You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0

  Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an "AS IS" BASIS,

  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.

  See the License for the specific language governing permissions and limitations under the License.
*/

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
    public int version_stamp { get; set; }
    public StepType item_type { get; set; }
    public Defect_Root_Level defect_root_level { get; set; }
    public Release release { get; set; }
    public Sprint sprint { get; set; }
    public string description { get; set; }
    public int? fixed_in_build { get; set; }
    public Detected_In_Release detected_in_release { get; set; }
    public string path { get; set; }
    public object wsjf_score { get; set; }
    public Item_Origin item_origin { get; set; }
    public string subtype { get; set; }
    public Qa_Owner qa_owner { get; set; }
    public Detected_By detected_by { get; set; }
    public DateTime? closed_on { get; set; }
    public object quality_story_type { get; set; }
    public string id { get; set; }
    public DateTime last_modified { get; set; }
    public Defect_Type defect_type { get; set; }
    public Phase phase { get; set; }
    public User owner { get; set; }
    public Severity severity { get; set; }
    public object rroe { get; set; }
    public DateTime? fixed_on { get; set; }
    public bool has_attachments { get; set; }
    public object epic_type { get; set; }
    public Author author { get; set; }
    public long? story_points { get; set; }
    public Product_Areas product_areas { get; set; }
    public Team team { get; set; }
    public Priority priority { get; set; }
    public object feature_type { get; set; }
    public bool has_comments { get; set; }
    public Taxonomies taxonomies { get; set; }
    public object time_criticality { get; set; }
    public string name { get; set; }
    public object job_size { get; set; }
    public object business_value { get; set; }
    public object original_id { get; set; }
    public int? detected_in_build { get; set; }
    public Comments comments { get; set; }
  }

  public class Parent
  {
    public string type { get; set; }
    public string subtype { get; set; }
    public string name { get; set; }
    public string id { get; set; }
  }

  public class Defect_Root_Level
  {
    public string type { get; set; }
    public string logical_name { get; set; }
    public string name { get; set; }
    public int index { get; set; }
    public string id { get; set; }
  }

  public class Sprint
  {
    public string type { get; set; }
    public DateTime end_date { get; set; }
    public string name { get; set; }
    public string id { get; set; }
    public DateTime start_date { get; set; }
  }

  public class Detected_In_Release
  {
    public string type { get; set; }
    public string name { get; set; }
    public string id { get; set; }
  }

  public class Item_Origin
  {
    public string type { get; set; }
    public string logical_name { get; set; }
    public string name { get; set; }
    public int index { get; set; }
    public string id { get; set; }
  }

  public class Qa_Owner
  {
    public string type { get; set; }
    public string full_name { get; set; }
    public string name { get; set; }
    public string id { get; set; }
  }

  public class Detected_By
  {
    public string type { get; set; }
    public string full_name { get; set; }
    public string name { get; set; }
    public string id { get; set; }
  }

  public class Defect_Type
  {
    public string type { get; set; }
    public string logical_name { get; set; }
    public string name { get; set; }
    public int index { get; set; }
    public string id { get; set; }
  }

  public class Phase
  {
    public string type { get; set; }
    public string name { get; set; }
    public int index { get; set; }
    public string id { get; set; }
  }

  public class Severity
  {
    public string type { get; set; }
    public string logical_name { get; set; }
    public string name { get; set; }
    public int index { get; set; }
    public string id { get; set; }
  }

  public class Author
  {
    public string type { get; set; }
    public string full_name { get; set; }
    public string name { get; set; }
    public string id { get; set; }
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
    public string id { get; set; }
  }

  public class Priority
  {
    public string type { get; set; }
    public string logical_name { get; set; }
    public string name { get; set; }
    public int index { get; set; }
    public string id { get; set; }
  }

  public class Taxonomies
  {
    public int total_count { get; set; }
    public Taxonomy[] data { get; set; }
  }

  public class Taxonomy
  {
    public string type { get; set; }
    public string logical_name { get; set; }
    public string subtype { get; set; }
    public string name { get; set; }
    public string id { get; set; }
    public Category category { get; set; }
  }

  public class Category
  {
    public string type { get; set; }
    public string name { get; set; }
    public string id { get; set; }
  }
}
