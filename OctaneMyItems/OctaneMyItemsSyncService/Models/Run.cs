using System;

namespace OctaneMyItemsSyncService.Models
{
  public class Runs
  {
    public int total_count { get; set; }
    public Run[] data { get; set; }
    public bool exceeds_total_count { get; set; }
  }

  public class Run
  {
    public string type { get; set; }
    public DateTime? creation_time { get; set; }
    //public object discovered { get; set; }
    //public object failed_since_build { get; set; }
    public int? version_stamp { get; set; }
    public Release release { get; set; }
    public string description { get; set; }
    //public bool manual { get; set; }
    public string duration { get; set; }
    //public object work_items_hash { get; set; }
    //public Runs_In_Suite runs_in_suite { get; set; }
    //public object test_version { get; set; }
    public string subtype { get; set; }
    public int? steps_num { get; set; }
    //public object error_details { get; set; }
    //public object failed_since_build_info { get; set; }
    //public object executor { get; set; }
    //public object error_type { get; set; }
    public int id { get; set; }
    //public object failed_build_age { get; set; }
    public DateTime? last_modified { get; set; }
    //public object class_name { get; set; }
    public string environment_hash { get; set; }
    //public object error_message { get; set; }
    //public object package { get; set; }
    //public Test test { get; set; }
    public ListNode native_status { get; set; }
    public User run_by { get; set; }
    //public object test_level { get; set; }
    public DateTime? started { get; set; }
    //public object product_areas_hash { get; set; }
    //public object identity_hash { get; set; }
    public Test_Type test_type { get; set; }
    //public object pipeline { get; set; }
    //public object component { get; set; }
    //public Testing_Tool_Type testing_tool_type { get; set; }
    public bool has_comments { get; set; }
    public Taxonomies taxonomies { get; set; }
    //public object build { get; set; }
    //public bool manage_test { get; set; }
    public bool draft_run { get; set; }
    public string name { get; set; }
    public string test_name { get; set; }
    //public object test_framework { get; set; }
    public ListNode status { get; set; }
    public Run_Steps steps { get; set; }
    public Comments comments { get; set; }

  }

  public class Release
  {
    public string type { get; set; }
    public string name { get; set; }
    public int id { get; set; }
  }

  //public class Runs_In_Suite
  //{
  //    public int total_count { get; set; }
  //    public object[] data { get; set; }
  //}

  public class Run_Steps
  {
    public int? total_count { get; set; }
    public Run_Step[] data { get; set; }
    public bool exceeds_total_count { get; set; }
  }

  public class Run_Step
  {
    public string type { get; set; }
    public DateTime? creation_time { get; set; }
    public DateTime? last_modified { get; set; }
    public string result { get; set; }
    public string actual { get; set; }
    public string description { get; set; }
    public long id { get; set; }
    public int? order { get; set; }
    public int? version_stamp { get; set; }
    public ListNode step_type { get; set; }
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
