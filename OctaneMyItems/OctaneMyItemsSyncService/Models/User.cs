/* 
  (c) Copyright 2016 Hewlett Packard Enterprise Development LP

  Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with the License.

  You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0

  Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an "AS IS" BASIS,

  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.

  See the License for the specific language governing permissions and limitations under the License.
*/

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
