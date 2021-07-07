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
    public string id { get; set; }
  }
}
