using LocalSearchTSP.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalSearchTSP.Services.Implements
{
    public class LocalSearchService : ILocalSearchService
    {
        public int CaculateLengthByPoint(Point firstPoint, Point secondPoint)
        {
            int dx, dy, d;
            dx = firstPoint.x - secondPoint.x;
            dy = firstPoint.y - secondPoint.y;
            d = Convert.ToInt32(Math.Sqrt(dx * dx + dy * dy));
            return d;
        }
        public int CaculateLengthByRoute(List<Point> route)
        {
            int length = 0;
            Point point = new Point();
            foreach (Point node in route)
            {
                length = length + CaculateLengthByPoint(node, point);
                point = node;
            }
            return length;
        }
        public List<Point> ReadFile(string fileName)
        {
            List<Point> route = new List<Point>();
            StreamReader sr = new StreamReader(fileName);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                if (line == "EOF") break;
                string[] checkLine = line.Split();
                if (checkLine[0].ToString() == "NAME" || checkLine[0].ToString() == "COMMENT" || checkLine[0].ToString() == "TYPE" || checkLine[0].ToString() == "DIMENSION" || checkLine[0].ToString() == "EDGE_WEIGHT_TYPE" || checkLine[0].ToString() == "NODE_COORD_SECTION") continue;
                Point point = new Point();
                point = ConvertLineToPoint(line);
                if (point.number == 0)
                {
                    Console.Write("Invalid Data!");
                }
                route.Add(point);
            }
            return route;
        }
        public Point ConvertLineToPoint(string line)
        {
            string[] data;
            data = line.Split();
            Point point = new Point();
            point.number = Convert.ToInt32(data[0]);
            point.x = (int) Math.Floor(Convert.ToDecimal(data[1]));
            point.y = (int)Math.Floor(Convert.ToDecimal(data[2]));
            return point;
        }
    }
}
