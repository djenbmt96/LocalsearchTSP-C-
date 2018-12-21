using LocalSearchTSP.Model;
using LocalSearchTSP.Services;
using LocalSearchTSP.Services.Implements;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalSearchTSP.Processors
{
    public class LocalSearchProcessor
    {
        private ILocalSearchService _localSearchService;
        private I2OptService _2OptService;

        public LocalSearchProcessor(ILocalSearchService localSearchService, I2OptService i2OptService)
        {
            this._localSearchService = localSearchService;
            this._2OptService = i2OptService;
        }
        public void Run()
        {
            List<Point> route = new List<Point>();
            List<Point> randomRoute = new List<Point>();

            var fileName = "filetest.txt";
            var timeRecord = new Stopwatch();
            var random = new Random();

            route = _localSearchService.ReadFile(fileName);
            var startPoint = random.Next(1, route.Count - 1);

            for (var i = startPoint; i < route.Count; i++)
            {
                randomRoute.Add(route[i]);
            }
            for (var i = 0; i < startPoint; i++)
            {
                randomRoute.Add(route[i]);
            }

            route = randomRoute;
            timeRecord.Start();
            Console.WriteLine("Runing...");
            route = _2OptService.Run2Opt(route);
            timeRecord.Stop();

            Console.Write("Route: ");
            for (int i = 0; i < route.Count; i++)
            {
                Console.Write(route[i].number + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Number of Point: " + route.Count);
            Console.WriteLine("Best Distance: " + _localSearchService.CaculateLengthByRoute(route));
            Console.WriteLine("Runing Time: {0} seconds", (timeRecord.ElapsedMilliseconds / 1000).ToString());
            Console.ReadLine();
        }
    }
}
