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

            //var tests = await octaneService.GetTests();
            //var myTests = await octaneService.GetMyTests();

            //var runs = await octaneService.GetRuns();
            //var myRuns = await octaneService.GetMyRuns();

            await octaneService.Logout();
        }
    }
}
