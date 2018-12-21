using LocalSearchTSP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalSearchTSP.Services.Implements
{
    public class _2OptService : I2OptService
    {
        private ILocalSearchService _localSearchService;
        public _2OptService(ILocalSearchService localSearchService)
        {
            _localSearchService = localSearchService;
        }
        public List<Point> Swap2Opt(List<Point> route, int indexFirstPoint, int indexSecondPoint)
        {
            List<Point> newRoute = new List<Point>();
            for (int a = 0; a < indexFirstPoint; a++)
            {
                newRoute.Add(route[a]);
            }
            for (int a = indexSecondPoint; a >= indexFirstPoint; a--)
            {
                newRoute.Add(route[a]);
            }
            for (int a = indexSecondPoint + 1; a < route.Count; a++)
            {
                newRoute.Add(route[a]);
            }
            return newRoute;
        }
        public List<Point> Run2Opt(List<Point> route)
        {
            List<Point> bestRoute = new List<Point>();
            bestRoute = route;
            int minDistance = _localSearchService.CaculateLengthByRoute(route);
            int enhancement = 0;
            while (enhancement < 20)
            {
                for (int i = 0; i < bestRoute.Count - 1; i++)
                {
                    for (int k = i + 1; k < bestRoute.Count; k++)
                    {
                        List<Point> newRoute = new List<Point>();
                        newRoute = Swap2Opt(bestRoute, i, k);
                        int newDistance = _localSearchService.CaculateLengthByRoute(newRoute);
                        if (newDistance < minDistance)
                        {
                            enhancement = 0;
                            minDistance = newDistance;
                            bestRoute = newRoute;
                        }
                    }
                }
                enhancement++;
            }
            return bestRoute;
        }
    }
}
