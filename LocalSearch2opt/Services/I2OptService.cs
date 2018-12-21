using LocalSearchTSP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalSearchTSP.Services
{
    public interface I2OptService
    {
        List<Point> Swap2Opt(List<Point> route, int indexFirstPoint, int indexSecondPoint);
        List<Point> Run2Opt(List<Point> route);
    }
}