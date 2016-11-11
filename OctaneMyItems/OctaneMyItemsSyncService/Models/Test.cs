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
  public class Tests
  {
    public int total_count { get; set; }
    public Test[] data { get; set; }
    public bool exceeds_total_count { get; set; }
  }

  public class Test
  {
    public string type { get; set; }
    public DateTime? creation_time { get; set; }
    public Covered_Contents covered_content { get; set; }
    public int? version_stamp { get; set; }
    public string description { get; set; }
    public string script_path { get; set; }
    public bool manual { get; set; }
    public int? latest_version { get; set; }
    public string subtype { get; set; }
    public int? steps_num { get; set; }
    public int id { get; set; }
    //public string class_name { get; set; }
    public DateTime? last_modified { get; set; }
    public int? approved_version { get; set; }
    public Phase phase { get; set; }
    public User owner { get; set; }
    //public object package { get; set; }
    public bool has_attachments { get; set; }
    public DateTime? created { get; set; }
    public Product_Areas product_areas { get; set; }
    //public object test_level { get; set; }
    public User designer { get; set; }
    public string estimated_duration { get; set; }
    public string sha { get; set; }
    public string identity_hash { get; set; }
    public Test_Type test_type { get; set; }
    public User_Tags user_tags { get; set; }
    //public object component { get; set; }
    //public object framework { get; set; }
    public Testing_Tool_Type testing_tool_type { get; set; }
    public bool has_comments { get; set; }
    //public object automation_identifier { get; set; }
    public string name { get; set; }
    //public Automation_Status automation_status { get; set; }
    //test script of manual or gherkin test
    public string script { get; set; }

    public Comments comments { get; set; }
  }

  public class Covered_Contents
  {
    public int total_count { get; set; }
    public Covered_Content[] data { get; set; }
  }

  public class Covered_Content
  {
    public string type { get; set; }
    public string subtype { get; set; }
    public string name { get; set; }
    public string id { get; set; }
  }


  public class Test_Type
  {
    public int total_count { get; set; }
    public ListNode[] data { get; set; }
  }


  public class Testing_Tool_Type
  {
    public string type { get; set; }
    public string name { get; set; }
    public string logical_name { get; set; }
    public int id { get; set; }
    public int? index { get; set; }

  }

  public class TestScript
  {
    public string script { get; set; }
    public string sha { get; set; }
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
}
