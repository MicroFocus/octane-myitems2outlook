/* 
  (c) Copyright 2016 Hewlett Packard Enterprise Development LP

  Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with the License.

  You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0

  Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an "AS IS" BASIS,

  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.

  See the License for the specific language governing permissions and limitations under the License.
*/

using OctaneMyItemsSyncService.Services;
using System;
using System.Linq;

namespace OctaneMyItemsSyncServiceDemo
{
  class Program
  {
    static void Main(string[] args)
    {
      Test();

      Console.ReadKey();
    }

    static async void Test()
    {
      OctaneService octaneService = new OctaneService("http://myd-vm12624.hpeswlab.net:8081/");
      var token = await octaneService.Login("sa@nga", "Welcome1");

      var sharedSpaces = await octaneService.GetSharedSpaces();

      var workspaces = await octaneService.GetWorkspaces(sharedSpaces.data[0].id.Value);
      await octaneService.SetDefaultSpace(sharedSpaces.data[0], workspaces.data.First(x => x.name == "D22438_Aimon_Xia_My_Items_2_Outlook"));

      //var backlogs = await octaneService.GetBacklogs();
      var myBacklogs = await octaneService.GetMyBacklogs();
      var backlog = await octaneService.GetBacklog(2504, true);

      //var tests = await octaneService.GetTests();
      var myTests = await octaneService.GetMyTests();
      var test = await octaneService.GetTest(1656, true);

      //var runs = await octaneService.GetRuns();
      var myRuns = await octaneService.GetMyRuns();
      var run = await octaneService.GetRun(9566, true);

      ////gherkin test
      //var ts = await octaneService.GetTestScript(1619);
      //Console.WriteLine(ts.script);
      ////manual test
      //ts = await octaneService.GetTestScript(1602);
      //Console.WriteLine(ts.script);

      //var steps = await octaneService.GetRunSteps(5162);

      //var comments = await octaneService.GetBacklogComments(2506);

      await octaneService.Logout();
    }
  }
}
