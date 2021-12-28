using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSzpitali
{
    public class NeighboursDistances
    {
        public NeighboursDistances() { }
        public NeighboursDistances(Point _point, double _disatnce) 
        {
            Point = _point;
            Distance = _disatnce;
        }

        public string ToString()
        {
            return Point.ToString() + ": " + Distance.ToString();
        }

        public Point Point { get; set; }
        public double Distance { get; set; }        
    }
}
