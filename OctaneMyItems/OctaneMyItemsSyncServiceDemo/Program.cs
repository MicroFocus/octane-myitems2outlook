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
      OctaneService octaneService = new OctaneService("https://hackathon.almoctane.com");
      await octaneService.Login("binwen.wu@hpe.com", "Mission-Possible");

      octaneService.SetDefaultSharespace(1001);

      var workspaces = await octaneService.GetWorkspace();
      await octaneService.SetDefaultWorkspace(workspaces.data.First(x => x.name == "D22438_Aimon_Xia_My_Items_2_Outlook"));

      //var backlogs = await octaneService.GetBacklogs();
      var myBacklogs = await octaneService.GetMyBacklogs();
      var backlog = await octaneService.GetBacklog(2504);

      //var tests = await octaneService.GetTests();
      var myTests = await octaneService.GetMyTests();
      var test = await octaneService.GetTest(1656);

      //var runs = await octaneService.GetRuns();
      var myRuns = await octaneService.GetMyRuns();
      var run = await octaneService.GetRun(9566);

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
