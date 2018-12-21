using LocalSearchTSP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalSearchTSP.Services
{
    public interface ILocalSearchService
    {
        int CaculateLengthByPoint(Point firstPoint, Point secondPoint);
        int CaculateLengthByRoute(List<Point> route);
        List<Point> ReadFile(string fileName);
        Point ConvertLineToPoint(string line);
    }
}
