using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalSearchTSP.Model
{
    public class Point
    {
        public int number { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public Point()
        {
            number = 0;
            x = 0;
            y = 0;
        }
    }
}
